import { useState } from "react";
import axios from "axios";
import swal from "sweetalert2";

import { Link } from "react-router-dom";

async function registerUser(credentials) {
  return axios
    .post("http://localhost:5211/api/Login/Create", credentials, {
      headers: { "Content-Type": "multipart/form-data" },
    })
    .then((response) => {
      return response.data;
    });
}

function Register() {
  const [Username, setUsername] = useState();
  const [Email, setEmail] = useState();
  const [Password, setPassword] = useState();
  const [Repassword, setRePassword] = useState();

  const handleSubmit = async (e) => {
    e.preventDefault();
    const response = await registerUser({
      Username,
      Email,
      Password,
      Repassword,
    });
    console.log(response);
    if (response) {
      swal
        .fire("Success", response.message, "success", {
          buttons: false,
          timer: 2000,
        })
        .then((v) => {
          window.location.href = "/login";
        });
    } else {
      swal("Failed", response.message, "error");
    }
  };

  return (
    <div>
      <div />
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
              id="username"
              name="username"
              label="username"
              onChange={(e) => setUsername(e.target.value)}
              placeholder="username"
            />
            <input
              variant="outlined"
              margin="normal"
              required
              id="email"
              name="email"
              label="Email Address"
              onChange={(e) => setEmail(e.target.value)}
              placeholder="email"
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
              placeholder="password"
            />{" "}
            <input
              variant="outlined"
              margin="normal"
              required
              id="repassword"
              name="repassword"
              label="rePassword"
              type="password"
              onChange={(e) => setRePassword(e.target.value)}
              placeholder="rePassword"
            />
            <button type="submit" variant="contained" color="primary">
              Sign In
            </button>
          </form>
        </div>
      </div>
      <Link to="/login">Login</Link>
    </div>
  );
}

export default Register;
