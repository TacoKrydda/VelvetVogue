import React, { useState } from "react";
import { BrandProps } from "../../../Data/EntityProps";
import style from "../Brand/CSS/BrandPost.module.css";

const BrandPost = () => {
  const [formData, setFormData] = useState<BrandProps[]>([]);

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

  const handleSubmit = async () => {
    try {
      let url = `https://localhost:7221/api/Brands`;
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

  console.log(formData);
  return (
    <div className={style.bpContainer}>
      <form className={style.bpForm}>
        <div className={style.bpFormGroup}>
          <label htmlFor="name">Brand Name:</label>
          <input
            type="text"
            id="name"
            name="name"
            onChange={handleInputChange}
            required
          />
        </div>
        <div className={style.buttonContainer}>
          <button className={style.bpPostBtn} onClick={() => handleSubmit()}>
            Submit
          </button>
        </div>
      </form>
    </div>
  );
};

export default BrandPost;
