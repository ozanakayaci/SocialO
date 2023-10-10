import { createBrowserRouter } from "react-router-dom";

import Home from "../pages/Home";
import Login from "../pages/Login";
import Register from "../pages/Register";
import ErrorPage from "../pages/ErrorPage";
import Navbar from "../components/Navbar";

export const router = createBrowserRouter([
  { path: "/login", element: <Login /> },
  { path: "/register", element: <Register /> },
  { path: "/", element: <Home /> },
  { path: "/home", element: <Home /> },
  { path: "*", element: <ErrorPage /> },
  { path: "/navbar", element: <Navbar /> },
]);
