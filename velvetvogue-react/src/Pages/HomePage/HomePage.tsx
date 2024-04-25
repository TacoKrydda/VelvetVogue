import React from "react";
import ProductListComponent from "./ProductListComponent";
import SneakersIcon from "../../Img/sneakers.jpg";
import SneakersIcon2 from "../../Img/sneakers2.jpg";
import SneakersIcon3 from "../../Img/sneakers3.jpg";
import tShirtIcon from "../../Img/t-shirt.jpg";
import jeansIcon from "../../Img/jeans.jpg";
import style from "./HomePage.module.css";

interface Product {
  id: number;
  name: string;
  price: number;
  imageUrl: string;
}

interface CartItem extends Product {
  quantity: number;
}

interface Category {
  id: number;
  name: string;
  subcategories: string[];
}

const products: Product[] = [
  {
    id: 1,
    name: "T-shirt",
    price: 199,
    imageUrl: tShirtIcon,
  },
  {
    id: 2,
    name: "Jeans",
    price: 499,
    imageUrl: jeansIcon,
  },
  {
    id: 3,
    name: "Sneakers",
    price: 299,
    imageUrl: SneakersIcon,
  },
  {
    id: 4,
    name: "Sneakers 2",
    price: 399,
    imageUrl: SneakersIcon2,
  },
  {
    id: 5,
    name: "Sneakers 3",
    price: 499,
    imageUrl: SneakersIcon3,
  },
];

const categories: Category[] = [
  {
    id: 1,
    name: "Kläder",
    subcategories: ["T-shirts", "Jeans", "Sneakers"],
  },
  {
    id: 2,
    name: "Accessoarer",
    subcategories: ["Hattar", "Smycken", "Väskor"],
  },
];

interface HomePageProps {
  searchTerm: string;
  cart: CartItem[];
  setIsCartVisible: (isVisible: boolean) => void;
  setCart: (newCart: CartItem[]) => void;
}

const HomePage: React.FC<HomePageProps> = ({
  searchTerm,
  cart,
  setIsCartVisible,
  setCart,
}) => {
  const addToCart = (product: Product) => {
    const existingItem = cart.find((item) => item.id === product.id);

    if (existingItem) {
      const updatedCart = cart.map((item) =>
        item.id === product.id ? { ...item, quantity: item.quantity + 1 } : item
      );
      setCart(updatedCart);
    } else {
      setCart([...cart, { ...product, quantity: 1 }]);
    }

    setIsCartVisible(true);
    setTimeout(() => {
      setIsCartVisible(false);
    }, 5000);
  };

  const filteredProducts = products.filter((product) =>
    product.name.toLowerCase().includes(searchTerm.toLowerCase())
  );

  return (
    <div className={style.container}>
      <div className={style.content}>
        <h1>Välkommen till vår E-handelssida för kläder!</h1>
        <ProductListComponent
          products={filteredProducts}
          addToCart={addToCart}
        />
      </div>
    </div>
  );
};

export default HomePage;
