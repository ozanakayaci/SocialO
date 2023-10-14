import { useEffect, useState } from "react";

import { useSelector, useDispatch } from "react-redux";

import { Link, useNavigate } from "react-router-dom";

import axios from "axios";

import { logout, login } from "../redux/socialo/socialoSlice";
import PostCard from "./PostCard";

import PropTypes from "prop-types";

function Flow({ OwnPost, profileId }) {
  const dispatch = useDispatch();
  const navigate = useNavigate();

  const userId = useSelector((state) => state.socialo.userId);

  const [test, setTest] = useState(0);
  const [message] = useState("Something went wrong");
  const [posts, setPosts] = useState([
    {
      authorName: "undefined",
      authorUsername: "undefined",
      postId: "undefined",
      content: "undefined",
      datePosted: "undefined",
      authorId: "undefined",
      commentCount: "undefined",
      favoriteCount: "undefined",
    },
  ]);
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
        if (page === 1) {
          setPosts(response.data);
        } else {
          setPosts([...posts, ...response.data]);
        }
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
                console.log("response", response);
                if (response.data === "") {
                  setTest(4);
                } else {
                  dispatch(login(response.data));
                }
                setTest(2);
              })
              .catch((error) => {
                if (error.response.status === 400) {
                  setTest(5);
                } else {
                  dispatch(logout());
                  navigate("/");
                }
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
    <div className="flex flex-col mt-14 items-center min-w-full  ">
      {posts.length < 1 && <div className="text-red-500">{message}</div>}

      {posts[0].authorName !== "undefined" ? (
        posts.map((post) => <PostCard key={post.postId} post={post} />)
      ) : isOwnPost ? (
        <div className="mt-20 text-5xl font-semibold text-blue-500 flex flex-row items-center h-36">
          Start Searching...
        </div>
      ) : (
        <div className="mt-16 m-5 text-5xl font-semibold text-blue-500 flex flex-row items-center h-36">
          <Link to="/search" className="hover:text-black underline">
            Find
          </Link>
          <div className="ml-3"> someone to follow...</div>
        </div>
      )}
    </div>
  );
}

Flow.propTypes = {
  OwnPost: PropTypes.bool,
  profileId: PropTypes.number,
};

export default Flow;
