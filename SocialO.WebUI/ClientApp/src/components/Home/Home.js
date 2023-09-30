import React from "react";

import { useLocation } from "react-router-dom";

import { useSelector } from "react-redux";

import Login from "../Login/Login";

import "./Home.css";
import Flow from "./Flow/Flow";
import Navbar from "../Navbar/Navbar";
import PostArea from "./PostArea/PostArea";

function Home() {
  const location = useLocation();

  const isAuthenticated = useSelector((state) => state.socialo.isAuthenticated);

  return (
    <div>
      {(location.pathname == "/" || location.pathname == "/home") &&
      !isAuthenticated ? (
        <Login></Login>
      ) : (
        <div className="home-main">
          <div>
            <PostArea />
          </div>
          <div className="flow-main">
            <Flow />
          </div>
        </div>
      )}
    </div>
  );
}

export default Home;
