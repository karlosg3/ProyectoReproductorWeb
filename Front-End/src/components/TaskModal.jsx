// src/components/TaskModal.jsx
import React, { useState, useEffect } from 'react';

const TaskModal = ({ task, users = [], onClose, onSave }) => {
  const [formData, setFormData] = useState({
    id: null,
    name: '',
    creditType: 'Crédito Simple',
    interestRate: '',
    creditAmount: '',
    description: '',
    assignedTo: []
  });

  useEffect(() => {
    if (task) {
      setFormData({ ...task });
    }
  }, [task]);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData(prev => ({ ...prev, [name]: value }));
  };

  const handleUserAssignment = (userId) => {
    setFormData(prev => {
        const newAssignedTo = prev.assignedTo.includes(userId)
            ? prev.assignedTo.filter(id => id !== userId)
            : [...prev.assignedTo, userId];
        return { ...prev, assignedTo: newAssignedTo };
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    onSave(formData);
  };

  return (
    <div className="modal-backdrop" onClick={onClose}>
      <div className="modal-content" onClick={e => e.stopPropagation()}>
        <form onSubmit={handleSubmit}>
          <input
            type="text"
            name="name"
            value={formData.name}
            onChange={handleChange}
            placeholder="Nombre del Prospecto"
            className="modal-title-input"
            required
          />
          <div className="modal-body">
            <div className="modal-left">
              <label>Tipo de Crédito</label>
              <input type="text" name="creditType" value={formData.creditType} onChange={handleChange} />
              
              <label>Tasa de Interés</label>
              <input type="text" name="interestRate" value={formData.interestRate} onChange={handleChange} placeholder="Ej: 14.5%" />

              <label>Monto Financiero</label>
              <input type="text" name="creditAmount" value={formData.creditAmount} onChange={handleChange} placeholder="Ej: 1,000,000.00" />
              
              <label>Comentarios / Descripción</label>
              <textarea name="description" value={formData.description} onChange={handleChange}></textarea>
            </div>
            <div className="modal-right">
              <div className="user-assignment-list">
                {(users || []).map(user => (
                  <div 
                    key={user.id} 
                    className={`user-assignment-item ${formData.assignedTo.includes(user.id) ? 'assigned' : ''}`}
                    onClick={() => handleUserAssignment(user.id)}
                  >
                    <div className="user-avatar" style={{ backgroundColor: user.avatarColor }}></div>
                    <span>{user.name}</span>
                    {formData.assignedTo.includes(user.id) && <div className="checkmark">✓</div>}
                  </div>
                ))}
              </div>
            </div>
          </div>
          <div className="modal-footer">
            <button type="button" className="modal-button secondary" onClick={onClose}>Cerrar</button>
            <button type="submit" className="modal-button primary">Guardar Prospecto</button>
          </div>
        </form>
      </div>
    </div>
  );
};

export default TaskModal;