import React from "react";
import axios from "axios";
import swal from "sweetalert2";

import "./PostInput.css";

import { useState } from "react";

import { useSelector } from "react-redux";

async function sendPost(credentials) {
  return axios
    .post("http://localhost:5211/api/Posts", credentials, {
      headers: {
        "Content-Type": "application/json",
        Authorization: localStorage.getItem("token"),
      },
    })
    .then((response) => {
      return response.data;
    })
    .catch((error) => {
      swal.fire("Failed", error.message, "error");
    });
}

function PostInput() {
  const [postText, setPostText] = useState("");

  const userId = useSelector((state) => state.socialo.userId);

  const handleSubmit = async (e) => {
    e.preventDefault();

    swal
      .fire({
        title: "Do you want to send this post?",
        showDenyButton: true,
        confirmButtonText: "Post",
        denyButtonText: "Edit",
      })
      .then((result) => {
        if (result.isConfirmed) {
          const response = sendPost(
            JSON.stringify({
              content: postText,
              authorId: userId,
            })
          );
          if (response) {
            swal.fire("Success", "Post sent successfully", "success");
          }
          setPostText("");
        }
      });
  };

  return (
    <div>
      <div className="form-field" onSubmit={handleSubmit}>
        <input required></input>
        <label>Post </label>
      </div>
    </div>
  );
}

export default PostInput;
