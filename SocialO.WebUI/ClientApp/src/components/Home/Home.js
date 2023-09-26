import React from "react";

import { useLocation } from "react-router-dom";

import { useSelector } from "react-redux";
import { useDispatch } from "react-redux";
import { logout } from "../../redux/socialo/socialoSlice";

import Login from "../Login/Login";

function Home() {
  const dispatch = useDispatch();

  const handleLogout = () => {
    localStorage.removeItem("accessToken");
    localStorage.removeItem("user");
    dispatch(logout());

    window.location.reload();
  };

  const location = useLocation();

  const isAuthenticated = useSelector((state) => state.socialo.isAuthenticated);

  return (
    <div>
      {(location.pathname == "/" || location.pathname == "/home") &&
      !isAuthenticated ? (
        <Login></Login>
      ) : (
        <div>
          <div>Girişi yapıldı</div>
          <button onClick={handleLogout}>Logout</button>
        </div>
      )}
    </div>
  );
}

export default Home;
