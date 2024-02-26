import React, { useState } from "react";
import BrandPost from "./Brand/BrandPost";
import CategoryPost from "./Category/CategoryPost";
import ColorPost from "./Color/ColorPost";
import { SizePost } from "./Size/SizePost";

const PostEntity = () => {
  const [selectedComponent, setSelectedComponent] = useState("BrandPost");

  const renderComponent = () => {
    switch (selectedComponent) {
      case "BrandPost":
        return <BrandPost />;
      case "Category":
        return <CategoryPost />;
      case "Color":
        return <ColorPost />;
      case "Size":
        return <SizePost />;
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
        <option value="Size">Size</option>
      </select>
      {renderComponent()}
    </div>
  );
};

export default PostEntity;
