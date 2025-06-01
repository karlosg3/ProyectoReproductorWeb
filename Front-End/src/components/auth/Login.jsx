// src/components/auth/Login.jsx
import React, { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import AuthLayout from './AuthLayout';

const Login = () => {


  return (
    <div className="auth-container">
      <div className="auth-header">
        <h1>INICIAR SESIÓN</h1>
        <p>Bienvenido de vuelta</p>
      </div>

      <div className="auth-form-container">
        <form className="auth-form">
          <input
            type="text"
            name="username"
            placeholder="Nombre de usuario"
          />
          
          <input
            type="password"
            name="password"
            placeholder="Contraseña"
          />
          
          <div className="auth-actions">
            <Link to ="registro"  className="auth-link">Registrarse</Link>
            <Link to = "board-page">
                 <button type="submit" className="auth-button">Ingresar</button>
            </Link>
       
          </div>
        </form>

        <div className="auth-extra-links">
          <a href="/forgot-password" className="auth-link">¿Olvidaste tu contraseña?</a>
        </div>
      </div>
    </div>
  );
};


export default Login;