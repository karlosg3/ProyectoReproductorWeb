// src/components/auth/Register.jsx
import React, { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import AuthLayout from './AuthLayout';
import { dbAuthUsers } from '../../db';

const Register = ({ onLoginSuccess }) => {
  const [username, setUsername] = useState('');
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');
  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError('');
    try {
      await dbAuthUsers.register({ username, email, password });
      // Opcional: auto-login después de registrarse
      const user = await dbAuthUsers.login(username, password);
      onLoginSuccess(user);
      navigate('/'); // Redirige al tablero principal
    } catch (err) {
      setError(err.message || 'Error al registrarse.');
    }
  };

  return (
    <AuthLayout>
      <form onSubmit={handleSubmit} className="auth-form">
        <input
          type="text"
          placeholder="Usuario"
          value={username}
          onChange={(e) => setUsername(e.target.value)}
          required
        />
        <input
          type="email"
          placeholder="Correo"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          required
        />
        <input
          type="password"
          placeholder="Contraseña"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
          required
        />
        {error && <p className="auth-error">{error}</p>}
        <div className="auth-actions centered">
            <button type="submit" className="auth-button">Registrarse</button>
        </div>
        <div className="auth-extra-links">
            <Link to="/login" className="auth-link">¿Ya tienes cuenta? Inicia Sesión</Link>
        </div>
      </form>
    </AuthLayout>
  );
};

export default Register;