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

    const response = await sendPost(
      JSON.stringify({
        content: postText,
        authorId: 5,
      })
    );
    if (response) {
      swal.fire("Success", "Post sent successfully", "success");
    }
  };

  return (
    <div>
      <form onSubmit={handleSubmit}>
        <input
          rows="3"
          minLength="1"
          maxLength="200"
          onChange={(e) => setPostText(e.target.value)}
        ></input>
        <button className="post-submit" type="submit">
          Post
        </button>
      </form>
    </div>
  );
}

export default PostInput;
