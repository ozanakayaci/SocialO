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

  const [post, setPost] = useState({
    postId: null,
    authorUsername: null,
    authorName: null,
    content: null,
    commentCount: null,
    favoriteCount: null,
  });

  useEffect(() => {
    console.log(location.pathname);
    console.log(`/post/${PostId}}`);
    if (location.pathname == `/post/${PostId}}`) {
      console.log("axios");
      axios
        .get(`https://localhost:7298/api/Posts/GetPost/${PostId}}`)
        .then((response) => {
          console.log(response.data);
          setPost(response.data);
        })
        .catch((error) => {
          console.log("error");
        });
    }
  }, [location.pathname]);

  let { PostId } = useParams();
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
            <Route path="/profile/:username" element={<Profile />} />
          </Route>
          <Route path="/post">
            <Route path=":PostId" element={<PostCard post={post} />} />
          </Route>
        </Routes>
      </div>
    </div>
  );
}

export default App;
