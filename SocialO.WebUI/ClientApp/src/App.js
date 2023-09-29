import { Route, Routes } from "react-router-dom";

import "./custom.css";

import Home from "./components/Home/Home.js";
import Login from "./components/Login/Login";
import Register from "./components/Login/Register";
import Profile from "./components/UserProfile/Profile.js";
import Navbar from "./components/Navbar/Navbar.js";

import "./App.css";

function App() {
  return (
    <div className="App">
      <Navbar />
      <div className="pages">
        <Routes>
          <Route path="/" element={<Home />} exact />
          <Route path="/home" element={<Home />} />
          <Route path="/login" element={<Login />} />
          <Route path="/register" element={<Register />} />
          <Route path="/profile" element={<Profile />} />
        </Routes>
      </div>
    </div>
  );
}

export default App;
