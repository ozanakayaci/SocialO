import { Navigate, Route, Routes } from "react-router-dom";

import "./App.css";

import Home from "./pages/Home";
import Login from "./pages/Login";
import Register from "./pages/Register";
import ErrorPage from "./pages/ErrorPage";
import Profile from "./pages/Profile";
import Post from "./pages/Post";
import Search from "./pages/Search";
import Settings from "./pages/Settings";
import { useSelector } from "react-redux";
import Navbar from "./components/Navbar";

function App() {
  const isAuthenticated = useSelector((state) => state.socialo.isAuthenticated);

  return (
    <>
      {isAuthenticated && <Navbar />}
      {!isAuthenticated ? (
        <Routes>
          <>
            <Route path="/" element={<Register />} />
            <Route path="/register" element={<Register />} />
            <Route path="/login" exact element={<Login />} />
            <Route path="/*" element={<Navigate to="/" />} />
          </>
        </Routes>
      ) : (
        <div className="flex flex-col justify-center items-center mt-28">
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/home" element={<Home />} />
            <Route path="/:username" element={<Profile />} />
            <Route path="/:username/post/:postId" element={<Post />} />
            <Route path="/search" element={<Search />} />
            <Route path="/settings" element={<Settings />} />
            <Route path="*" element={<ErrorPage />} />
          </Routes>
        </div>
      )}
    </>
  );
}

export default App;
