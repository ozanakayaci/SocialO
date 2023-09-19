import React from "react";
import { Link } from "react-router-dom";
import axios from "axios";

function Home() {
  axios
    .get("https://localhost:7298/WeatherForecast")
    .then((res) => {
      console.log(res);
    })
    .catch((err) => {
      console.log(err);
    });

  return (
    <div>
      <h1>Home</h1>
      <Link to="/login">Login</Link>
    </div>
  );
}

export default Home;
