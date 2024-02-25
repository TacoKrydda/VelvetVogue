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
import BrandPost from "./Pages/Crud/Brand/BrandPost";

function App() {
  return (
    <div className="App-container">
      <BrowserRouter>
        <div className="App-header">
          <div className="Head-nav-bar">
            <MobileNavigation />
          </div>
          <div className="Search-container">
            <Header />
          </div>
        </div>
        <div className="App-body">
          <div className="Body-nav-bar">
            <DesktopNavigation />
          </div>
          <div className="App-body-content">
            <Routes>
              <Route path="/" element={<BrandPost />} />
              <Route path="/post" element={<PostEntity />} />
              <Route path="/about" element={<About />} />
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
