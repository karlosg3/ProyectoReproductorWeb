// src/App.jsx
import React, { useState, useEffect } from 'react';
import Board from './components/Board';
import TaskModal from './components/TaskModal';
import { DragDropContext } from '@hello-pangea/dnd';
import './App.css';
import EditIcon from './assets/edit.svg';
import TrashIcon from './assets/trash.svg';
import initialData from './initial-data'; // Importa los datos iniciales
import { loadInitialData, seedDatabase } from './initial-data';
import db from './database';
import { ApiService } from './services/apiService'
import { DatabaseService } from './database-utils';

function App() {
  const [data, setData] = useState({
    users: [
      { id: 'user-1', name: 'Fernando Lopez', avatarColor: '#FF6B6B' },
      { id: 'user-2', name: 'Alejandro Paz', avatarColor: '#3498DB' },
      { id: 'user-3', name: 'Sebastian Ruiz', avatarColor: '#4CAF50' },
      { id: 'user-4', name: 'Ernesto Flores', avatarColor: '#F44336' },
    ],
    tasks: {},
    columns: {},
    boards: {},
    activeBoardId: null
  });
  const [activeBoardId, setActiveBoardId] = useState(null);
  const [modalState, setModalState] = useState({ isOpen: false, task: null, columnId: null });

  const activeBoard = data.boards[activeBoardId];

  useEffect(() => {
    const loadData = async () => {
      try {
        // 1. Obtener desde la API
        const [usersRes, tasksRes, columnsRes, boardsRes] = await Promise.all([
          ApiService.fetchUsers(),
          ApiService.fetchTasks(),
          ApiService.fetchColumns(),
          ApiService.fetchBoards()
        ]);
  
        // 2. Guardar en IndexedDB
        await db.users.bulkPut(usersRes.data);
        await db.tasks.bulkPut(tasksRes.data);
        await db.columns.bulkPut(columnsRes.data);
        await db.boards.bulkPut(boardsRes.data);
  
        // 3. Leer desde IndexedDB para setData
        const [users, tasks, columns, boards, appState] = await Promise.all([
          db.users.toArray(),
          db.tasks.toArray(),
          db.columns.toArray(),
          db.boards.toArray(),
          DatabaseService.getAppState()
        ]);
  
        setData({
          users: Object.fromEntries(users.map(u => [u.id, u])),
          tasks: Object.fromEntries(tasks.map(t => [t.id, t])),
          columns: Object.fromEntries(columns.map(c => [c.id, c])),
          boards: Object.fromEntries(boards.map(b => [b.id, b])),
          activeBoardId: appState?.activeBoardId || (boards[0]?.id || null)
        });
        setActiveBoardId(appState?.activeBoardId || (boards[0]?.id || null));
      } catch (err) {
        console.error("Error cargando datos desde la API o IndexedDB", err);
      }
    };
  
    loadData();
  }, []);


  // Lógica de Drag and Drop
  const onDragEnd = async (result) => {
    const { destination, source, draggableId, type } = result;
    if (!destination) return;
    if (destination.droppableId === source.droppableId && destination.index === source.index) return;

    // Reordenar columnas
    if (type === 'column') {
      const newColumnOrder = Array.from(activeBoard.columnOrder);
      newColumnOrder.splice(source.index, 1);
      newColumnOrder.splice(destination.index, 0, draggableId);

      const updatedBoard = { ...activeBoard, columnOrder: newColumnOrder };
      await DatabaseService.updateBoard(updatedBoard);

      setData(prev => ({
        ...prev,
        boards: { ...prev.boards, [updatedBoard.id]: updatedBoard }
      }));
      return;
    }

    // Reordenar tarjetas
    const start = data.columns[source.droppableId];
    const finish = data.columns[destination.droppableId];

    if (start === finish) {
      const newTaskIds = Array.from(start.taskIds);
      newTaskIds.splice(source.index, 1);
      newTaskIds.splice(destination.index, 0, draggableId);
      const updatedColumn = { ...start, taskIds: newTaskIds };

      await DatabaseService.updateColumn(updatedColumn);

      setData(prev => ({
        ...prev,
        columns: { ...prev.columns, [updatedColumn.id]: updatedColumn }
      }));
      return;
    }

    const startTaskIds = Array.from(start.taskIds);
    startTaskIds.splice(source.index, 1);
    const newStart = { ...start, taskIds: startTaskIds };

    const finishTaskIds = Array.from(finish.taskIds);
    finishTaskIds.splice(destination.index, 0, draggableId);
    const newFinish = { ...finish, taskIds: finishTaskIds };

    await Promise.all([
      DatabaseService.updateColumn(newStart),
      DatabaseService.updateColumn(newFinish)
    ]);

    setData(prev => ({
      ...prev,
      columns: { ...prev.columns, [newStart.id]: newStart, [newFinish.id]: newFinish }
    }));
  };
  
  // --- Gestión de Boards ---
  const addBoard = async () => {
    const boardName = prompt("Ingresa el nombre del nuevo tablero:");
    if (!boardName) return;
    const newBoardId = `board-${Date.now()}`;
    const newBoard = { id: newBoardId, title: boardName, columnOrder: [] };
    await DatabaseService.createBoard(newBoard);
    await DatabaseService.setActiveBoard(newBoardId);

    setData(prev => ({
      ...prev,
      boards: { ...prev.boards, [newBoardId]: newBoard }
    }));
    setActiveBoardId(newBoardId);
  };
  
  const renameBoard = async (boardId, newName) => {
    if (!newName) return;
    const updatedBoard = { ...data.boards[boardId], title: newName };

    await DatabaseService.updateBoard(updatedBoard);

    setData(prev => ({
      ...prev,
      boards: { ...prev.boards, [boardId]: updatedBoard }
    }));
  };

  const deleteBoard = async (boardId) => {
    if (!window.confirm("¿Seguro que quieres eliminar este tablero y todas sus listas?")) return;

    await DatabaseService.deleteBoard(boardId);

    setData(prev => {
      const newBoards = { ...prev.boards };
      delete newBoards[boardId];
      const newActiveBoardId = Object.keys(newBoards)[0] || null;
      DatabaseService.setActiveBoard(newActiveBoardId);

      return { ...prev, boards: newBoards };
    });
    setActiveBoardId(Object.keys(data.boards).filter(id => id !== boardId)[0] || null);
  };

  // --- Gestión de Listas (Columnas) ---
  const addList = async () => {
    if (!activeBoard) return;
    const listName = prompt("Ingresa el nombre de la nueva lista:");
    if (!listName) return;

    const newColumnId = `column-${Date.now()}`;
    const newColumn = { id: newColumnId, title: listName, taskIds: [] };
    const updatedBoard = { ...activeBoard, columnOrder: [...activeBoard.columnOrder, newColumnId] };

    await DatabaseService.createColumn(newColumn);
    await DatabaseService.updateBoard(updatedBoard);

    setData(prev => ({
      ...prev,
      columns: { ...prev.columns, [newColumnId]: newColumn },
      boards: { ...prev.boards, [updatedBoard.id]: updatedBoard }
    }));
  };

  const renameList = async (columnId, newName) => {
    if (!newName) return;
    const updatedColumn = { ...data.columns[columnId], title: newName };
    await DatabaseService.updateColumn(updatedColumn);

    setData(prev => ({
      ...prev,
      columns: { ...prev.columns, [columnId]: updatedColumn }
    }));
  };

  const deleteList = async (columnId) => {
    if (!window.confirm("¿Seguro que quieres eliminar esta lista?")) return;
    const updatedBoard = { ...activeBoard, columnOrder: activeBoard.columnOrder.filter(id => id !== columnId) };

    await DatabaseService.deleteColumn(columnId);
    await DatabaseService.updateBoard(updatedBoard);

    setData(prev => ({
      ...prev,
      boards: { ...prev.boards, [updatedBoard.id]: updatedBoard }
    }));
  };
  
  // --- Gestión de Tarjetas (Tasks) ---
  const handleOpenModal = (taskId, columnId) => {
    const task = taskId ? data.tasks[taskId] : null;
    setModalState({ isOpen: true, task, columnId });
  };
  
  const handleCloseModal = () => {
    setModalState({ isOpen: false, task: null, columnId: null });
  };
  
  const handleSaveTask = async (taskData) => {
    if (!modalState.columnId) return;
    // Es una tarea nueva
    if (!taskData.id) {
      const newTaskId = `task-${Date.now()}`;
      const newTask = { ...taskData, id: newTaskId, columnId: modalState.columnId };
      const column = data.columns[modalState.columnId];
      const updatedColumn = { ...column, taskIds: [...column.taskIds, newTaskId] };

      await Promise.all([
        DatabaseService.createTask(newTask), // IndexedDB
        ApiService.createTask(newTask),      // API
        DatabaseService.updateColumn(updatedColumn)
      ]);

      setData(prev => ({
        ...prev,
        tasks: { ...prev.tasks, [newTaskId]: newTask },
        columns: { ...prev.columns, [updatedColumn.id]: updatedColumn }
      }));
    } else {
      await Promise.all([
        DatabaseService.updateTask(taskData),
        ApiService.updateTask(taskData)
      ]);
      setData(prev => ({
        ...prev,
        tasks: { ...prev.tasks, [taskData.id]: taskData }
      }));
    }
    handleCloseModal();
  };
  
  const deleteTask = async (taskId, columnId) => {
    if (!window.confirm("¿Seguro que quieres eliminar esta tarjeta?")) return;
    const column = data.columns[columnId];
    const updatedColumn = { ...column, taskIds: column.taskIds.filter(id => id !== taskId) };

    await DatabaseService.deleteTask(taskId);
    await DatabaseService.updateColumn(updatedColumn);

    setData(prev => ({
      ...prev,
      columns: { ...prev.columns, [columnId]: updatedColumn }
    }));
  };

  const handleSetActiveBoard = async (boardId) => {
    await DatabaseService.setActiveBoard(boardId);
    setActiveBoardId(boardId);
  };


  return (
    <div className="app-container">
      {modalState.isOpen && (
        <TaskModal
          task={modalState.task}
          users={Object.values(data.users || {})}
          onClose={handleCloseModal}
          onSave={handleSaveTask}
        />
      )}
      <div className="sidebar">
        {/* ... (logo) ... */}
         {Object.values(data.boards).map(board => (
            <div key={board.id} className={`board-button-wrapper ${board.id === activeBoardId ? 'active' : ''}`}>
                 <button className="board-button" onClick={() => setActiveBoardId(board.id)}>
                    {board.title}
                </button>
                <div className="board-actions">
                    <img src={EditIcon} alt="Editar" onClick={() => renameBoard(board.id, prompt('Nuevo nombre del tablero:', board.title))} />
                    <img src={TrashIcon} alt="Eliminar" onClick={() => deleteBoard(board.id)} />
                </div>
            </div>
         ))}
        <button className="add-board-button" onClick={addBoard}>+ Añadir Tablero</button>
        {/* ... (logout) ... */}
      </div>

      <div className="main-content">
        <header className="main-header">
           <div className="header-left">
              <h2>{activeBoard?.title || 'Sin tableros'}</h2>
              <button className="create-list-button" onClick={addList} disabled={!activeBoard}>+ Crear Lista</button>
           </div>
           {/* ... (user-info) ... */}
        </header>
        <DragDropContext onDragEnd={onDragEnd}>
          <Board
            board={activeBoard}
            columns={data.columns}
            tasks={data.tasks}
            openModal={handleOpenModal}
            deleteTask={deleteTask}
            renameList={renameList}
            deleteList={deleteList}
          />
        </DragDropContext>
      </div>
    </div>
  );
}

export default App;