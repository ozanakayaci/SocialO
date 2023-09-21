import { useState } from "react";
import axios from "axios";
import swal from "sweetalert2";

import { Link } from "react-router-dom";

import { useDispatch } from "react-redux";
import { getUser } from "../../redux/socialo/socialoSlice";

async function loginUser(credentials) {
  return axios
    .post("http://localhost:5211/api/Login/Login", credentials)
    .then((response) => {
      return response.data;
    });
}

function Login() {
  const dispatch = useDispatch();

  const [loginString, setLoginString] = useState();
  const [password, setPassword] = useState();

  const handleSubmit = async (e) => {
    e.preventDefault();
    const response = await loginUser({
      loginString,
      password,
    });
    if (response["accessToken"]) {
      swal
        .fire("Success", response.message, "success", {
          buttons: false,
          timer: 2000,
        })
        .then((v) => {
          localStorage.setItem("accessToken", response["accessToken"]);
          delete response["user"].passwordHash;
          delete response["user"].passwordSalt;
          dispatch(getUser(response["user"]));
          delete response["user"];
          sessionStorage.setItem("token", JSON.stringify(response));
          window.location.href = "/";
        });
    } else {
      swal.fire("Failed", response.message, "error");
    }
  };

  return (
    <div>
      <div>
        <div>
          <div component="h1" variant="h5">
            Sign in
          </div>
          <form onSubmit={handleSubmit}>
            <input
              variant="outlined"
              margin="normal"
              required
              id="email"
              name="email"
              label="Email Address"
              onChange={(e) => setLoginString(e.target.value)}
            />
            <input
              variant="outlined"
              margin="normal"
              required
              id="password"
              name="password"
              label="Password"
              type="password"
              onChange={(e) => setPassword(e.target.value)}
            />
            <button type="submit" variant="contained" color="primary">
              Sign In
            </button>
          </form>
        </div>
      </div>
      <Link to="/register">Register</Link>
    </div>
  );
}

export default Login;
