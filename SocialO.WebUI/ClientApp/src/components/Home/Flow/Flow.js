import axios from "axios";
import { useState, useEffect } from "react";
import PostCard from "./PostCard";

function Flow() {
  const [posts, setPosts] = useState([]);
  const [page, setPage] = useState(1);
  const [pageSize, setPageSize] = useState(10);
  const [userId, setUserId] = useState(
    JSON.parse(localStorage.getItem("user")).id
  );

  useEffect(() => {
    if (userId) {
      axios
        .get(
          `http://localhost:5211/api/Posts/${userId}?page=${page}&pageSize=${pageSize}&isOwnPost=false`,
          {
            headers: {
              "Content-Type": "text/plain",
            },
          }
        )
        .then((response) => {
          setPosts(response.data);
          console.log(response.data);
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
