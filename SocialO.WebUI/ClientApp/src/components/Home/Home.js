import React from "react";

import { useLocation } from "react-router-dom";

import { useSelector } from "react-redux";

import Login from "../Login/Login";

function Home() {
  const handleLogout = () => {
    localStorage.removeItem("accessToken");
    localStorage.removeItem("user");
    window.location.href = "/";
  };

  const location = useLocation();

  const isAuthenticated = useSelector((state) => state.socialo.isAuthenticated);

  return (
    <div>
      {location.pathname != "/" ||
      (location.pathname != "/home" && !isAuthenticated) ? (
        <Login></Login>
      ) : (
        <button onClick={handleLogout}>Logout</button>
      )}
    </div>
  );
}

export default Home;
