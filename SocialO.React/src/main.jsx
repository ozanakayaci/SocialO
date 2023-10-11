import React from "react";
import ReactDOM from "react-dom/client";
import "./index.css";
//redux
import { Provider } from "react-redux";
import store from "./redux/store";
//react-router-dom
import { BrowserRouter } from "react-router-dom";
//react-toastify
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.min.css";

import App from "./App";

ReactDOM.createRoot(document.getElementById("root")).render(
  <React.StrictMode>
    <ToastContainer
      position="bottom-center"
      autoClose={3000}
      limit={2}
      hideProgressBar={false}
      newestOnTop
      closeOnClick
      rtl={false}
      pauseOnFocusLoss
      draggable
      pauseOnHover
      theme="light"
    />
    <Provider store={store}>
      <BrowserRouter>
        <App />
      </BrowserRouter>
    </Provider>
  </React.StrictMode>
);
