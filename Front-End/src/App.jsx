// src/App.jsx
import React, { useEffect, useState } from 'react';
import { Routes, Route, useNavigate, useLocation, Navigate } from 'react-router-dom';
import Login from './components/auth/Login.jsx';
import Register from './components/auth/Registrar.jsx';
import BoardPage from './pages/BoardPage.jsx';
import AuthLayout from './components/auth/AuthLayout.jsx';
import './App.css';



function App() {
  return (
    <div className="Aplicacion">
      <Routes>
        <Route path="/" element={ <AuthLayout /> } />
        <Route path="board-page" element={ <BoardPage /> } />
        <Route path="login" element={ <Login /> } />
        <Route path="registro" element={ <Register /> } />
      </Routes>
    </div>
  )

}

export default App;