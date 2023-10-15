import { Button, TextField } from "@mui/material";
import { DatePicker } from "@mui/x-date-pickers";
import axios from "axios";
import dayjs from "dayjs";
import { useEffect, useState } from "react";
import { toast } from "react-toastify";

function Settings() {
  const [userId] = useState(localStorage.getItem("userId"));
  const [userProfile, setUserProfile] = useState({});

  const [isLoading, setIsLoading] = useState(true);

  const [firstName, setFirstName] = useState(userProfile.firstName);
  const [lastName, setLastName] = useState(userProfile.lastName);
  const [birthdate, setBirthdate] = useState(userProfile.dateOfBirth);
  const [about, setAbout] = useState(userProfile.about);

  useEffect(() => {
    setIsLoading(true);
    axios
      .get(`https://localhost:7298/api/UserProfile?userId=${userId}`)
      .then((response) => {
        setUserProfile(response.data);
        setIsLoading(false);
        setFirstName(response.data.firstName);
        setLastName(response.data.lastName);
        setBirthdate(response.data.dateOfBirth);
        setAbout(response.data.about);
      });
  }, []);

  const handleSubmit = (e) => {
    e.preventDefault();
    const data = {
      firstName: firstName,
      lastName: lastName,
      gender: null,
      dateOfBirth: birthdate,
      about: about,
      userId: userId,
    };

    console.log(data);
    axios
      .put("https://localhost:7298/api/UserProfile", data, {
        headers: {
          "Content-Type": "application/json",
        },
      })
      .then((response) => {
        if (response.status == 200) {
          toast("Profile updated successfully..", {
            position: "bottom-center",
            autoClose: 5000,
            hideProgressBar: false,
            closeOnClick: true,
            pauseOnHover: true,
            draggable: true,
            progress: undefined,
            theme: "light",
          });
        }
      });
  };

  return (
    <>
      {isLoading ? (
        <div>loading</div>
      ) : (
        <form
          onSubmit={(e) => handleSubmit(e)}
          className="flex justify-center flex-col w-full items-start mt-8  md:w-full md:max-w-md mx-2 pb-2 px-2"
        >
          <div className="w-full flex flex-row justify-center mb-5 md:mb-10 text-blue-500 text-2xl md:text-3xl">
            Edit your profile
          </div>
          <div className="w-full flex flex-row justify-between">
            <TextField
              className="w-6/12"
              id="outlined-multiline-flexible"
              label="Name"
              variant="outlined"
              defaultValue={userProfile.firstName}
              onChange={(e) => setFirstName(e.target.value)}
            />
            <TextField
              className=" w-5/12"
              id="outlined-multiline-flexible"
              label="Surname"
              variant="outlined"
              defaultValue={userProfile.lastName}
              onChange={(e) => setLastName(e.target.value)}
            />
          </div>
          <div className="mt-4 w-full flex flex-row justify-start">
            <DatePicker
              className="w-1/2"
              label="Birthdate"
              value={dayjs(userProfile.dateOfBirth)}
              onChange={(newValue) => setBirthdate(newValue)}
            />
          </div>
          <div className="mt-4 w-full flex flex-row justify-around">
            <TextField
              defaultValue={userProfile.about}
              className="w-full"
              id="outlined-multiline-flexible"
              label="About"
              variant="outlined"
              multiline
              rows={4}
              onChange={(e) => setAbout(e.target.value)}
            />
          </div>
          <div className="mt-4">
            <Button variant="outlined" type="submit">
              Update
            </Button>
          </div>
        </form>
      )}
    </>
  );
}

export default Settings;
