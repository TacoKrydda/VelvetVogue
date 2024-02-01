import "./App.css";
import Header from "./Componets/Header";
import Home from "./Pages/Home";
import Footer from "./Componets/Footer";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import About from "./Pages/About";

function App() {
  return (
    <div className="App-Container">
      <BrowserRouter>
        <div className="App-header">
          <Header />
        </div>
        <div className="App-Body">
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/about" element={<About />} />
          </Routes>
        </div>
        <div className="App-footer">
          <Footer />
        </div>
      </BrowserRouter>
    </div>
  );
}

export default App;
