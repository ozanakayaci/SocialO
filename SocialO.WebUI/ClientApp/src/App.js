import { useEffect } from "react";
import { Route, Routes, useLocation, useNavigate } from "react-router-dom";
import { useSelector } from "react-redux";

//style
import "./custom.css";
import "./App.css";

//components
import Home from "./components/Home/Home.js";
import Login from "./components/Login/Login";
import Register from "./components/Login/Register";
import Profile from "./components/UserProfile/Profile.js";
import Navbar from "./components/Navbar/Navbar.js";
import Post from "./components/Home/Post/Post";

function App() {
  const isAuthenticated = useSelector((state) => state.socialo.isAuthenticated);
  const location = useLocation();
  const navigate = useNavigate();

  useEffect(() => {
    if (isAuthenticated) {
      navigate("/home");
    } else navigate("/login");
  }, [isAuthenticated]);

  return (
    <div className="App">
      {isAuthenticated && !(location.pathname == "/login") && <Navbar />}
      <div className="pages">
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/home" element={<Home />} />
          <Route path="/register" element={<Register />} />
          <Route path="/login" element={<Login />} />
          <Route path="/profile" element={<Profile />}>
            <Route path="/profile/:username" element={<Profile />} />
          </Route>
          <Route path="/post">
            <Route path="/post/:PostId" element={<Post />} />
          </Route>
        </Routes>
      </div>
    </div>
  );
}

export default App;
