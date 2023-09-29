import axios from "axios";

import { redirect } from "react-router-dom";

import { useState, useEffect } from "react";

import PostCard from "./PostCard";

import { useSelector, useDispatch } from "react-redux";
import { logout } from "../../../redux/socialo/socialoSlice";

function Flow() {
  const [posts, setPosts] = useState([]);
  const [page, setPage] = useState(1);
  const [pageSize, setPageSize] = useState(10);
  const [userId, setUserId] = useState(5);

  const isAuthenticated = useSelector((state) => state.socialo.isAuthenticated);

  const dispatch = useDispatch();

  useEffect(() => {
    if (userId) {
      axios
        .get(
          `http://localhost:5211/api/Posts/${userId}?page=${page}&pageSize=${pageSize}&isOwnPost=false`,
          {
            headers: {
              Authorization: localStorage.getItem("token"),
            },
          }
        )
        .then((response) => {
          setPosts(response.data);
          console.log(response.data);
        })
        .catch((error) => {
          if (error.response.status === 401) {
            dispatch(logout());
            redirect("/");
          }
        });
    }
  }, [userId, page, pageSize]);

  return (
    <div className="flow">
      {posts.map((post) => (
        <PostCard key={post.postId} post={post} />
      ))}
    </div>
  );
}

export default Flow;
