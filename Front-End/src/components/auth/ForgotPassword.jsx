import React, { useEffect } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import AuthLayout from './AuthLayout';

function YouTubeEmbed() {
  const videoId = 'xJdbBmN6yhg'; // Reemplaza con el ID del video de YouTube

  useEffect(() => {
    // Esta función se ejecutará después de que el componente se monte
    const iframe = document.getElementById('youtube-iframe');
    if (iframe) {
      iframe.src = `https://www.youtube.com/embed/${videoId}?autoplay=1&mute=0`;
    }
  }, [videoId]);

  return (
    <div>
    <div style={{ position: 'fixed', top: 0, left: 0, width: '100%', height: '100%', overflow: 'hidden', alignContent: 'center', left: '25%' }}>
      <iframe
        id="youtube-iframe"
        width="50%"
        height="50%"
        src="" // La URL se establece en el useEffect
        title="YouTube video player"
        frameBorder="0"
        allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share"
        allowFullScreen
        style={{ border: 'none' }}
      ></iframe>
      <br/>
      <br/>
      <Link to = '/'>
                  <button type="button" className="auth-button" style={{ marginRight: '20px' }}>
                  Regresar
                </button>
                </Link>
    </div>
    
    </div>
  );
}

export default YouTubeEmbed;

