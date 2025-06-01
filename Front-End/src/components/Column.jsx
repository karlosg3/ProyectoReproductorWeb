// src/components/Column.jsx
import React from 'react';
import Task from './Task';
import { Droppable, Draggable } from '@hello-pangea/dnd';
import EditIcon from '../assets/edit.svg';
import TrashIcon from '../assets/trash.svg';

const Column = ({ column, tasks, index, openModal, deleteTask, renameList, deleteList }) => {
  return (
    <Draggable draggableId={column.id} index={index}>
      {(provided) => (
        <div className="column" {...provided.draggableProps} ref={provided.innerRef}>
          <div className="column-header" {...provided.dragHandleProps}>
            <h3 className="column-title">{column.title}</h3>
            <div className="column-actions">
              <img src={EditIcon} alt="Editar" onClick={() => renameList(column.id, prompt('Nuevo nombre de la lista:', column.title))}/>
              <img src={TrashIcon} alt="Eliminar" onClick={() => deleteList(column.id)}/>
            </div>
          </div>
          <Droppable droppableId={column.id} type="task">
            {(provided, snapshot) => (
              <div
                className={`task-list ${snapshot.isDraggingOver ? 'dragging-over' : ''}`}
                ref={provided.innerRef}
                {...provided.droppableProps}
              >
                {tasks.map((task, index) => (
                  <Task key={task.id} task={task} index={index} columnId={column.id} openModal={openModal} deleteTask={deleteTask} />
                ))}
                {provided.placeholder}
              </div>
            )}
          </Droppable>
          <button className="add-task-button" onClick={() => openModal(null, column.id)}>+ Agregar Prospecto</button>
        </div>
      )}
    </Draggable>
  );
};

export default Column;