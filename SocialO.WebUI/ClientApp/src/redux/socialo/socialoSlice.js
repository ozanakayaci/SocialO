import { createSlice } from "@reduxjs/toolkit";

import jwt_decode from "jwt-decode";

const token = localStorage.getItem("token");
const decoded = jwt_decode(token);

export const socialoSlice = createSlice({
  name: "socialo",
  initialState: {
    isAuthenticated: localStorage.getItem("token") ? true : false,
    userId: decoded
      ? decoded[
          "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"
        ]
      : null,
    token: localStorage.getItem("token") ? true : null,
  },
  reducers: {
    loginSuccess: (state, action) => {
      state.isAuthenticated = action.payload.authenticateResult;
      state.token = action.payload.authToken; // JWT token'ını saklayın
      localStorage.setItem("token", `Bearer ${action.payload.authToken}`);
      sessionStorage.setItem("refreshToken", action.payload.refreshToken);
    },
    logout: (state) => {
      state.isAuthenticated = false;
      state.user = null;
      state.token = null; // Çıkış yapınca JWT token'ı sıfırlayın
      localStorage.removeItem("token"); // JWT token'ını yerel depodan kaldırın
    },
  },
});

export const { loginSuccess, logout } = socialoSlice.actions;
export default socialoSlice.reducer;
