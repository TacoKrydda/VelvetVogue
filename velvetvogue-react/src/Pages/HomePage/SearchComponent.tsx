import React from "react";

interface SearchProps {
  searchTerm: string;
  setSearchTerm: (term: string) => void;
}

const SearchComponent: React.FC<SearchProps> = ({
  searchTerm,
  setSearchTerm,
}) => {
  return (
    <div>
      <input
        type="text"
        placeholder="Sök efter produkter..."
        value={searchTerm}
        onChange={(e) => setSearchTerm(e.target.value)}
        className="Search-input"
      />
      <button className="Search-button">Sök</button>
    </div>
  );
};

export default SearchComponent;
