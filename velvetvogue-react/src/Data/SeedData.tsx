import React, { useEffect, useState } from "react";

type DataProps = {
  id: number;
  productName: string;
};

const SeedData = () => {
  const seedData: DataProps[] = [
    { id: 1, productName: "Produkt 1" },
    { id: 2, productName: "Produkt 2" },
    { id: 3, productName: "Produkt 3" },
    { id: 4, productName: "Produkt 4" },
    { id: 5, productName: "Produkt 5" },
  ];

  const [data, setData] = useState<DataProps[]>([]);

  useEffect(() => {
    setData(seedData);
  }, []);
  return (
    <div>
      <h1>Seeddata</h1>
      <ul>
        {data.map((item) => (
          <li key={item.id}>{item.productName}</li>
        ))}
      </ul>
    </div>
  );
};

export default SeedData;
