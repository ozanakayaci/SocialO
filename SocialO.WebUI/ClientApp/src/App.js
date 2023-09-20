import { Route, Routes } from "react-router-dom";

import "./custom.css";

import { Link } from "react-router-dom";

import Login from "./components/Login/Login";
import Register from "./components/Login/Register";
import Home from "./components/Home/Home.js";
import Profile from "./components/UserProfile/Profile.js";

import "./App.css";

function App() {
  return (
    <div>
      <div>
        <Link to="/home">Home</Link>
        <Link to="/login">Login</Link>
      </div>

      <Routes>
        <Route path="/" element={<Home />} exact />
        <Route path="/home" element={<Home />} />
        <Route path="/login" element={<Login />} />
        <Route path="/register" element={<Register />} />
        <Route path="/profile" element={<Profile />} />
      </Routes>
    </div>
  );
}

export default App;
