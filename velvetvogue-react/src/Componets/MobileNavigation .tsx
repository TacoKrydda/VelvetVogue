import { Sidebar } from "primereact/sidebar";
import { Button } from "primereact/button";
import React, { useState } from "react";

const MobileNavigation = () => {
  const [visible, setVisible] = useState(false);

  return (
    <div>
      <Sidebar
        visible={visible}
        onHide={() => setVisible(false)}
        className="mobile-sidebar"
      >
        <h2>Sidebar</h2>
        <p>
          Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do
          eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad
          minim veniam, quis nostrud exercitation ullamco laboris nisi ut
          aliquip ex ea commodo consequat.
        </p>
      </Sidebar>
      <Button icon="pi pi-arrow-right" onClick={() => setVisible(true)} />
    </div>
  );
};

export default MobileNavigation;
