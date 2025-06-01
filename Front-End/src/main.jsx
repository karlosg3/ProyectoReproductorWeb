// src/main.jsx

import React from 'react';
import ReactDOM from 'react-dom/client';
import { BrowserRouter } from 'react-dom/client';
import App from './App.jsx';
import './App.css'; // Importando los estilos globales
import reportWebVitals from './reportWebVitals';

// Encuentra el elemento root en tu HTML y renderiza el componente App dentro de él.
ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
    <BrowserRouter>
      <App />
    </BrowserRouter>
  </React.StrictMode>
);

reportWebVitals();