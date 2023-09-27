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
      state.isAuthenticated = true;
      state.user = action.payload.user;
      state.token = action.payload.accessToken; // JWT token'ını saklayın
      localStorage.setItem("user", JSON.stringify(action.payload.user));
      localStorage.setItem("token", JSON.stringify(action.payload.accessToken));
    },
    logout: (state) => {
      state.isAuthenticated = false;
      state.user = null;
      state.token = null; // Çıkış yapınca JWT token'ı sıfırlayın
      localStorage.removeItem("user"); // Kullanıcıyı yerel depodan kaldırın
      localStorage.removeItem("token"); // JWT token'ını yerel depodan kaldırın
    },
  },
});

export const { loginSuccess, logout } = socialoSlice.actions;
export default socialoSlice.reducer;
