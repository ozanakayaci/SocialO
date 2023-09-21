import { createSlice } from "@reduxjs/toolkit";

export const socialoSlice = createSlice({
  name: "socialo",
  initialState: {
    isAuthenticated: false,
    user: null,
  },
  reducers: {
    getUser: (state, action) => {
      state.isAuthenticated = true;
      state.user = action.payload;
      localStorage.setItem("user", JSON.stringify(action.payload));
    },
  },
});

export const { getUser } = socialoSlice.actions;
export default socialoSlice.reducer;
