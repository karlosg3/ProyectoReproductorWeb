// src/components/auth/Login.jsx
/*import React, { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import AuthLayout from './AuthLayout';

export default function Login({ onAuth }) {
  
  const [u, setU] = useState('');
  const [p, setP] = useState('');
  const [msg, setMsg] = useState('');
  const [msgColor, setMsgColor] = useState('black');

  const handle = async (e) => {
    e.preventDefault();

    const res = await onAuth(u.trim(), p.trim());
    
    if (res.ok) {
      setMsg(`✅ Bienvenido ${u}`);
      setMsgColor('green');
    } else {
      setMsg(`❌ ${res.msg || 'Error al iniciar sesión'}`);
      setMsgColor('red');
    }
  };

  return (
    <div className="auth-container">
      <div className="auth-header">
        <h1>INICIAR SESIÓN</h1>
        <p>Bienvenido de vuelta</p>
      </div>

      <div className="auth-form-container">
        <form className="auth-form" onSubmit={handle}>
          <input
            type="text"
            name="username"
            value={u}
            placeholder="Nombre de usuario"
            onChange={(e) => setU(e.target.value)}
            required
          />
          
          <input
            type="password"
            name="password"
            placeholder="Contraseña"
            value={p}
            onChange={(e) => setP(e.target.value)}
          required
          />
          
          <div className="auth-actions">
            <Link to ="registro"  className="auth-link">Registrarse</Link>
            <Link to = "board-page">
                 <button type="submit" className="auth-button">Ingresar</button>
            </Link>
            <p id="auth-msg" style={{ color: msgColor, fontWeight: 'bold' }}>{msg}</p>
       
          </div>
        </form>

        <div className="auth-extra-links">
          <a href="/forgot-password" className="auth-link">¿Olvidaste tu contraseña?</a>
        </div>
      </div>
    </div>
  );
};
*/

// components/auth/Login.jsx
import React, { useState } from 'react';
import '../auth/Login.css'
import { Link, useNavigate } from 'react-router-dom';

const Login = ({ onAuth }) => {
  const [usuario, setUsuario] = useState('');
  const [password, setPassword] = useState('');
  const Navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();
    const resultado = await onAuth(usuario, password);
    if (resultado.ok) {
      Navigate("/board-page")
    }else{
      alert(resultado.msg);
    }
  };

  return (
      <div className='login-form'>
        <h2>INICIAR SESIÓN</h2>
        <p className="subtitle">Bienvenido de vuelta</p>
        <form onSubmit={handleSubmit}>
        <input value={usuario} onChange={(e) => setUsuario(e.target.value)} placeholder="Usuario" />
        <input type="password" value={password} onChange={(e) => setPassword(e.target.value)} placeholder="Contraseña" />
        <button type="submit">Ingresar</button>
        <div className="links">
          <div className="auth-extra-links">
            <a href="/forgot-password" className="auth-link">¿Olvidaste tu contraseña?</a>
          </div>
        </div>
        </form>
      </div>
  );
};

export default Login;