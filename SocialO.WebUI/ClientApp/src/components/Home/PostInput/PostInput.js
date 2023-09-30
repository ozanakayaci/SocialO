import React from "react";
import axios from "axios";
import swal from "sweetalert2";

import "./PostInput.css";

import { useState } from "react";

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
              authorId: 5,
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
      <form onSubmit={handleSubmit}>
        <input
          rows="3"
          minLength="1"
          maxLength="200"
          onChange={(e) => setPostText(e.target.value)}
          value={postText}
        ></input>
        <button className="post-submit" type="submit">
          Post
        </button>
      </form>
    </div>
  );
}

export default PostInput;
