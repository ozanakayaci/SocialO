import { Link } from "react-router-dom";

function PostCard({ post }) {
  return (
    <div className="w-full  flex  max-w-screen-sm items-center justify-center my-2">
      <div className="w-full rounded-md bg-gradient-to-r from-blue-500  to-white pb-1">
        <div className="h-full w-full bg-white p-5">
          {/*horizantil margin is just for display*/}
          <div className="flex items-start px-4 py-4">
            <img
              className="w-12 h-12 rounded-full object-cover mr-4 shadow"
              src="https://images.unsplash.com/photo-1542156822-6924d1a71ace?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=500&q=60"
              alt="avatar"
            />
            <div className="w-full">
              <div className="flex items-center justify-between">
                <Link to={`/profile/:${post.authorId}`}>
                  <h2 className="text-lg font-semibold text-gray-900 -mt-1">
                    {post.authorName}
                  </h2>
                </Link>
                <small className="text-sm text-gray-700">22h ago</small>
              </div>

              <p className="mt-3 text-gray-700 text-sm w-full">
                {post.content}
              </p>
            </div>
          </div>
          <div className="mt-4 flex items-center">
            <div className="flex mr-2 text-gray-700 text-sm mr-3">
              <svg
                fill="none"
                viewBox="0 0 24 24"
                className="w-4 h-4 mr-1"
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
            <div className="flex mr-2 text-gray-700 text-sm mr-8">
              <svg
                fill="none"
                viewBox="0 0 24 24"
                className="w-4 h-4 mr-1"
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
    </div>
  );
}

export default PostCard;
