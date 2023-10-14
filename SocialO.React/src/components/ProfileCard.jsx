import { Avatar } from "@mui/material";
import PropTypes from "prop-types";
import { useState } from "react";

import { Link } from "react-router-dom";

function ProfileCard({ user }) {
  const [isFollowed, setIsFollowed] = useState(false);

  function FollowHandler() {
    setIsFollowed(!isFollowed);
  }

  return (
    <div className="w-full flex md:max-w-screen-sm items-center justify-center mt-3">
      <div className="w-full rounded-md bg-gradient-to-r from-blue-500  to-white pb-1 ">
        <div
          className="h-full w-full bg-white  p-5
          hover:bg-gradient-to-t from-blue-100 to-white
          rounded-sm px-2 md:p-5
        "
        >
          {/*horizantil margin is just for display*/}
          <div
            to={`/${user.username}`}
            className="flex items-start px-0 md:px-4 py-4 "
          >
            <Avatar className="w-8 h-8 md:w-12 md:h-12 rounded-full object-cover mr-4 shadow">
              {user.username[0].toUpperCase()}
            </Avatar>
            <div className="w-full ">
              <div className="flex justify-between items-center h-10">
                <div className="flex flex-row items-center ">
                  <Link to={`/${user.username}`} className="hover:underline">
                    <h2 className="font-semibold text-gray-900 text-ellipsis line-clamp-1 text-base md:text-2xl">
                      {user.name ? user.name : user.username}
                    </h2>
                  </Link>
                  <div className="ml-1 text-ellipsis line-clamp-1 text-xs md:text-lg">
                    @{user.username}
                  </div>
                </div>
              </div>
              <div className="flex flex-row text-sm md:text-base">
                <div className=" text-slate-400 font-light">
                  <span className="text-black font-bold">
                    {user.followingCount - 1}{" "}
                  </span>
                  Follower
                </div>
                <div className="ml-3 text-slate-400 font-light">
                  <span className="text-black font-bold">
                    {user.followerCount - 1}{" "}
                  </span>
                  Following
                </div>
              </div>
              <p className="mt-3 text-gray-700 text-sm md:text-base  pb-2  w-full">
                {user.about}
              </p>
            </div>
            {isFollowed ? (
              <div className=" text-xs md:text-sm mt-1">
                <button
                  onClick={FollowHandler}
                  type="button"
                  className="inline-block rounded-3xl bg-black hover:bg-blue-400 hover:text-black w-15 px-4 pb-2 pt-2.5 uppercase leading-normal text-white font-bold "
                >
                  Unfollow
                </button>
              </div>
            ) : (
              <div>
                <button
                  onClick={FollowHandler}
                  type="button"
                  className="inline-block  rounded-3xl bg-blue-400 hover:bg-black hover:text-white w-15 px-4 pb-2 pt-2.5 uppercase leading-normal text-black font-bold "
                >
                  Follow
                </button>
              </div>
            )}
          </div>
        </div>
      </div>
    </div>
  );
}

ProfileCard.propTypes = {
  user: PropTypes.object,
};

export default ProfileCard;
