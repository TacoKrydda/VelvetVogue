import React from "react";
import { Link } from "react-router-dom";

const Header = () => {
  return (
    <header>
      <nav>
        <ul className="nav-list">
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
      </nav>
    </header>
  );
};

export default Header;
