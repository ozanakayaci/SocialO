import { useEffect, useState } from "react";
import ProfileCard from "../components/ProfileCard";
import { TextField } from "@mui/material";
import axios from "axios";

function Search() {
  const [searchText, setSearchText] = useState("");

  const [usersData, setUsersData] = useState([
    {
      id: -1,
      username: "undefined",
      about: "undefined",
      name: "undefined",
      followerCount: -1,
      followingCount: -1,
    },
  ]);

  useEffect(() => {
    const delayDebounceFn = setTimeout(
      () => {
        if (searchText.length > 0) {
          axios
            .get(
              `http://localhost:5211/api/Users/SearchByName?searchedString=${searchText}`
            )
            .then((response) => {
              setUsersData(response.data);
            });
        }
      },
      searchText.length == 1 ? 100 : 1000
    );

    return () => clearTimeout(delayDebounceFn);
  }, [searchText]);

  return (
    <>
      <div className="px-4 flex justify-center items-center mt-8 w-full md:max-w-screen-sm h-16 rounded-xl border-gray-100 bg-white">
        <TextField
          className="w-full border border-blue-500 focus:outline-none focus:ring-1 focus:ring-blue-400 focus:border-transparent"
          id="outlined-basic"
          label="Search"
          variant="outlined"
          placeholder="Username "
          autoFocus
          value={searchText}
          onChange={(e) => {
            setSearchText(e.target.value);
          }}
        />
      </div>

      {searchText != "" && usersData[0].id != -1 ? (
        usersData.map((user, i) => <ProfileCard key={i} user={user} />)
      ) : (
        <div className="mt-20 text-2xl md:text-5xl font-semibold text-blue-500 flex flex-row items-center h-36">
          <div className=" h-12 w-12 flex items-center justify-center rounded-lg fill-blue-500  text-blue-500 mt-1 md:mt-2 ">
            <svg
              xmlns="http://www.w3.org/2000/svg"
              className="h-6 md:h-10 w-6 md:w-10"
              viewBox="0 0 24 24"
            >
              <path d="M 9 2 C 5.1458514 2 2 5.1458514 2 9 C 2 12.854149 5.1458514 16 9 16 C 10.747998 16 12.345009 15.348024 13.574219 14.28125 L 14 14.707031 L 14 16 L 20 22 L 22 20 L 16 14 L 14.707031 14 L 14.28125 13.574219 C 15.348024 12.345009 16 10.747998 16 9 C 16 5.1458514 12.854149 2 9 2 z M 9 4 C 11.773268 4 14 6.2267316 14 9 C 14 11.773268 11.773268 14 9 14 C 6.2267316 14 4 11.773268 4 9 C 4 6.2267316 6.2267316 4 9 4 z"></path>
            </svg>
          </div>
          Start Searching...
        </div>
      )}
    </>
  );
}

export default Search;
