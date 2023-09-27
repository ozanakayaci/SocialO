import { useEffect, useState } from "react";

import { Link } from "react-router-dom";

function PostCard({ post }) {
  const [timeElapsed, setTimeElapsed] = useState("");

  useEffect(() => {
    const now = new Date();
    const postedDate = new Date(post.datePosted);
    console.log("now", now);
    console.log("pD", postedDate);

    // İki tarih arasındaki farkı hesaplayın
    const timeDifference = now - postedDate;

    // Dakika cinsinden geçen zamanı hesaplayın
    const minutesElapsed = Math.floor(timeDifference / (1000 * 60));

    if (minutesElapsed < 1) {
      // 1 dakikadan az ise "Şimdi" olarak ayarlayın
      setTimeElapsed("Şimdi");
    } else if (minutesElapsed < 60) {
      // 1 saatten az ise dakika cinsinden süreyi gösterin
      setTimeElapsed(`${minutesElapsed} dakika önce`);
    } else if (minutesElapsed < 1440) {
      // 1 saatten fazla ise saat cinsinden süreyi gösterin
      const hoursElapsed = Math.floor(minutesElapsed / 60);
      setTimeElapsed(`${hoursElapsed} saat önce`);
    } else {
      // 1 günden fazla ise gün cinsinden süreyi gösterin
      const daysElapsed = Math.floor(minutesElapsed / 1440);
      setTimeElapsed(`${daysElapsed} gün önce`);
    }
  }, [post.datePosted]);

  return (
    <Link to={`/post/${post.authorUsername}/${post.postId}`} className="card-c">
      <div className="c-header">
        <span className="c-name">
          <Link to={`/${post.authorUsername}`}>{post.authorName} </Link>
        </span>
        <span>
          <Link to={`/${post.authorUsername}`}> @{post.authorUsername}</Link>
        </span>
      </div>
      <div className="c-body">
        <p>{post.content}</p>
      </div>
      <div className="c-footer">
        <div>
          <i className="fa-regular fa-calendar"></i> <span>{timeElapsed}</span>
        </div>

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
