// src/components/auth/AuthLayout.jsx
import React from 'react';
import './AuthStyles.css'; // Crearemos este archivo CSS
import Login from './Login';
import { useDispatch } from 'react-redux';
import {
  loginUsuario,
  registroUsuario
} from '../../redux/actions/usuarioActions'

const AuthLayout = () => {
  const dispatch = useDispatch();
  const handleAuth = async (usuario, password) => {
      try {
        let res = await dispatch(loginUsuario({ username: usuario, password: password }));
        if (loginUsuario.rejected.match(res)) {
          res = await dispatch(registroUsuario({ username: usuario, password: password}));
          if (registroUsuario.rejected.match(res)) {
            const msg = res.payload || 'No se pudo registrar el usuario';
            return { ok: false, msg };
          }
        }
        return { ok: true };
        } catch (e) {
          return { ok: false, msg: 'Error inesperado en la autenticación' };
        }
    };


  return (
    <div className="auth-container">
      <div className="auth-header">
        <h1>TERIYAKI</h1>
        <p>Proyectos</p>
      </div>
      <div className="auth-form-container">
      <Login onAuth={handleAuth}/>
      </div>
    </div>
  );
};

export default AuthLayout;