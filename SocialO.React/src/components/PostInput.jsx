import { Button, TextField } from "@mui/material";

function PostInput() {
  return (
    <>
      <TextField
        className="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm  placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600  sm:text-sm sm:leading-6 "
        id="outlined-textarea"
        label="What's on your mind?"
        multiline
      />
      <div className="flex justify-end mt-2">
        <Button
          type="submit"
          className="flex justify-center rounded-md bg-blue-500  px-3 py-1.5 text-sm font-semibold leading-6 text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
          variant="contained"
        >
          Post
        </Button>
      </div>
    </>
  );
}

export default PostInput;
