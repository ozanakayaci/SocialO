import { Route, Routes } from "react-router-dom";

import "./custom.css";

import Login from "./components/Login/Login";
import Register from "./components/Login/Register";
import Home from "./components/Home/Home.js";

import "./App.css";

function App() {
  return (
    <Routes>
      <Route path="/" element={<Home />} exact />
      <Route path="/home" element={<Home />} />
      <Route path="/login" element={<Login />} />
      <Route path="/register" element={<Register />} />
    </Routes>
  );
}

export default App;
