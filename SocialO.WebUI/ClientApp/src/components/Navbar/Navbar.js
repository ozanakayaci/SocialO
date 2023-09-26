import React from "react";
import { Link } from "react-router-dom";
import "./Navbar.css"; // CSS dosyasını ekledik

function Navbar() {
  return (
    <nav className="navbar">
      <div className="logo">
        <h1>
          <Link className="nav-link" to="/">
            SocialO
          </Link>
        </h1>
      </div>
      <div className="nav-links">
        <Link className="nav-link" to="/home">
          Home
        </Link>
        <Link className="nav-link" to="/login">
          Login
        </Link>
      </div>
    </nav>
  );
}

export default Navbar;
