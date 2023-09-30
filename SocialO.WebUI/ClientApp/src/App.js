import { useState, useEffect } from "react";
import { Route, Routes, useLocation, useParams } from "react-router-dom";

import axios from "axios";

import "./custom.css";

import Home from "./components/Home/Home.js";
import Login from "./components/Login/Login";
import Register from "./components/Login/Register";
import Profile from "./components/UserProfile/Profile.js";
import Navbar from "./components/Navbar/Navbar.js";

import { useSelector } from "react-redux";

import "./App.css";
import PostCard from "./components/Home/Flow/PostCard";

function App() {
  const isAuthenticated = useSelector((state) => state.socialo.isAuthenticated);
  const location = useLocation();

  let { userId, username } = useParams();

  const [post, setPost] = useState();

  useEffect(() => {
    if (location.pathname == "/profile/:username/:userId") {
      axios
        .get(
          `https://localhost:7298/api/Posts/${location.pathname.split("/")[3]}`
        )
        .then((response) => {
          setPost(response.data);
        })
        .catch((error) => {
          console.log(error);
        });
    }
  }, [location.pathname]);

  return (
    <div className="App">
      {isAuthenticated && !(location.pathname == "/login") && <Navbar />}
      <div className="pages">
        <Routes>
          <Route path="/home" element={<Home />} />
          <Route path="/" element={<Home />}></Route>
          <Route path="/register" element={<Register />} />
          <Route path="/profile" />
          <Route path="/login" element={<Login />} />
          <Route path="/profile" element={<Profile />}>
            <Route path="/profile/:username" element={<Profile />}>
              <Route
                path="/profile/:username/:userId"
                element={<PostCard post={post} />}
              />
            </Route>
          </Route>
        </Routes>
      </div>
    </div>
  );
}

export default App;
