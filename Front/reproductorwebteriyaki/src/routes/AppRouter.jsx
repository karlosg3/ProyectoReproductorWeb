import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import HomePage from '../paginas/HomePage.jsx';
import SearchPage from '../paginas/SearchPage.jsx';
import LibraryPage from '../paginas/LibraryPage.jsx';

const AppRouter = () => {
  return (

      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route path="/search" element={<SearchPage />} />
        <Route path="/library" element={<LibraryPage />} />
      </Routes>

  );
};

export default AppRouter;