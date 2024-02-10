import { Sidebar } from "primereact/sidebar";
import React, { useState } from "react";
import { Link } from "react-router-dom";
import HamburgerIcon from "./HamburgerIcon";
import ShowMoreLessIcon from "./ShowMoreLessIcon";

const MobileNavigation = () => {
  const [visible, setVisible] = useState(false);

  const [subPants, setSubPants] = useState(false);
  const [subShirts, setSubShirts] = useState(false);

  const showCategories = (category: string, show: boolean) => {
    switch (category) {
      case "Pants":
        setSubPants(!subPants);
        setSubShirts(false);
        break;
      case "Shirts":
        setSubShirts(!subShirts);
        setSubPants(false);
        break;
      default:
        break;
    }
  };

  return (
    <>
      <button
        className="mobile-sidebar-btn"
        onClick={() => setVisible(!visible)}
      >
        <HamburgerIcon isOpen={visible} />
      </button>
      {visible && (
        <div className="mobile-sidebar">
          <nav className="navigation-nav">
            <ul className="navigation-ul">
              <li className="navigation-li">
                <Link className="navigation-a-p" to="/category/pants">
                  Byxor
                </Link>
                <button
                  className="navigation-btn"
                  onClick={() => showCategories("Pants", subPants)}
                >
                  <ShowMoreLessIcon showMore={!subPants} />
                </button>
              </li>

              {subPants && (
                <ul className="navigation-sub-ul">
                  <li className="navigation-li">
                    <Link className="navigation-a-c" to="/category/pants/jeans">
                      Jeans
                    </Link>
                  </li>
                  <li className="navigation-li">
                    <Link
                      className="navigation-a-c"
                      to="/category/pants/chinos"
                    >
                      Chinos
                    </Link>
                  </li>
                </ul>
              )}

              <li className="navigation-li">
                <Link className="navigation-a-p" to="/category/shirts">
                  Shirts
                </Link>
                <button
                  className="navigation-btn"
                  onClick={() => showCategories("Shirts", subShirts)}
                >
                  <ShowMoreLessIcon showMore={!subShirts} />
                </button>
              </li>

              {subShirts && (
                <ul className="navigation-sub-ul">
                  <li className="navigation-li">
                    <Link
                      className="navigation-a-c"
                      to="/category/shirts/t-shirts"
                    >
                      T-shirts
                    </Link>
                  </li>
                  <li className="navigation-li">
                    <Link
                      className="navigation-a-c"
                      to="/category/shirts/skjortor"
                    >
                      Skjortor
                    </Link>
                  </li>
                </ul>
              )}
            </ul>
          </nav>
        </div>
      )}
    </>
  );
};

export default MobileNavigation;
