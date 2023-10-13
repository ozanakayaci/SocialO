import { Avatar } from "@mui/material";
import PropTypes from "prop-types";
import { useEffect, useState } from "react";
import { Link } from "react-router-dom";

function PostCard({ post }) {
  const [formattedTime, setFormattedTime] = useState("");

  useEffect(() => {
    const postDate = new Date(
      `${post.datePosted.toString().split(" ")[0]}.000Z`
    );
    const currentDate = new Date();

    const timeDifference = currentDate - postDate;
    const minutesDifference = Math.floor(timeDifference / (1000 * 60));
    const hoursDifference = Math.floor(minutesDifference / 60);
    const daysDifference = Math.floor(hoursDifference / 24);
    const weeksDifference = Math.floor(daysDifference / 7);
    const monthsDifference = Math.floor(daysDifference / 30);

    let formattedDifference = "";
    if (monthsDifference > 0) {
      formattedDifference = `${monthsDifference} month${
        monthsDifference > 1 ? "s" : ""
      } ago`;
    } else if (weeksDifference > 0) {
      formattedDifference = `${weeksDifference} week${
        weeksDifference > 1 ? "s" : ""
      } ago`;
    } else if (daysDifference > 0) {
      formattedDifference = `${daysDifference} day${
        daysDifference > 1 ? "s" : ""
      } ago`;
    } else if (hoursDifference > 0) {
      formattedDifference = `${hoursDifference} hour${
        hoursDifference > 1 ? "s" : ""
      } ago`;
    } else {
      formattedDifference = `${minutesDifference} minute${
        minutesDifference > 1 ? "s" : ""
      } ago`;
    }

    setFormattedTime(formattedDifference);
  }, [post.datePosted]);

  return (
    <Link
      to={`/${post.authorUsername}/post/${post.postId}`}
      className="w-full flex sm:max-w-screen-sm items-center justify-center mt-3"
    >
      <div className="w-full rounded-md bg-gradient-to-r from-blue-500  to-white pb-1 ">
        <div
          className="h-full w-full bg-white  p-5
          hover:bg-gradient-to-t from-blue-100 to-white
          rounded-sm
        "
        >
          {/*horizantil margin is just for display*/}
          <div className="flex items-start px-4 py-4 ">
            <Avatar className="w-12 h-12 rounded-full object-cover mr-4 shadow">
              {post.authorUsername[0].toUpperCase()}
            </Avatar>
            <div className="w-full ">
              <div className="flex justify-between items-center">
                <div className="flex flex-row items-center ">
                  <Link
                    to={`/${post.authorUsername}`}
                    className="hover:underline text-2xl"
                  >
                    <h2 className="font-semibold text-gray-900 -mt-1 text-ellipsis line-clamp-1">
                      {post.authorName ? post.authorName : post.authorUsername}
                    </h2>
                  </Link>
                  <div className="ml-1 text-ellipsis line-clamp-1">
                    @{post.authorName ? post.authorName : post.authorUsername}
                  </div>
                </div>
                <small className="text-sm text-gray-700 text-ellipsis line-clamp-1  hidden sm:flex">
                  {formattedTime}
                </small>
              </div>

              <p className="mt-3 text-gray-700 text-base  pb-2  w-full">
                {post.content}
              </p>
            </div>
          </div>
          <div className="mt-4 flex flex-row-reverse items-center  p-4">
            <div className="flex  mr-2 text-gray-700 text-sm mr-3">
              <svg
                fill="none"
                viewBox="0 0 24 24"
                className="w-5 h-5 mr-1"
                stroke="currentColor"
              >
                <path
                  strokeLinecap="round"
                  strokeLinejoin="round"
                  strokeWidth={2}
                  d="M4.318 6.318a4.5 4.5 0 000 6.364L12 20.364l7.682-7.682a4.5 4.5 0 00-6.364-6.364L12 7.636l-1.318-1.318a4.5 4.5 0 00-6.364 0z"
                />
              </svg>
              <span>{post.favoriteCount}</span>
            </div>
            <div className="flex justify-center mr-2 text-gray-700 text-sm mr-8">
              <svg
                fill="none"
                viewBox="0 0 24 24"
                className="w-5 h-5 mr-1"
                stroke="currentColor"
              >
                <path
                  strokeLinecap="round"
                  strokeLinejoin="round"
                  strokeWidth={2}
                  d="M17 8h2a2 2 0 012 2v6a2 2 0 01-2 2h-2v4l-4-4H9a1.994 1.994 0 01-1.414-.586m0 0L11 14h4a2 2 0 002-2V6a2 2 0 00-2-2H5a2 2 0 00-2 2v6a2 2 0 002 2h2v4l.586-.586z"
                />
              </svg>
              <span>{post.commentCount}</span>
            </div>
          </div>
        </div>
      </div>
    </Link>
  );
}

PostCard.propTypes = {
  post: PropTypes.object,
};

export default PostCard;
