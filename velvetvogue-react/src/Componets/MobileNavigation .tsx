import { Sidebar } from "primereact/sidebar";
import { Button } from "primereact/button";
import React, { useState } from "react";
import { Link } from "react-router-dom";

const MobileNavigation = () => {
  const [visible, setVisible] = useState(false);

  const buttonStyle: React.CSSProperties = {
    position: "absolute",
    height: "100%",
    width: "100%",
  };

  return (
    <div>
      <Sidebar
        visible={visible}
        onHide={() => setVisible(false)}
        className="mobile-sidebar"
      >
        <nav className="mobile-Nav-Content">
          <ul className="mobile-Nav-List">
            <li>
              <Link to="/category/pants">Byxor</Link>
              <ul className="mobile-Sub-Nav">
                <li>
                  <Link className="mobile-Sub-Link" to="/category/pants/jeans">
                    Jeans
                  </Link>
                </li>
              </ul>
            </li>
          </ul>
        </nav>
      </Sidebar>
      <Button
        style={buttonStyle}
        icon="pi pi-search"
        severity="success"
        aria-label="Search"
        onClick={() => setVisible(true)}
      />
    </div>
  );
};

export default MobileNavigation;
