import React, { useState } from "react";
import { Link } from "react-router-dom";

const About = () => {
  const [subPants, setSubPants] = useState(false);
  const [subShirts, setSubShirts] = useState(false);

  const showCategories = (category: string, show: boolean) => {
    switch (category) {
      case "Pants":
        setSubPants(!subPants);
        setSubShirts(false);
        break;
      case "Shirts":
        setSubShirts(!subShirts);
        setSubPants(false);
        break;
      default:
        break;
    }
  };

  return (
    <div>
      <h2>Om oss</h2>
      <p>
        Välkommen till vår "Om oss"-sida. Vi är ett fantastiskt team som bygger
        spännande saker!
      </p>

      <div className="desktop-sidebar">
        <nav className="navigation-nav">
          <ul className="navigation-ul">
            <li className="navigation-li">
              <Link className="navigation-a-p" to="/category/pants">
                Byxor
              </Link>
              <button
                className="navigation-btn"
                onClick={() => showCategories("Pants", subPants)}
              >
                More
              </button>
            </li>

            {subPants && (
              <ul className="navigation-ul">
                <li className="navigation-li">
                  <Link className="navigation-a-c" to="/category/pants/jeans">
                    Jeans
                  </Link>
                </li>
                <li className="navigation-li">
                  <Link className="navigation-a-c" to="/category/pants/chinos">
                    Chinos
                  </Link>
                </li>
              </ul>
            )}

            <li className="navigation-li">
              <Link className="navigation-a-p" to="/category/shirts">
                Shirts
              </Link>
              <button
                className="navigation-btn"
                onClick={() => showCategories("Shirts", subShirts)}
              >
                More
              </button>
            </li>

            {subShirts && (
              <ul className="navigation-sub-nav">
                <li className="navigation-li">
                  <Link
                    className="navigation-a-c"
                    to="/category/shirts/t-shirts"
                  >
                    T-shirts
                  </Link>
                </li>
                <li className="navigation-li">
                  <Link
                    className="navigation-a-c"
                    to="/category/shirts/skjortor"
                  >
                    Skjortor
                  </Link>
                </li>
              </ul>
            )}
          </ul>
        </nav>
      </div>
    </div>
  );
};

export default About;
