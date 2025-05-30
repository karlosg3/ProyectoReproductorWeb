import React from 'react';
import './Comunes.css';

const Boton = ({ children, onClick, tipo = 'primary', disabled = false }) => {
  return (
    <button
      className={`boton boton-${tipo}`}
      onClick={onClick}
      disabled={disabled}
    >
      {children}
    </button>
  );
};

export default Boton;