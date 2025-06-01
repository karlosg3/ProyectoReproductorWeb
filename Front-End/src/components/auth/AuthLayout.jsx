// src/components/auth/AuthLayout.jsx
import React from 'react';
import './AuthStyles.css'; // Crearemos este archivo CSS

const AuthLayout = ({ children }) => {
  return (
    <div className="auth-container">
      <div className="auth-header">
        <h1>TERIYAKI</h1>
        <p>Proyectos</p>
      </div>
      <div className="auth-form-container">
        {children}
      </div>
    </div>
  );
};

export default AuthLayout;