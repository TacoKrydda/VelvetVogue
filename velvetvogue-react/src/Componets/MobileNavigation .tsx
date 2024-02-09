import { Sidebar } from "primereact/sidebar";
import { Button } from "primereact/button";
import React, { useState } from "react";
import { Link } from "react-router-dom";

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

  const buttonStyle: React.CSSProperties = {
    position: "absolute",
    height: "100%",
    width: "100%",
  };

  return (
    <div>
      <button className="hellothere" onClick={() => setVisible(true)}></button>

      <Sidebar
        visible={visible}
        onHide={() => setVisible(false)}
        className="mobile-sidebar"
      >
        <nav className="mobile-Nav-Content">
          <ul className="mobile-Nav-List">
            <li>
              <Link to="/category/pants">Byxor</Link>
              <button onClick={() => showCategories("Pants", subPants)}>
                More
              </button>
            </li>

            {subPants && (
              <ul className="mobile-Sub-Nav">
                <li>
                  <Link className="mobile-Sub-Link" to="/category/pants/jeans">
                    Jeans
                  </Link>
                </li>
                <li>
                  <Link className="mobile-Sub-Link" to="/category/pants/chinos">
                    Chinos
                  </Link>
                </li>
                <li>
                  <Link
                    className="mobile-Sub-Link"
                    to="/category/pants/kostymbyxor"
                  >
                    Kostymbyxor
                  </Link>
                </li>
                <li>
                  <Link
                    className="mobile-Sub-Link"
                    to="/category/pants/träningsbyxor"
                  >
                    Träningsbyxor
                  </Link>
                </li>
                <li>
                  <Link
                    className="mobile-Sub-Link"
                    to="/category/pants/cargobyxor"
                  >
                    Cargobyxor
                  </Link>
                </li>
              </ul>
            )}

            <li>
              <Link to="/category/shirts">Shirts</Link>
              <button onClick={() => showCategories("Shirts", subShirts)}>
                More
              </button>
            </li>

            {subShirts && (
              <ul className="mobile-Sub-Nav">
                <li>
                  <Link
                    className="mobile-Sub-Link"
                    to="/category/shirts/t-shirts"
                  >
                    T-shirts
                  </Link>
                </li>
                <li>
                  <Link
                    className="mobile-Sub-Link"
                    to="/category/shirts/skjortor"
                  >
                    Skjortor
                  </Link>
                </li>
                <li>
                  <Link
                    className="mobile-Sub-Link"
                    to="/category/shirts/hoodies"
                  >
                    Hoodies
                  </Link>
                </li>
                <li>
                  <Link
                    className="mobile-Sub-Link"
                    to="/category/shirts/polotröjor"
                  >
                    Polotröjor
                  </Link>
                </li>
              </ul>
            )}
          </ul>
        </nav>
      </Sidebar>
      {/* <Button
        style={buttonStyle}
        icon="pi pi-search"
        severity="success"
        aria-label="Search"
        onClick={() => setVisible(true)}
      /> */}
    </div>
  );
};

export default MobileNavigation;
