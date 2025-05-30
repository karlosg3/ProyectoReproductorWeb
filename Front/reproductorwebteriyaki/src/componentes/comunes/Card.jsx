import React from 'react';
import './Comunes.css';

const Card = ({ children, onClick }) => {
  return (
    <div className="card" onClick={onClick}>
      {children}
    </div>
  );
};

export default Card;