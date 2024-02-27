import React, { useEffect, useState } from "react";
import {
  ProductProps,
  BrandProps,
  CategoryProps,
  ColorProps,
  SizeProps,
} from "../../../Data/EntityProps";

const ProductPost = () => {
  const [brands, setBrands] = useState<BrandProps[]>([]);
  const [categories, setCategories] = useState<CategoryProps[]>([]);
  const [colors, setColors] = useState<ColorProps[]>([]);
  const [sizes, setSizes] = useState<SizeProps[]>([]);

  const [formData, setFormData] = useState<ProductProps>({} as ProductProps);

  useEffect(() => {
    const fetchData = async (url: string, setter: Function) => {
      try {
        const response = await fetch(url);
        if (response.ok) {
          const data = await response.json();
          setter(data);
        } else {
          console.error(
            `Kunde inte hämta data från ${url}:`,
            response.statusText
          );
        }
      } catch (error) {
        console.error(`Fel vid hämtning av data från ${url}:`, error);
      }
    };

    fetchData("https://localhost:7221/api/Brands", setBrands);
    fetchData("https://localhost:7221/api/Categories", setCategories);
    fetchData("https://localhost:7221/api/Colors", setColors);
    fetchData("https://localhost:7221/api/Sizes", setSizes);
  }, []);

  const capitalizeFirstLetter = (str: string): string => {
    return str.replace(/\b\w/g, (char) => char.toUpperCase());
  };
  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    var processedValue = value;

    processedValue = capitalizeFirstLetter(value);

    setFormData({
      ...formData,
      [name]: processedValue,
    });
  };

  const handleSelectChange = (
    e: React.ChangeEvent<HTMLSelectElement>,
    field: string
  ) => {
    const { value } = e.target;
    setFormData({
      ...formData,
      [field]: parseInt(value), // Converting to number since IDs are usually numbers
    });
  };

  console.log(formData);

  const handleSubmit = async () => {
    try {
      let url = `https://localhost:7221/api/Products`;
      const response = await fetch(url, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(formData),
      });

      if (response.ok) {
        const data = await response.json();
        console.log("Data från servern:", data);
      } else {
        console.error("Serverfel:", response.statusText);
      }
    } catch (error) {
      console.error("Fel vid POST-förfrågan:", error);
    }
  };

  return (
    <div>
      <form>
        <label>Product Name:</label>
        <input
          type="text"
          id="name"
          name="name"
          onChange={handleInputChange}
          required
        />
        <label>Brand:</label>
        <select
          value={formData?.brandId}
          onChange={(e) => handleSelectChange(e, "brandId")}
        >
          <option value={0}>Select Brand</option>
          {brands.map((brand) => (
            <option key={brand.id} value={brand.id}>
              {brand.name}
            </option>
          ))}
        </select>
        <label>Category:</label>
        <select
          value={formData.categoryId}
          onChange={(e) => handleSelectChange(e, "categoryId")}
        >
          <option value={0}>Select Category</option>
          {categories.map((category) => (
            <option key={category.id} value={category.id}>
              {category.name}
            </option>
          ))}
        </select>
        <label>Color:</label>
        <select
          value={formData.colorId}
          onChange={(e) => handleSelectChange(e, "colorId")}
        >
          <option value={0}>Select Color</option>
          {colors.map((color) => (
            <option key={color.id} value={color.id}>
              {color.name}
            </option>
          ))}
        </select>
        <label>Size:</label>
        <select
          value={formData.sizeId}
          onChange={(e) => handleSelectChange(e, "sizeId")}
        >
          <option value={0}>Select Size</option>
          {sizes.map((size) => (
            <option key={size.id} value={size.id}>
              {size.name}
            </option>
          ))}
        </select>
        <label>Price:</label>
        <input
          type="number"
          id="price"
          name="price"
          value={formData.price}
          onChange={handleInputChange}
          required
        />
      </form>
      <div>
        <button onClick={() => handleSubmit()}>Submit</button>
      </div>
    </div>
  );
};

export default ProductPost;
