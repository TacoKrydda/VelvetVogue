import "./App.css";
import Header from "./Componets/Header";
import Home from "./Pages/Home";
import Footer from "./Componets/Footer";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import About from "./Pages/About";
import SideNavBar from "./Componets/SideNavBar";
import Navigation from "./Componets/Navigation";

function App() {
  return (
    <div className="App-container">
      <BrowserRouter>
        <div className="App-header">
          <div className="Head-nav-bar">
            <Navigation />
          </div>
          <div className="Search-container">
            <Header />
          </div>
        </div>
        <div className="App-body">
          <div className="App-body-content">
            <Routes>
              <Route path="/" element={<Home />} />
              <Route path="/about" element={<About />} />
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
