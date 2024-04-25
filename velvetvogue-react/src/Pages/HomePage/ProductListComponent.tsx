import React from "react";
import style from "./HomePage.module.css";

interface Product {
  id: number;
  name: string;
  price: number;
  imageUrl: string;
}

interface ProductListProps {
  products: Product[];
  addToCart: (product: Product) => void;
}

const ProductListComponent: React.FC<ProductListProps> = ({
  products,
  addToCart,
}) => {
  return (
    <div className={style.products}>
      {products.map((product) => (
        <div key={product.id} className={style.product}>
          <img src={product.imageUrl} alt={product.name} />
          <h3>{product.name}</h3>
          <p>Pris: {product.price} kr</p>
          <button onClick={() => addToCart(product)}>
            Lägg till i varukorg
          </button>
        </div>
      ))}
    </div>
  );
};

export default ProductListComponent;
