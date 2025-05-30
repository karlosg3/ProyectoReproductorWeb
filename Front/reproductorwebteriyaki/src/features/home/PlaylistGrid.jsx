import React from 'react';

const PlaylistGrid = () => (
  <div className="playlist-grid">
    <h2>Tus playlists</h2>
    <div className="grid">
      {[1, 2, 3, 4, 5, 6].map((item) => (
        <div key={item} className="playlist-card">
          <div className="cover" />
          <p>Playlist {item}</p>
        </div>
      ))}
    </div>
  </div>
);

export default PlaylistGrid;