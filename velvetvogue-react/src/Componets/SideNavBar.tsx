import React from "react";
import { Link } from "react-router-dom";

const SideNavBar = () => {
  return (
    <nav className="Nav-list-content">
      <ul className="Nav-list">
        <li>
          <Link to="/category/pants">Byxor</Link>
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
  );
};

export default SideNavBar;
