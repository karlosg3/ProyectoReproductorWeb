import React from 'react';
import { Link } from 'react-router-dom';
import './NavbarSideBar.css';


const Sidebar = ({ isOpen, onToggle }) => (


  
  <aside className={`sidebar ${isOpen ? 'open' : 'closed'}`}>
    <button className="menu-toggle sidebar-toggle" onClick={onToggle}>
      ☰
    </button>
    <ul>
      <li><Link to="/">Inicio</Link></li>
      <li><Link to="/search">Buscar</Link></li>
      <li><Link to="/library">Tu biblioteca</Link></li>
    </ul>
  </aside>
);

export default Sidebar;