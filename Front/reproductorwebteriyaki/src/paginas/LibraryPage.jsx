import React, { useState, useEffect } from 'react';
import Sidebar from '../componentes/layout/Sidebar';
import Footer from '../componentes/comunes/Footer';
import '../paginas/estilos/HomePage.css';

const LibraryPage = () => {
  const [isMobile, setIsMobile] = useState(window.innerWidth < 768);
  const [menuOpen, setMenuOpen] = useState(!isMobile);

  useEffect(() => {
    const handleResize = () => {
      const mobile = window.innerWidth < 768;
      setIsMobile(mobile);
      if (!mobile) setMenuOpen(true);
    };

    window.addEventListener('resize', handleResize);
    return () => window.removeEventListener('resize', handleResize);
  }, []);

  return (
    <div className="home-wrapper" style={{ display: 'flex' }}>
      <Sidebar isOpen={menuOpen} />
      <div
        className="main-content"
        style={{
          marginLeft: menuOpen && !isMobile ? '220px' : '0',
          transition: 'margin-left 0.3s ease-in-out',
          flex: 1
        }}
      >
        <div className="navbar">
          <h1>Tu Biblioteca</h1>
        </div>
        <div className="home-container">
          <p>Aquí se mostrará la música guardada, tus playlists y artistas favoritos.</p>
          {/* Aquí puedes agregar componentes como LibraryGrid, PlaylistCard, etc. */}
          <Footer />
        </div>
      </div>
    </div>
  );
};

export default LibraryPage;