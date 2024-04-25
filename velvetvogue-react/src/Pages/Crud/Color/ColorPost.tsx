import React, { useState } from "react";
import { ColorProps } from "../../../Data/EntityProps";

const ColorPost = () => {
  const [formData, setFormData] = useState<ColorProps[]>([]);

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
      let url = `https://localhost:7221/api/Colors`;
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
        <label>Color Name:</label>
        <input
          type="text"
          id="name"
          name="name"
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

export default ColorPost;
