// src/App.jsx
import React, { useState } from 'react';
import initialData from './initial-data';
import Board from './components/Board';
import TaskModal from './components/TaskModal';
import { DragDropContext } from '@hello-pangea/dnd';
import './App.css';
import EditIcon from './assets/edit.svg';
import TrashIcon from './assets/trash.svg';

function boardPage() {
    const [data, setData] = useState(initialData);
    const [activeBoardId, setActiveBoardId] = useState(data.activeBoardId);
    const [modalState, setModalState] = useState({ isOpen: false, task: null, columnId: null });

    const activeBoard = data.boards[activeBoardId];

    // Lógica de Drag and Drop
    const onDragEnd = (result) => {
        const { destination, source, draggableId, type } = result;
        if (!destination) return;
        if (destination.droppableId === source.droppableId && destination.index === source.index) return;

        // Reordenar columnas
        if (type === 'column') {
            const newColumnOrder = Array.from(activeBoard.columnOrder);
            newColumnOrder.splice(source.index, 1);
            newColumnOrder.splice(destination.index, 0, draggableId);

            const newBoard = { ...activeBoard, columnOrder: newColumnOrder };
            setData(prev => ({ ...prev, boards: { ...prev.boards, [newBoard.id]: newBoard } }));
            return;
        }

        // Reordenar tarjetas
        const start = data.columns[source.droppableId];
        const finish = data.columns[destination.droppableId];

        if (start === finish) {
            const newTaskIds = Array.from(start.taskIds);
            newTaskIds.splice(source.index, 1);
            newTaskIds.splice(destination.index, 0, draggableId);
            const newColumn = { ...start, taskIds: newTaskIds };
            setData(prev => ({ ...prev, columns: { ...prev.columns, [newColumn.id]: newColumn } }));
            return;
        }

        const startTaskIds = Array.from(start.taskIds);
        startTaskIds.splice(source.index, 1);
        const newStart = { ...start, taskIds: startTaskIds };

        const finishTaskIds = Array.from(finish.taskIds);
        finishTaskIds.splice(destination.index, 0, draggableId);
        const newFinish = { ...finish, taskIds: finishTaskIds };

        setData(prev => ({ ...prev, columns: { ...prev.columns, [newStart.id]: newStart, [newFinish.id]: newFinish } }));
    };

    // --- Gestión de Boards ---
    const addBoard = () => {
        const boardName = prompt("Ingresa el nombre del nuevo tablero:");
        if (!boardName) return;
        const newBoardId = `board-${Date.now()}`;
        const newBoard = { id: newBoardId, title: boardName, columnOrder: [] };
        setData(prev => ({ ...prev, boards: { ...prev.boards, [newBoardId]: newBoard } }));
        setActiveBoardId(newBoardId);
    };

    const renameBoard = (boardId, newName) => {
        if (!newName) return;
        setData(prev => ({ ...prev, boards: { ...prev.boards, [boardId]: { ...prev.boards[boardId], title: newName } } }));
    };

    const deleteBoard = (boardId) => {
        if (!window.confirm("¿Seguro que quieres eliminar este tablero y todas sus listas?")) return;
        setData(prev => {
            const newBoards = { ...prev.boards };
            delete newBoards[boardId];
            const newActiveBoardId = Object.keys(newBoards)[0] || null;
            setActiveBoardId(newActiveBoardId);
            return { ...prev, boards: newBoards };
        });
    };

    // --- Gestión de Listas (Columnas) ---
    const addList = () => {
        const listName = prompt("Ingresa el nombre de la nueva lista:");
        if (!listName) return;
        const newColumnId = `column-${Date.now()}`;
        const newColumn = { id: newColumnId, title: listName, taskIds: [] };
        const newBoard = { ...activeBoard, columnOrder: [...activeBoard.columnOrder, newColumnId] };
        setData(prev => ({
            ...prev,
            columns: { ...prev.columns, [newColumnId]: newColumn },
            boards: { ...prev.boards, [newBoard.id]: newBoard }
        }));
    };

    const renameList = (columnId, newName) => {
        if (!newName) return;
        setData(prev => ({ ...prev, columns: { ...prev.columns, [columnId]: { ...prev.columns[columnId], title: newName } } }));
    };

    const deleteList = (columnId) => {
        if (!window.confirm("¿Seguro que quieres eliminar esta lista?")) return;
        const newColumnOrder = activeBoard.columnOrder.filter(id => id !== columnId);
        const newBoard = { ...activeBoard, columnOrder: newColumnOrder };
        setData(prev => ({ ...prev, boards: { ...prev.boards, [newBoard.id]: newBoard } }));
    };

    // --- Gestión de Tarjetas (Tasks) ---
    const handleOpenModal = (taskId, columnId) => {
        const task = taskId ? data.tasks[taskId] : null;
        setModalState({ isOpen: true, task, columnId });
    };

    const handleCloseModal = () => {
        setModalState({ isOpen: false, task: null, columnId: null });
    };

    const handleSaveTask = (taskData) => {
        // Es una tarea nueva
        if (!taskData.id) {
            const newTaskId = `task-${Date.now()}`;
            const newTask = { ...taskData, id: newTaskId };
            const column = data.columns[modalState.columnId];
            const newTaskIds = [...column.taskIds, newTaskId];

            setData(prev => ({
                ...prev,
                tasks: { ...prev.tasks, [newTaskId]: newTask },
                columns: { ...prev.columns, [column.id]: { ...column, taskIds: newTaskIds } }
            }));
        } else { // Es una actualización
            setData(prev => ({
                ...prev,
                tasks: { ...prev.tasks, [taskData.id]: taskData }
            }));
        }
        handleCloseModal();
    };

    const deleteTask = (taskId, columnId) => {
        if (!window.confirm("¿Seguro que quieres eliminar esta tarjeta?")) return;
        const column = data.columns[columnId];
        const newTaskIds = column.taskIds.filter(id => id !== taskId);
        setData(prev => ({
            ...prev,
            columns: { ...prev.columns, [columnId]: { ...column, taskIds: newTaskIds } }
        }));
    };

    return (
        <div className="app-container">
            <div className="header-principal">
                <div className="header-left">
                    <img src="/logo.png" alt="Logo" className="logo-header" />
                </div>

                <div className="header-right">
                    <div className="user-info">
                        <div className="user-avatar"></div>
                        <span className="user-name">Juan Pérez</span>
                        <button className="logout-button-header">Cerrar sesión</button>
                    </div>
                </div>
            </div>
            {modalState.isOpen && (
                <TaskModal
                    task={modalState.task}
                    users={data.users}
                    onClose={handleCloseModal}
                    onSave={handleSaveTask}
                />
            )}
            <div className='content-row'>
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
        </div>
    );
}

export default boardPage;