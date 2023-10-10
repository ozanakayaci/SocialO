import { TextField } from "@mui/material";

function Home() {
  return (
    <div className="m-11">
      <TextField
        id="outlined-textarea"
        label="Multiline Placeholder"
        placeholder="Placeholder"
        multiline
      />
    </div>
  );
}

export default Home;
