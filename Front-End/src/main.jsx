import React from 'react';
import { createRoot } from 'react-dom/client';
import { BrowserRouter } from 'react-router-dom';
import { Provider } from 'react-redux'; // ✅ Importa el Provider de Redux
import App from './App';
import './App.css';
import reportWebVitals from './reportWebVitals';
import store from './redux/store'; // ✅ Importa tu store

const container = document.getElementById('root');
const root = createRoot(container);

root.render(
  <React.StrictMode>
    <Provider store={store}> {/* ✅ Aquí envuelves toda la app */}
      <BrowserRouter>
        <App />
      </BrowserRouter>
    </Provider>
  </React.StrictMode>
);

reportWebVitals();