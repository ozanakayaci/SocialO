import { configureStore } from "@reduxjs/toolkit";

import socialoSlice from "./socialo/socialoSlice";

const store = configureStore({
  reducer: {
    socialo: socialoSlice,
  },
});

export default store;
