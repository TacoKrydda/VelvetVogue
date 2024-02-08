import React, { useState } from "react";

interface SubCategory {
  name: string;
}

interface Category {
  name: string;
  subCategories: SubCategory[];
}

const DesktopNavigation: React.FC = () => {
  const [categories, setCategories] = useState<Category[]>([
    {
      name: "Byxor",
      subCategories: [{ name: "Jeans" }, { name: "Chinos" }],
    },
    {
      name: "Tröjor",
      subCategories: [{ name: "Hoodies" }, { name: "T-Shirt" }],
    },
    // Lägg till fler kategorier och underkategorier här vid behov
  ]);

  const [activeCategory, setActiveCategory] = useState<string | null>(null);

  const toggleSubCategories = (categoryName: string) => {
    setActiveCategory(activeCategory === categoryName ? null : categoryName);
  };

  return (
    <div className="desktop-sidebar">
      <ul>
        {categories.map((category) => (
          <li key={category.name}>
            <button onClick={() => toggleSubCategories(category.name)}>
              {category.name}
            </button>
            {activeCategory === category.name && (
              <ul>
                {category.subCategories.map((subCategory) => (
                  <li key={subCategory.name}>{subCategory.name}</li>
                ))}
              </ul>
            )}
          </li>
        ))}
      </ul>
    </div>
  );
};

export default DesktopNavigation;
