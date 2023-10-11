import { useEffect, useState } from "react";

import { useSelector, useDispatch } from "react-redux";

import { useNavigate } from "react-router-dom";

import axios from "axios";

import { logout, loginSuccess } from "../redux/socialo/socialoSlice";
import PostCard from "./PostCard";

function Flow() {
  const dispatch = useDispatch();
  const navigate = useNavigate();

  const [posts, setPosts] = useState([]);
  const [userId] = useState(1);
  const [page] = useState(1);
  const [pageSize] = useState(10);
  const [isOwnPost] = useState(false);

  useEffect(() => {
    axios
      .get(
        `http://localhost:5211/api/Posts/${userId}?page=${page}&pageSize=${pageSize}&isOwnPost=${isOwnPost}`,
        {
          headers: {
            Authorization: localStorage.getItem("token"),
          },
        }
      )
      .then((response) => {
        setPosts(response.data);
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
            .catch(() => {
              dispatch(logout());
              navigate("/");
            });
        }
      });
  }, [userId, page, pageSize]);

  return (
    <div className="flex flex-col mt-14 items-center">
      {posts.map((post) => (
        <PostCard key={post.postId} post={post} />
      ))}
    </div>
  );
}

export default Flow;
