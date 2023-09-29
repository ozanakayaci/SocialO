import React from "react";

import { useDispatch, useSelector } from "react-redux";
import { logout } from "../../redux/socialo/socialoSlice";

//css
import "./Navbar.css";

//component
import Search from "./Search/Search";

//react router
import { Link, redirect } from "react-router-dom";

function Navbar() {
  const dispatch = useDispatch();

  const isAuthenticated = useSelector((state) => state.socialo.isAuthenticated);

  const handleLogout = () => {
    localStorage.removeItem("accessToken");
    localStorage.removeItem("user");
    dispatch(logout());

    redirect("/");
  };

  return (
    <div className="navbar">
      <div className="navbar-comp">
        <Link className="navbar-button logo" to="/">
          Social<span>-</span>O
        </Link>
        {isAuthenticated && (
          <div className="category-buttons">
            <Link className="navbar-button" to="/home">
              Home
            </Link>
            <Link className="navbar-button" to="/profile">
              Profile
            </Link>
            <Link className="navbar-button" onClick={handleLogout}>
              Logout
            </Link>
          </div>
        )}
        <Search />
      </div>
    </div>
  );
}

export default Navbar;
