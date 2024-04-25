import "./App.css";
import Header from "./Componets/Header";
import Home from "./Pages/Home";
import Footer from "./Componets/Footer";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import About from "./Pages/About";
import MobileNavigation from "./Componets/MobileNavigation ";
import DesktopNavigation from "./Componets/DesktopNavigation";
import Jeans from "./Pages/Pants/Jeans";
import PostEntity from "./Pages/Crud/PostEntity";
import HomePage from "./Pages/HomePage/HomePage";
import { useState } from "react";
import SearchComponent from "./Pages/HomePage/SearchComponent";
import CartComponent from "./Pages/HomePage/CartComponent";
import cartstyle from "./Pages/HomePage/HomePage.module.css";
import CartContainer from "./Componets/CartContainer";

interface Product {
  id: number;
  name: string;
  price: number;
  imageUrl: string;
}

interface CartItem extends Product {
  quantity: number;
}

function App() {
  const [searchTerm, setSearchTerm] = useState<string>("");
  const [cart, setCart] = useState<CartItem[]>([]);
  const [isCartVisible, setIsCartVisible] = useState<boolean>(false);
  const getTotalPrice = () => {
    return cart.reduce((total, item) => total + item.price * item.quantity, 0);
  };

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

  return (
    <div className="App-container">
      <BrowserRouter>
        <div className="App-header">
          <div className="Head-nav-bar">
            <MobileNavigation />
          </div>
          <div className="Search-container">
            <SearchComponent
              searchTerm={searchTerm}
              setSearchTerm={setSearchTerm}
            />
          </div>
          <CartContainer
            cart={cart}
            isCartVisible={isCartVisible}
            setIsCartVisible={setIsCartVisible}
            getTotalPrice={getTotalPrice}
          />
        </div>
        <div className="App-body">
          <div className="Body-nav-bar">
            <DesktopNavigation />
          </div>
          <div className="App-body-content">
            <Routes>
              {/* <Route path="/" element={<Home />} /> */}
              <Route path="/post" element={<PostEntity />} />
              <Route path="/about" element={<About />} />
              <Route
                path="/"
                element={
                  <HomePage
                    searchTerm={searchTerm}
                    cart={cart}
                    setIsCartVisible={setIsCartVisible}
                    setCart={setCart}
                  />
                }
              />
              <Route path="/category/pants/jeans" element={<Jeans />} />
            </Routes>
          </div>
        </div>
        <div className="App-footer">
          <Footer />
        </div>
      </BrowserRouter>
    </div>
  );
}

export default App;
