// src/App.jsx
import React, { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { Routes, Route, useNavigate, useLocation, Navigate } from 'react-router-dom';
import Login from './components/auth/Login.jsx';
import Register from './components/auth/Registrar.jsx';
import BoardPage from './pages/BoardPage.jsx';
import AuthLayout from './components/auth/AuthLayout.jsx';
import YouTubeEmbed from './components/auth/ForgotPassword.jsx';
import { loginUsuario, registerUsuario } from './redux/actions/usuarioActions.js'
import { logoutUsuario } from './redux/slices/usuarioSlice.js';
import './App.css';



function App() {
  const dispatch = useDispatch();
  const user = useSelector((state) => state.user);

  const handleAuth = async (usuario, password) => {
    try {
      let res = await dispatch(loginUsuario({ username: usuario, password: password }));
      if (loginUsuario.rejected.match(res)) {
        res = await dispatch(registerUsuario({ username: usuario, password: password}));
        if (registerUsuario.rejected.match(res)) {
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
    <div className="Aplicacion">
      <Routes>
        <Route path="/" element={<AuthLayout />} />
        <Route path="board-page" element={<BoardPage />} />
        <Route path="login" element={<Login onAuth={handleAuth} />} />
        <Route path="registro" element={<Register />} />
        <Route path="forgot-password" element={<YouTubeEmbed />} />
      </Routes>
    </div>
  )

}

export default App;