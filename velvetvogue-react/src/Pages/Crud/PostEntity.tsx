import React, { useState } from "react";
import BrandPost from "./Brand/BrandPost";
import Category from "./Category/Category";
import Color from "./Color/Color";

const PostEntity = () => {
  const [selectedComponent, setSelectedComponent] = useState("BrandPost");

  const renderComponent = () => {
    switch (selectedComponent) {
      case "BrandPost":
        return <BrandPost />;
      case "Category":
        return <Category />;
      case "Color":
        return <Color />;
      default:
        return null;
    }
  };

  return (
    <div>
      <select
        value={selectedComponent}
        onChange={(e) => setSelectedComponent(e.target.value)}
      >
        <option value="BrandPost">Brand Post</option>
        <option value="Category">Category</option>
        <option value="Color">Color</option>
      </select>
      {renderComponent()}
    </div>
  );
};

export default PostEntity;
