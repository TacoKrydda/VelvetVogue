import React from "react";
import CartComponent from "../Pages/HomePage/CartComponent";
import pic from "../Img/shopping-cart-icon.png";

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

const CartContainer: React.FC<CartProps> = ({
  cart,
  isCartVisible,
  setIsCartVisible,
  getTotalPrice,
}) => {
  const handlecartShow = () => {
    setIsCartVisible(!isCartVisible);
  };
  return (
    <div className="cartContainer">
      <button onClick={handlecartShow}>
        <img src={pic} alt="broken" />
        <CartComponent
          cart={cart}
          isCartVisible={isCartVisible}
          setIsCartVisible={setIsCartVisible}
          getTotalPrice={getTotalPrice}
        />
      </button>
    </div>
  );
};

export default CartContainer;
