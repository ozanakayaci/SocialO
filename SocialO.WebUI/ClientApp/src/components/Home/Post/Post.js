import React, { useEffect, useState } from "react";
import { Link, useParams, redirect } from "react-router-dom";
import { useDispatch } from "react-redux";

import axios from "axios";

import { loginSuccess, logout } from "../../../redux/socialo/socialoSlice";

function Post() {
  const [post, setPost] = useState({});
  const { PostId } = useParams();

  const dispatch = useDispatch();

  useEffect(() => {
    axios
      .get(`http://localhost:5211/api/Posts/GetPost/${PostId}`, {
        headers: {
          Authorization: localStorage.getItem("token"),
        },
      })
      .then((response) => {
        setPost(response.data);
      })
      .catch((error) => {
        if (error.response.status === 401) {
          let data = new FormData();
          data.append("refreshToken", sessionStorage.getItem("refreshToken"));
          axios
            .post(
              `http://localhost:5211/api/Login/RefreshTokenLogin`,
              sessionStorage.getItem("refreshToken")
            )
            .then((response) => {
              dispatch(loginSuccess(response.data));
            })
            .catch((error) => {
              dispatch(logout());
              redirect("/");
            });
        }
      });
  }, [PostId]);

  return (
    <div className="card-c">
      <div className="c-header">
        <span className="c-name">
          <Link to={`/profile/${post.authorUsername}`}>{post.authorName} </Link>
        </span>
        <span>
          <Link to={`/profile/${post.authorUsername}`}>
            {" "}
            @{post.authorUsername}
          </Link>
        </span>
      </div>
      <div className="c-body">
        <pre>{post.content}</pre>
      </div>
      <div className="c-footer">
        <div className="comment">
          <Link>
            <i className="fa-regular fa-comments"></i> {post.commentCount}
          </Link>
        </div>
        <div className="favorite">
          <Link to="">
            <i className="fa-regular fa-heart"></i> {post.favoriteCount}
          </Link>
        </div>
      </div>
    </div>
  );
}

export default Post;
