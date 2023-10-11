import { Route, Routes } from "react-router-dom";

import "./App.css";

import Home from "./pages/Home";
import Login from "./pages/Login";
import Register from "./pages/Register";
import ErrorPage from "./pages/ErrorPage";
import Profile from "./pages/Profile";
import Search from "./pages/Search";
import Settings from "./pages/Settings";

function App() {
  return (
    <>
      <Routes>
        <Route path="/login" element={<Login />} />
        <Route path="/register" element={<Register />} />
        <Route path="/" element={<Home />} />
        <Route path="/home" element={<Home />} />
        <Route path="/profile" element={<Profile />} />
        <Route path="/search" element={<Search />} />
        <Route path="/settings" element={<Settings />} />
        
        <Route path="*" element={<ErrorPage />} />
      </Routes>
    </>
  );
}

export default App;
