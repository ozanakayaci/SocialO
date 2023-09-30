import axios from "axios";
import { useEffect, useState } from "react";

import { useParams } from "react-router-dom";

function Profile() {
  let { username } = useParams();

  const [user, setUser] = useState({
    id: null,
    username: null,
    firstName: null,
    lastName: null,
    gender: null,
    about: null,
    dateOfBirth: null,
    dateRegistered: null,
    postCount: null,
    followerCount: null,
    followingCount: null,
    favoriteCount: null,
  });

  useEffect(() => {
    axios
      .get(`https://localhost:7298/api/Users/${username}`)
      .then((response) => {
        setUser(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
  }, [username]);

  return (
    <div>
      <div>{user.username}</div>
      <div>{user.firstName}</div>
    </div>
  );
}

export default Profile;
