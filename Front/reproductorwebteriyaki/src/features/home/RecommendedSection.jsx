import React from 'react';

const RecommendedSection = () => (
  <div className="recommended-section">
    <h2>Recomendado para ti</h2>
    <div className="recommended-list">
      {[1, 2, 3, 4].map((item) => (
        <div key={item} className="recommended-item">
          <div className="thumb" />
          <p>Álbum {item}</p>
        </div>
      ))}
    </div>
  </div>
);


export default RecommendedSection;