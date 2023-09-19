import Login from "./components/Login/Login";
import Home from "./components/Home/Home.js";

const AppRoutes = [
  {
    index: true,
    element: <Home />,
  },
  {
    path: "/login",
    element: <Login />,
  },
];

export default AppRoutes;
