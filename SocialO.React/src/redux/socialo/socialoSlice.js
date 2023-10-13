import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

import jwt_decode from "jwt-decode";

const initialState = {
  isAuthenticated: localStorage.getItem("token") ? true : false,
  userId: null,
  userName: null,
  token: localStorage.getItem("token") ? localStorage.getItem("token") : null,
  refreshToken: sessionStorage.getItem("refreshToken")
    ? sessionStorage.getItem("refreshToken")
    : null,
  pending: false,
};

if (initialState.token) {
  const decodedToken = jwt_decode(initialState.token);
  initialState.userId =
    decodedToken[
      "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"
    ];
  initialState.userName =
    decodedToken["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
  localStorage.setItem("userId", initialState.userId);
} else {
  initialState.token = localStorage.getItem("token")
    ? localStorage.getItem("token")
    : null;
}
//login logout işlemleri için
export const login = createAsyncThunk(
  "socialo/login",
  async (credentials, thunAPI) => {
    console.log("credentials", credentials);
    if (!credentials.authToken) {
      return await axios
        .post("http://localhost:5211/api/Login/SignIn", credentials, {
          headers: {
            "Content-Type": "application/json",
          },
        })
        .then((res) => {
          return res.data;
        })
        .catch((err) => {
          return thunAPI.rejectWithValue(err);
        });
    }
    console.log("geçti");
    return credentials;
  }
);

export const socialoSlice = createSlice({
  name: "socialo",
  initialState,
  reducers: {
    loginSuccess: (state, action) => {
      state.isAuthenticated = action.payload.authenticateResult;
      state.token = action.payload.authToken; // JWT token'ını saklayın
      localStorage.setItem("token", `Bearer ${action.payload.authToken}`);
      sessionStorage.setItem("refreshToken", action.payload.refreshToken);

      if (state.token) {
        const decodedToken = jwt_decode(state.token);
        state.userId =
          decodedToken[
            "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"
          ];
        state.userName =
          decodedToken[
            "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"
          ];
        localStorage.setItem("userId", state.userId);
      } else {
        state.token = sessionStorage.getItem("token")
          ? sessionStorage.getItem("token")
          : null;
      }
    },
    logout: (state) => {
      state.isAuthenticated = false;
      state.refreshToken = null;
      state.token = null; // Çıkış yapınca JWT token'ı sıfırlayın
      localStorage.removeItem("token"); // JWT token'ını yerel depodan kaldırın
      state.userId = null;
      state.userName = null;
      localStorage.removeItem("userId");
      sessionStorage.removeItem("refreshToken");
    },
  },
  extraReducers: {
    [login.fulfilled]: (state, action) => {
      state.pending = false;
      state.isAuthenticated = action.payload.authenticateResult;
      state.token = action.payload.authToken; // JWT token'ını saklayın
      localStorage.setItem("token", `Bearer ${action.payload.authToken}`);
      sessionStorage.setItem("refreshToken", action.payload.refreshToken);
      if (state.token) {
        const decodedToken = jwt_decode(state.token);
        state.userId =
          decodedToken[
            "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"
          ];
        state.userName =
          decodedToken[
            "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"
          ];
        localStorage.setItem("userId", state.userId);
      } else {
        state.token = sessionStorage.getItem("token")
          ? sessionStorage.getItem("token")
          : null;
      }
    },
    [login.rejected]: (state) => {
      state.pending = false;
    },
    [login.pending]: (state) => {
      state.pending = true;
    },
  },
});

export const { loginSuccess, logout } = socialoSlice.actions;
export default socialoSlice.reducer;
