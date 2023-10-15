import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import axios from "axios";

import PostCard from "../components/PostCard";

function Post() {
  const postId = useParams().postId;

  const [post, setPost] = useState({
    authorName: "undefined",
    authorUsername: "undefined",
    postId: "undefined",
    content: "undefined",
    datePosted: "undefined",
    authorId: "undefined",
    commentCount: "undefined",
    favoriteCount: "undefined",
  });

  useEffect(() => {
    axios
      .get(`http://localhost:5211/api/Posts/GetPost/${postId}`, {
        headers: {
          Authorization: localStorage.getItem("token"),
        },
      })
      .then((response) => {
        setPost(response.data);
        console.log(response);
      });
  }, []);

  return (
    <>
      <PostCard post={post} />
    </>
  );
}

export default Post;
