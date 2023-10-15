import { Button, TextField } from "@mui/material";
import { useState } from "react";

function Settings() {
  const [image, setImage] = useState(null);

  function handleImage(event) {
    setImage(event.target.files);

    console.log(image);
  }

  return (
    <>
      <div className="flex justify-center flex-col w-full items-start mt-10  md:w-full md:max-w-md mx-2 pb-2 px-2">
        <div className="mt-4 w-full">
          <TextField
            className="w-1/2"
            id="outlined-multiline-flexible"
            label="Name"
            variant="outlined"
          />
        </div>
        <div className="mt-4 w-full">
          <TextField
            className="w-1/2"
            id="outlined-multiline-flexible"
            label="Surname"
            variant="outlined"
          />
        </div>
        <div className="mt-4 w-full">
          <TextField
            className="w-full"
            id="outlined-multiline-flexible"
            label="About"
            variant="outlined"
            multiline
            rows={4}
          />
        </div>
      </div>
    </>
  );
}

export default Settings;
