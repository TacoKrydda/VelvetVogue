import React from "react";
import { Link } from "react-router-dom";
import SearchBar from "./SearchBar";

const Header = () => {
  return (
    <header>
      <div className="head-search">
        <SearchBar />
      </div>
    </header>
  );
};

export default Header;
