import { useState } from "react";

import axios from "axios";

import swal from "sweetalert2";

import { useSelector } from "react-redux";

import { useNavigate } from "react-router-dom";

import "./PostInput.css";

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
  const navigate = useNavigate();

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
            navigate("/");
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
