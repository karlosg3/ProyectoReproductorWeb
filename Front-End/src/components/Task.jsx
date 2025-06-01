// src/components/Task.jsx
import React from 'react';
import { Draggable } from '@hello-pangea/dnd';
import TrashIcon from '../assets/trash.svg';

const Task = ({ task, index, columnId, openModal, deleteTask }) => {
  return (
    <Draggable draggableId={task.id} index={index}>
      {(provided, snapshot) => (
        <div
          className={`task-card ${snapshot.isDragging ? 'dragging' : ''}`}
          {...provided.draggableProps}
          {...provided.dragHandleProps}
          ref={provided.innerRef}
          onClick={() => openModal(task.id, columnId)}
        >
          <div className="task-header">
            <h4>{task.name}</h4>
            <img 
              src={TrashIcon} 
              alt="Eliminar" 
              className="delete-task-icon" 
              onClick={(e) => {
                e.stopPropagation(); // Evita que se abra el modal al hacer clic en el icono
                deleteTask(task.id, columnId);
              }}
            />
          </div>
          <p className="task-amount">$ {task.creditAmount}</p>
        </div>
      )}
    </Draggable>
  );
};

export default Task;