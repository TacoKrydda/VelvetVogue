import React from "react";
import style from "./HomePage.module.css";

interface CartItem {
  id: number;
  name: string;
  price: number;
  imageUrl: string;
  quantity: number;
}

interface CartItemProps {
  item: CartItem;
}

const CartItemComponent: React.FC<CartItemProps> = ({ item }) => {
  return (
    <div className={style.cartItem}>
      <img
        src={item.imageUrl}
        alt={item.name}
        className={style.cartItemImage}
      />
      <div className={style.cartItemDetails}>
        <p>{item.name}</p>
        <p>Antal: {item.quantity}</p>
        <p>Totalt: {item.price * item.quantity} kr</p>
      </div>
    </div>
  );
};

export default CartItemComponent;
