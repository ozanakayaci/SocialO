import { useState, useEffect } from "react";
import axios from "axios";
import swal from "sweetalert2";

import { Link } from "react-router-dom";

//import Login.css
import "./Login.css";

import { useDispatch } from "react-redux";
import { loginSuccess } from "../../redux/socialo/socialoSlice";

async function loginUser(credentials) {
  return axios
    .post("http://localhost:5211/api/Login/SignIn", credentials)
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
          dispatch(loginSuccess(response));
        });
    } else {
      swal.fire("Failed", response.message, "error");
    }
  };

  return (
    <div className="popup-login">
      <div>
        <div>
          <div className="signIn">
            Sign in to Social
            <span>O</span>
          </div>
          <form className="login-form" onSubmit={handleSubmit}>
            <input
              className="login-input"
              required
              id="email"
              name="email"
              label="Email Address"
              onChange={(e) => setLoginString(e.target.value)}
            />
            <input
              className="login-input"
              required
              id="password"
              name="password"
              label="Password"
              type="password"
              onChange={(e) => setPassword(e.target.value)}
            />
            <button
              className="login-button"
              type="submit"
              variant="contained"
              color="primary"
            >
              Sign In
            </button>
            <Link className="login-button" to="/register">
              Sign Up
            </Link>
          </form>
        </div>
      </div>
    </div>
  );
}

export default Login;
