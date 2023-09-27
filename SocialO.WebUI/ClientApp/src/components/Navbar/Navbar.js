import React from "react";
import { Link } from "react-router-dom";
import "./Navbar.css"; // CSS dosyasını ekledik

import { useDispatch } from "react-redux";
import { logout } from "../../redux/socialo/socialoSlice";

function Navbar() {
  const dispatch = useDispatch();

  const handleLogout = () => {
    localStorage.removeItem("accessToken");
    localStorage.removeItem("user");
    dispatch(logout());

    window.location.reload();
  };

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

        <button onClick={handleLogout}>Logout</button>
      </div>
    </nav>
  );
}

export default Navbar;
