import React, { useState, useEffect } from 'react';
import HeroBanner from '../features/home/HeroBanner.jsx';
import RecommendedSection from '../features/home/RecommendedSection.jsx';
import PlaylistGrid from '../features/home/PlaylistGrid.jsx';
import Navbar from '../componentes/layout/Navbar.jsx';
import Sidebar from '../componentes/layout/Sidebar.jsx';
import Footer from '../componentes/comunes/Footer.jsx';
import Header from '../componentes/comunes/Header.jsx';
import '../features/home/Home.css';
import './estilos/HomePage.css';


const HomePage = () => {
  const [isMobile, setIsMobile] = useState(window.innerWidth < 768);
  const [menuOpen, setMenuOpen] = useState(false);

  useEffect(() => {
    const handleResize = () => {
      setIsMobile(window.innerWidth < 768);
      if (window.innerWidth >= 768) {
        setMenuOpen(true); // Mantener abierto en escritorio
      }
    };

    window.addEventListener('resize', handleResize);

    // Inicial
    if (window.innerWidth >= 768) {
      setMenuOpen(true);
    }

    return () => window.removeEventListener('resize', handleResize);
  }, []);

  const toggleMenu = () => {
    setMenuOpen((prev) => !prev);
  };

  return (
    <div className="home-wrapper">
      <Sidebar isOpen={menuOpen} onToggle={toggleMenu} />
      <div className={`main-content ${menuOpen ? 'sidebar-open' : ''}`}>
       <Header/>
        <div className="home-container">
          <HeroBanner />
          <RecommendedSection />
          <PlaylistGrid />
          <Footer />
        </div>
      </div>
    </div>
  );
};

export default HomePage;

