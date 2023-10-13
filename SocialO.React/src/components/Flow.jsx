import { useEffect, useState } from "react";

import { useSelector, useDispatch } from "react-redux";

import { useNavigate } from "react-router-dom";

import axios from "axios";

import { logout, login } from "../redux/socialo/socialoSlice";
import PostCard from "./PostCard";

import PropTypes from "prop-types";
import { Card } from "@mui/material";

function Flow({ OwnPost, profileId }) {
  const dispatch = useDispatch();
  const navigate = useNavigate();

  const userId = useSelector((state) => state.socialo.userId);

  const [test, setTest] = useState(0);
  const [message] = useState("Something went wrong");
  const [posts, setPosts] = useState([]);
  const [page] = useState(1);
  const [pageSize] = useState(10);
  const [isOwnPost] = useState(OwnPost || false);

  useEffect(() => {
    //redux'a taşıyacağız
    userId === null && navigate("/login");
    axios
      .get(
        `http://localhost:5211/api/Posts/${
          isOwnPost ? profileId : userId
        }?page=${page}&pageSize=${pageSize}&isOwnPost=${isOwnPost}`,
        {
          headers: {
            Authorization: localStorage.getItem("token"),
          },
        }
      )
      .then((response) => {
        setPosts(response.data);
        setTest(1);
      })
      .catch((error) => {
        if (error.response.status === 401) {
          if (sessionStorage.getItem("refreshToken")) {
            axios
              .post(
                `http://localhost:5211/api/Login/${sessionStorage.getItem(
                  "refreshToken"
                )}`
              )
              .then((response) => {
                console.log("response", response.data);
                dispatch(login(response.data));
                setTest(2);
              })
              .catch(() => {
                dispatch(logout());
                navigate("/");
              });
          } else {
            dispatch(logout());
            navigate("/");
            setTest(3);
          }
        }
      });
  }, [test, profileId]);

  return (
    <Card className="flex flex-col mt-14 items-center sm:min-w-full  ">
      {posts.length < 1 && <div className="text-red-500">{message}</div>}

      {posts.map((post) => (
        <PostCard key={post.postId} post={post} />
      ))}
    </Card>
  );
}

Flow.propTypes = {
  OwnPost: PropTypes.bool,
  profileId: PropTypes.number,
};

export default Flow;
