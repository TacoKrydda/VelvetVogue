import React, { useState } from "react";
import { Link } from "react-router-dom";
import SearchBar from "./SearchBar";
import SearchComponent from "../Pages/HomePage/SearchComponent";

const Header = () => {
  const [searchTerm, setSearchTerm] = useState<string>("");
  return (
    <header>
      <div className="head-search">
        {/* <SearchBar /> */}
        <SearchComponent
          searchTerm={searchTerm}
          setSearchTerm={setSearchTerm}
        />
        <div className="hello man">
          <p>
            helloooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo
          </p>
        </div>
      </div>
    </header>
  );
};

export default Header;
