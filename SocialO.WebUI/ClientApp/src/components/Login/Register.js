import { useState } from "react";
import axios from "axios";
import swal from "sweetalert2";

import "./Register.css";

import { Link } from "react-router-dom";

async function registerUser(credentials) {
  return axios
    .post("http://localhost:5211/api/Login/SignUp", credentials, {
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
    try {
      const response = await registerUser({
        Username,
        Email,
        Password,
        Repassword,
      });

      if (response.status === 200) {
        // Başarılı kayıt
        swal.fire("Success", response.data.message, "success");
        setTimeout(() => {
          window.location.href = "/login";
        }, 2000);
      } else {
        // API'den gelen hata
        swal.fire("Failed", response.data.message, "error");
      }
    } catch (error) {
      // Hata oluştuğunda
      swal.fire("Error", "Bir hata oluştu. Lütfen tekrar deneyin.", "error");
      console.error("API isteği sırasında hata oluştu:", error);
    }
  };

  return (
    <div className="popup-register">
      <div>
        <div>
          <div className="signIn">
            Sign up to Social
            <span>O</span>
          </div>
          <form className="register-form" onSubmit={handleSubmit}>
            <input
              className="register-input"
              required
              id="email"
              name="email"
              label="Email Address"
              onChange={(e) => setUsername(e.target.value)}
              placeholder="Username"
            />
            <input
              className="register-input"
              required
              id="email"
              name="email"
              label="email"
              type="email"
              onChange={(e) => setEmail(e.target.value)}
              placeholder="Email"
            />
            <input
              className="register-input"
              required
              id="password"
              name="password"
              label="Password"
              type="password"
              onChange={(e) => setPassword(e.target.value)}
              placeholder="password"
            />
            <input
              className="register-input"
              required
              id="repassword"
              name="repassword"
              label="rePassword"
              type="password"
              onChange={(e) => setRePassword(e.target.value)}
              placeholder="rePassword"
            />
            <button
              className="register-button"
              type="submit"
              variant="contained"
              color="primary"
            >
              Sign Up
            </button>
            <Link className="register-button" to="/login">
              Sign In
            </Link>
          </form>
        </div>
      </div>
    </div>
  );
}

export default Register;
