import React from 'react';
import './Comunes.css';

const SearchBar = ({ value, onChange, placeholder = 'Buscar...' }) => {
  return (
    <input
      type="search"
      className="search-bar"
      value={value}
      onChange={onChange}
      placeholder={placeholder}
      autoComplete="off"
    />
  );
};

export default SearchBar;