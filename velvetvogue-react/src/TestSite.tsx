import React, { useState } from "react";
import "./TestSite.module.css";
import ShoppingCartIcon from "../src/Img/shopping-cart-icon.png";
import SneakersIcon from "../src/Img/sneakers.jpg";

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
    imageUrl: SneakersIcon,
  },
  {
    id: 2,
    name: "Jeans",
    price: 499,
    imageUrl: SneakersIcon,
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
    price: 299,
    imageUrl: SneakersIcon,
  },
  {
    id: 5,
    name: "Sneakers 3",
    price: 299,
    imageUrl: SneakersIcon,
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

const HomePage: React.FC = () => {
  const [searchTerm, setSearchTerm] = useState<string>("");
  const [cart, setCart] = useState<CartItem[]>([]);
  const [isCartVisible, setIsCartVisible] = useState<boolean>(false);

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

  const getTotalPrice = () => {
    return cart.reduce((total, item) => total + item.price * item.quantity, 0);
  };

  const filteredProducts = products.filter((product) =>
    product.name.toLowerCase().includes(searchTerm.toLowerCase())
  );

  return (
    <div className="container">
      <div className="sidebar">
        <h2>Kategorier</h2>
        <ul>
          {categories.map((category) => (
            <li key={category.id}>
              {category.name}
              <ul>
                {category.subcategories.map((subcategory) => (
                  <li key={subcategory}>{subcategory}</li>
                ))}
              </ul>
            </li>
          ))}
        </ul>
      </div>
      <div className="content">
        <h1>Välkommen till vår E-handelssida för kläder!</h1>
        <div className="search">
          <input
            type="text"
            placeholder="Sök efter produkter..."
            value={searchTerm}
            onChange={(e) => setSearchTerm(e.target.value)}
          />
          <button>Sök</button>
        </div>
        <div className="products">
          {filteredProducts.map((product) => (
            <div key={product.id} className="product">
              <img src={product.imageUrl} alt={product.name} />
              <h3>{product.name}</h3>
              <p>Pris: {product.price} kr</p>
              <button onClick={() => addToCart(product)}>
                Lägg till i varukorg
              </button>
            </div>
          ))}
        </div>
      </div>
      <div
        className="cart"
        style={{ display: isCartVisible ? "block" : "none" }}
        onMouseEnter={() => setIsCartVisible(true)}
        onMouseLeave={() => setIsCartVisible(false)}
      >
        <h2>Kundvagn</h2>
        <ul>
          {cart.map((item) => (
            <li key={item.id}>
              <div className="cart-item">
                <img
                  src={item.imageUrl}
                  alt={item.name}
                  className="cart-item-image"
                />
                <div className="cart-item-details">
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
      <div
        className="cart-icon"
        onMouseEnter={() => setIsCartVisible(true)}
        onMouseLeave={() => setIsCartVisible(false)}
      >
        <img src={ShoppingCartIcon} alt="Shopping Cart" />
      </div>
    </div>
  );
};

export default HomePage;
