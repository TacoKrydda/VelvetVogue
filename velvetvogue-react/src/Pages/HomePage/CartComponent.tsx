import React from "react";
import style from "./HomePage.module.css";

interface CartItem {
  id: number;
  name: string;
  price: number;
  imageUrl: string;
  quantity: number;
}

interface CartProps {
  cart: CartItem[];
  isCartVisible: boolean;
  setIsCartVisible: (isVisible: boolean) => void;
  getTotalPrice: () => number;
}

const CartComponent: React.FC<CartProps> = ({
  cart,
  isCartVisible,
  setIsCartVisible,
  getTotalPrice,
}) => {
  console.log("isCartVisible: ", isCartVisible);
  return (
    <div
      className={`cart ${isCartVisible ? "visible" : ""}`}
      // onMouseEnter={() => setIsCartVisible(true)}
      // onMouseLeave={() => setIsCartVisible(false)}
    >
      <h2>Kundvagn</h2>
      <ul>
        {cart.map((item) => (
          <li key={item.id}>
            <div className="cartItem">
              <img
                src={item.imageUrl}
                alt={item.name}
                className="cartItemImage"
              />
              <div className="cartItemDetails">
                <p>{item.name}</p>
                <p>Antal: {item.quantity}</p>
                <p>Totalt: {item.price * item.quantity} kr</p>
              </div>
            </div>
          </li>
        ))}
      </ul>
      <p>Totalt: {getTotalPrice()} kr</p>
    </div>
  );
};

export default CartComponent;
