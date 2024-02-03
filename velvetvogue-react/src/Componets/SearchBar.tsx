import React from "react";

const SearchBar = () => {
  return (
    <div className="Search-container">
      <input type="text" placeholder="Sök..." className="Search-input" />
      <button className="Search-button">Sök</button>
    </div>
  );
};

export default SearchBar;
