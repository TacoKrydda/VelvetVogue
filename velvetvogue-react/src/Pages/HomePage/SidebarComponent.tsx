import React from "react";
import style from "./HomePage.module.css";

interface Category {
  id: number;
  name: string;
  subcategories: string[];
}

interface SidebarProps {
  categories: Category[];
}

const SidebarComponent: React.FC<SidebarProps> = ({ categories }) => {
  return (
    <div className={style.sidebar}>
      <h2>Kategorier</h2>
      <ul>
        {categories.map((category) => (
          <li key={category.id}>
            {category.name}
            <ul>
              {category.subcategories.map((subcategory) => (
                <li key={subcategory}>{subcategory}</li>
              ))}
            </ul>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default SidebarComponent;
