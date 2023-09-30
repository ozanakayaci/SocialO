import { useEffect, useState } from "react";

import { Link } from "react-router-dom";

function PostCard({ post }) {
  const [timeElapsed, setTimeElapsed] = useState("");

  return (
    <Link to={`/post/${post.authorUsername}/${post.postId}`} className="card-c">
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
    </Link>
  );
}

export default PostCard;
