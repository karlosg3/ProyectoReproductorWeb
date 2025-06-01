// src/components/auth/Register.jsx
import React, { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import AuthLayout from './AuthLayout';

const Registrar = () => {
  return (
    <div className="auth-container">
      <div className="auth-header">
        <h1>REGISTRARSE</h1>
        <p>Crea una nueva cuenta</p>
      </div>

      <div className="auth-form-container">
        <form className="auth-form">
          <input
            type="text"
            name="firstName"
            placeholder="Nombre"
          />
          
          <input
            type="text"
            name="lastName"
            placeholder="Apellido"
          />
          
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

          <div className="auth-actions centered">
            <Link to = '/'>
              <button type="button" className="auth-button" style={{ marginRight: '20px' }}>
              Regresar
            </button>
            </Link>

                <Link to = '/'>
           <button type="submit" className="auth-button">
              Registrar
            </button>
            </Link>          
           
          </div>
        </form>
      </div>
    </div>
  );
};


export default Registrar;