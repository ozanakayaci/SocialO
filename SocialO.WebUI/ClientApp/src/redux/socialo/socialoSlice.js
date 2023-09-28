import { createSlice } from "@reduxjs/toolkit";

export const socialoSlice = createSlice({
  name: "socialo",
  initialState: {
    isAuthenticated: localStorage.getItem("token") ? true : false,
    user: null,
    token: null,
  },
  reducers: {
    loginSuccess: (state, action) => {
      console.log(action.payload);
      state.isAuthenticated = action.payload.authenticateResult;
      state.token = action.payload.authToken; // JWT token'ını saklayın
      localStorage.setItem("token", `Bearer ${action.payload.authToken}`);
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
