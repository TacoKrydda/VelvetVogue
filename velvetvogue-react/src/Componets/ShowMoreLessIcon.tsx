import React from "react";

interface ShowMoreLessIconProps {
  showMore: boolean;
}

const ShowMoreLessIcon: React.FC<ShowMoreLessIconProps> = ({ showMore }) => {
  return (
    <svg
      xmlns="http://www.w3.org/2000/svg"
      viewBox="0 0 24 24"
      width="80%"
      height="80%"
    >
      <path fill="none" d="M0 0h24v24H0z" />
      {showMore ? (
        <>
          <path d="M12 18l6-6H6z" />
        </>
      ) : (
        <>
          <path d="M12 6l-6 6h12z" />
        </>
      )}
    </svg>
  );
};

export default ShowMoreLessIcon;
