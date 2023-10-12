import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

import jwt_decode from "jwt-decode";

const initialState = {
  isAuthenticated: localStorage.getItem("token") ? true : false,
  userId: null,
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
} else {
  initialState.token = sessionStorage.getItem("token")
    ? sessionStorage.getItem("token")
    : null;
}
//login logout işlemleri için
export const login = createAsyncThunk(
  "socialo/login",
  async (credentials, thunAPI) => {
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
    },
    logout: (state) => {
      state.isAuthenticated = false;
      state.refreshToken = null;
      state.token = null; // Çıkış yapınca JWT token'ı sıfırlayın
      localStorage.removeItem("token"); // JWT token'ını yerel depodan kaldırın
    },
  },
  extraReducers: {
    [login.fulfilled]: (state, action) => {
      state.pending = false;
      console.log(action);
      state.isAuthenticated = action.payload.authenticateResult;
      state.token = action.payload.authToken; // JWT token'ını saklayın
      localStorage.setItem("token", `Bearer ${action.payload.authToken}`);
      console.log(localStorage.getItem("token"));
      sessionStorage.setItem("refreshToken", action.payload.refreshToken);
    },
    [login.rejected]: (state, action) => {
      state.pending = false;
      console.log("rejected");
    },
    [login.pending]: (state) => {
      state.pending = true;
    },
  },
});

export const { loginSuccess, logout } = socialoSlice.actions;
export default socialoSlice.reducer;
