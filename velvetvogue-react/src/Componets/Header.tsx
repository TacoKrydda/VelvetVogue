import React from "react";
import { Link } from "react-router-dom";
import SearchBar from "./SearchBar";

const Header = () => {
  return (
    <header>
      <div className="head-search">
        <SearchBar />
      </div>
      {/* <nav>
        <ul className="head-list">
          <li>
            <Link to="/">Hem</Link>
          </li>
          <li>
            <Link to="/about">Om oss</Link>
          </li>
          <li>
            <Link to="/contact">Kontakt</Link>
          </li>
        </ul>
      </nav> */}
    </header>
  );
};

export default Header;
