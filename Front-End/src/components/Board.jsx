// src/components/Board.jsx
import React from 'react';
import Column from './Column';
import { Droppable } from '@hello-pangea/dnd';

const Board = ({ board, columns, tasks, openModal, deleteTask, renameList, deleteList }) => {
  if (!board) {
    return <div className="board-container empty"><h2>Selecciona o crea un tablero.</h2></div>;
  }
  
  return (
    <Droppable droppableId="all-columns" direction="horizontal" type="column">
      {(provided) => (
        <div className="board-container" {...provided.droppableProps} ref={provided.innerRef}>
          {board.columnOrder.map((columnId, index) => {
            const column = columns[columnId];
            const columnTasks = column.taskIds.map(taskId => tasks[taskId]);
            return (
              <Column
                key={column.id}
                column={column}
                tasks={columnTasks}
                index={index}
                openModal={openModal}
                deleteTask={deleteTask}
                renameList={renameList}
                deleteList={deleteList}
              />
            );
          })}
          {provided.placeholder}
        </div>
      )}
    </Droppable>
  );
};

export default Board;