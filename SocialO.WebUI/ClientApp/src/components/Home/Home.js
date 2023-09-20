import React from "react";
import { Link, useLocation } from "react-router-dom";
import Login from "../Login/Login";

function Home() {
  const handleLogout = () => {
    localStorage.removeItem("accessToken");
    localStorage.removeItem("user");
    window.location.href = "/";
  };

  const location = useLocation();

  return (
    <div>
      <button onClick={handleLogout}>Logout</button>
      {location.pathname != "/" && 5 == 5 && <Login></Login>}
    </div>
  );
}

export default Home;
