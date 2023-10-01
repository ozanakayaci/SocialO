import { useState, useEffect } from "react";
import axios from "axios";
import swal from "sweetalert2";

import { Link } from "react-router-dom";

//import Login.css
import "./Login.css";

import { useDispatch, useSelector } from "react-redux";
import { loginSuccess } from "../../redux/socialo/socialoSlice";

async function loginUser(credentials) {
  return axios
    .post("http://localhost:5211/api/Login/SignIn", credentials, {
      headers: {
        "Content-Type": "application/json",
      },
    })
    .then((response) => {
      return response.data;
    });
}

function Login() {
  const dispatch = useDispatch();

  const isAuthenticated = useSelector((state) => state.socialo.isAuthenticated);

  const [loginString, setLoginString] = useState();
  const [password, setPassword] = useState();

  useEffect(() => {
    if (isAuthenticated) {
      window.location.href = "/home";
    }
  }, [isAuthenticated]);

  const handleSubmit = async (e) => {
    e.preventDefault();
    const response = await loginUser(
      JSON.stringify({
        username: loginString,
        password: password,
      })
    );
    if (response["authToken"]) {
      swal
        .fire("Success", response.message, "success", {
          buttons: false,
          timer: 2000,
        })
        .then((v) => {
          dispatch(loginSuccess(response));
          window.location.href = "/home";
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
            <button className="login-button" type="submit">
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
