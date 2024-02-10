import React from "react";

interface HamburgerIconProps {
  isOpen: boolean;
}

const HamburgerIcon: React.FC<HamburgerIconProps> = ({ isOpen }) => {
  return (
    <svg
      xmlns="http://www.w3.org/2000/svg"
      viewBox="0 0 24 24"
      width="80%"
      height="80%"
    >
      {isOpen ? (
        <>
          <path fill="none" d="M0 0h24v24H0z" />
          {/* Kryssikon */}
          <path d="M19 6.41L17.59 5 12 10.59 6.41 5 5 6.41 10.59 12 5 17.59 6.41 19 12 13.41 17.59 19 19 17.59 13.41 12z" />
        </>
      ) : (
        <>
          <path fill="none" d="M0 0h24v24H0z" />
          {/* Hamburgarikon */}
          <path d="M4 6h16v2H4zm0 5h16v2H4zm0 5h16v2H4z" />
        </>
      )}
    </svg>
  );
};

export default HamburgerIcon;
