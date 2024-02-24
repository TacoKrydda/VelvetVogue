import React, { useEffect, useState } from "react";
import { BrandProps, CategoryProps } from "../../Data/EntityProps";

const PostEntity = () => {
  const [formType, setFormType] = useState<"brand" | "category">("brand");
  const [formData, setFormData] = useState<any>({});

  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value,
    });
  };

  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    console.log("Form Data:", formData);
    if (formType === "brand") {
      postData("Brands");
    } else if (formType === "category") {
      postData("Categories");
    }
  };

  const postData = async (entityType: string) => {
    try {
      let url = `https://localhost:7221/api/${entityType}`;
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
      <h2>Post Entity</h2>
      <form onSubmit={handleSubmit}>
        {formType === "brand" && (
          <>
            <label htmlFor="brandName">Brand Name:</label>
            <input
              type="text"
              id="name"
              name="name"
              onChange={handleInputChange}
            />
          </>
        )}
        <button type="submit">Submit</button>
      </form>

      <div>
        <button onClick={() => setFormType("brand")}>Brand</button>
      </div>
    </div>
  );
};

export default PostEntity;
