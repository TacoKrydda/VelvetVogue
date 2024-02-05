import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";

const Navigation: React.FC = () => {
  const [isOpen, setIsOpen] = useState(false);

  const toggleMenu = () => {
    setIsOpen(!isOpen);
  };

  return (
    <>
      <div className="menu-toggle" onClick={toggleMenu}>
        ☰
      </div>
      <div className={`navigation ${isOpen ? "open" : ""}`}>
        <nav className="Nav-list-content">
          <ul className="Nav-list">
            <li>
              <Link to="/">Byxor</Link>
              <ul className="Sub-nav">
                <li>
                  <Link to="/category/pants/jeans">Jeans</Link>
                </li>
                <li>
                  <Link to="/category/pants/chinos">Chinos</Link>
                </li>
                <li>
                  <Link to="/category/pants/tracksuit">Träningsbyxor</Link>
                </li>
              </ul>
            </li>
          </ul>
          <ul className="Nav-list">
            <li>
              <Link to="/category/shirts">Tröjor</Link>
              <ul className="Sub-nav">
                <li>
                  <Link to="/category/shirts/huvtröjor">Huvtröjor</Link>
                </li>
                <li>
                  <Link to="/category/shirts/sweatshirts">Sweatshirts</Link>
                </li>
                <li>
                  <Link to="/category/shirts/fleecetröjor">Fleecetröjor</Link>
                </li>
              </ul>
            </li>
          </ul>
        </nav>
      </div>
    </>
  );
};

export default Navigation;
