import { useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom";
import axios from "axios";

import Flow from "../components/Flow";
import { Avatar } from "@mui/material";
import { useSelector } from "react-redux";

function Profile() {
  const username = useParams().username;

  const stateUsername = useSelector((state) => state.socialo.userName);

  const [profileData, setProfileData] = useState({
    about: "undefined",
    dateOfBirth: "undefined",
    dateRegistered: "undefined",
    favoriteCount: 0,
    firstName: "undefined",
    followerCount: 0,
    followingCount: 0,
    gender: "undefined",
    id: -1,
    lastName: "undefined",
    postCount: 0,
    username: "undefined",
  });
  const [isFollowed, setIsFollowed] = useState(true);

  const [OwnPost] = useState(true);

  useEffect(() => {
    axios
      .get(`http://localhost:5211/api/Users/${username}`)
      .then((response) => {
        setProfileData(response.data);
      });
  }, []);

  function FollowHandler() {
    setIsFollowed(!isFollowed);
  }
  return (
    <>
      <div className="sm:max-w-screen-sm w-full px-5 pb-4 sm:px-24 mt-12 bg-gradient-to-b from-blue-100 rounded-lg	 ">
        <div className="flex justify-center w-full text-3xl my-8 relative">
          <div className="absolute bottom-0">
            <Avatar
              sx={{ width: 80, height: 80, border: 2, borderColor: "#e1f5fe" }}
            >
              {profileData.username[0].toUpperCase()}
            </Avatar>
          </div>
        </div>
        <div className="mb-5">
          <div>
            <div className="flex flex-row items-center w-full justify-between ">
              <div className="flex flex-row items-center ">
                <Link
                  to={`/${profileData.username}`}
                  className="hover:underline text-2xl"
                >
                  <h2 className="font-semibold text-gray-900 -mt-1 text-ellipsis line-clamp-1">
                    {profileData.username}
                  </h2>
                </Link>
                <div className="ml-1 text-ellipsis line-clamp-1">
                  @{profileData.username}
                </div>
              </div>
              {profileData.username !== stateUsername &&
                (isFollowed ? (
                  <div>
                    <button
                      onClick={FollowHandler}
                      type="button"
                      className="inline-block rounded-3xl bg-black w-28 px-6 pb-2 pt-2.5 text-xs uppercase leading-normal text-white font-bold"
                    >
                      Unfollow
                    </button>
                  </div>
                ) : (
                  <div>
                    <button
                      onClick={FollowHandler}
                      type="button"
                      className="inline-block  rounded-3xl bg-blue-400 w-28 px-6 pb-2 pt-2.5 text-xs uppercase leading-normal text-black font-bold"
                    >
                      Follow
                    </button>
                  </div>
                ))}
            </div>
            <div className="flex flex-row">
              <div className="text-slate-400 font-light">
                <span className="text-black font-bold">
                  {profileData.postCount}{" "}
                </span>
                Posts
              </div>
              <div className="ml-3 text-slate-400 font-light">
                <span className="text-black font-bold">
                  {profileData.followingCount - 1}{" "}
                </span>
                Follower
              </div>
              <div className="ml-3 text-slate-400 font-light">
                <span className="text-black font-bold">
                  {profileData.followerCount - 1}{" "}
                </span>
                Following
              </div>
            </div>
            <div>
              <div className="whitespace-pre-wrap	">
                {profileData.about ? profileData.about : " tettetteeett"}
              </div>
            </div>
          </div>
        </div>
      </div>

      <>
        <Flow OwnPost={OwnPost} profileId={profileData.id} />
      </>
    </>
  );
}

export default Profile;
