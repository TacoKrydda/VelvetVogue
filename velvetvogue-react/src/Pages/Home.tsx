import React from "react";
import { Link } from "react-router-dom";
import { Carousel } from "primereact/carousel";
import testImg from "../Img/pexels-godisable-jacob-1346187.jpg";

const Home = () => {
  return (
    <div>
      <div className="Body-sales">
        <Link to="/category/pants">
          <div className="Card">
            <img src={testImg} alt="pic" />
            <div className="Card-text">
              <h3>Jeans Product</h3>
              <p>Medlemspris!</p>
            </div>
          </div>
        </Link>
        <Link to="/category/pants">
          <div className="Card">
            <img src={testImg} alt="pic" />
            <div className="Card-text">
              <h3>Jeans Product</h3>
              <p>Medlemspris!</p>
            </div>
          </div>
        </Link>
        <Link to="/category/pants">
          <div className="Card">
            <img src={testImg} alt="pic" />
            <div className="Card-text">
              <h3>Jeans Product</h3>
              <p>Medlemspris!</p>
            </div>
          </div>
        </Link>
        <Link to="/category/pants">
          <div className="Card">
            <img src={testImg} alt="pic" />
            <div className="Card-text">
              <h3>Jeans Product</h3>
              <p>Medlemspris!</p>
            </div>
          </div>
        </Link>
        <Link to="/category/pants">
          <div className="Card">
            <img src={testImg} alt="pic" />
            <div className="Card-text">
              <h3>Jeans Product</h3>
              <p>Medlemspris!</p>
            </div>
          </div>
        </Link>
      </div>
      <div className="Body-new-items">
        <h2>Hello</h2>
      </div>
    </div>
  );
};

export default Home;
