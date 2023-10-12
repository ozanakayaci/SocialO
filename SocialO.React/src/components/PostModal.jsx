import { FocusTrap } from "@headlessui/react";
import { Avatar, Button, Modal, TextField } from "@mui/material";
import { useState } from "react";

function PostModal() {
  const [open, setOpen] = useState(false);

  function handlePost() {
    
  }

  const handleOpen = () => setOpen(true);
  const handleClose = () => setOpen(false);

  return (
    <>
      <Avatar
        alt="Remy Sharp"
        src="https://img.freepik.com/premium-vector/man-avatar-profile-picture-vector-illustration_268834-538.jpg"
        className="mr-2"
      />
      <div
        onClick={handleOpen}
        id="filled-multiline-flexible"
        className="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm  placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600  sm:text-sm sm:leading-6 "
      >
        <span className="w-full h-full p-4">What&apos;s on your mind?</span>
      </div>
      <div>
        <div className="flex justify-end ml-2">
          <Button
            disabled
            type="submit"
            className="flex justify-center rounded-md bg-blue-500  px-3 py-1.5 text-sm font-semibold leading-6 text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
            variant="contained"
            onClick={handlePost}
          >
            Post
          </Button>
        </div>
      </div>

      <Modal
        open={open}
        onClose={handleClose}
        aria-labelledby="modal-modal-title"
        aria-describedby="modal-modal-description"
        className="flex justify-center flex-row items-center mx-auto w-full md:max-w-md border-b-2 pb-2 border-gray-300"
      >
        <div className="absolute w-full border-0 rounded-2xl bg-white p-5 mx-2">
          <div className="flex flex-row items-center">
            <Avatar
              alt="Remy Sharp"
              src="https://img.freepik.com/premium-vector/man-avatar-profile-picture-vector-illustration_268834-538.jpg"
              className="mr-2"
              sx={{ width: 30, height: 30 }}
            />
            Username
          </div>
          <div className="mt-2">
            <FocusTrap disableRestoreFocus>
              <TextField
                id="outlined-textarea"
                placeholder="What's on your mind?"
                multiline
                className="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm  placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600  sm:text-sm sm:leading-6 "
                inputProps={{ maxLength: 240 }}
                autoFocus
              />
            </FocusTrap>
            <div className="mt-4">
              <div className="flex justify-end ml-2">
                <Button
                  type="submit"
                  className="flex justify-center rounded-md bg-blue-500  px-3 py-1.5 text-sm font-semibold leading-6 text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
                  variant="contained"
                  onClick={handlePost}
                >
                  Post
                </Button>
              </div>
            </div>
          </div>
        </div>
      </Modal>

      {/* <Transition appear show={isOpen} as={Fragment}>
        <Dialog as="div" className="relative z-10" onClose={handlePost}>
          <Transition.Child
            as={Fragment}
            enter="ease-out duration-300"
            enterFrom="opacity-0"
            enterTo="opacity-100"
            leave="ease-in duration-200"
            leaveFrom="opacity-100"
            leaveTo="opacity-0"
          >
            <div className="fixed inset-0 bg-black bg-opacity-25" />
          </Transition.Child>

          <div className="fixed inset-0 overflow-y-auto">
            <div className="flex min-h-full items-center justify-center p-4 text-center">
              <Transition.Child
                as={Fragment}
                enter="ease-out duration-300"
                enterFrom="opacity-0 scale-95"
                enterTo="opacity-100 scale-100"
                leave="ease-in duration-200"
                leaveFrom="opacity-100 scale-100"
                leaveTo="opacity-0 scale-95"
              >
                <Dialog.Panel className="w-full max-w-md transform overflow-hidden rounded-2xl bg-white p-6 text-left  shadow-xl transition-all">
                  <Dialog.Title
                    as="h3"
                    className="text-lg font-medium leading-6 text-gray-900"
                  >
                    <div className="flex flex-row items-center">
                      <Avatar
                        alt="Remy Sharp"
                        src="/static/images/avatar/1.jpg"
                        className="mr-2"
                        sx={{ width: 30, height: 30 }}
                      />
                      Username
                    </div>
                  </Dialog.Title>
                  <div className="mt-2">
                    <TextField
                      id="outlined-textarea"
                      placeholder="What's on your mind?"
                      multiline
                      className="block w-full h-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm  placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600  sm:text-sm sm:leading-6 "
                      inputProps={{ maxLength: 240 }}
                    />

                    <div className="mt-4">
                      <div className="flex justify-end ml-2">
                        <Button
                          type="submit"
                          className="flex justify-center rounded-md bg-blue-500  px-3 py-1.5 text-sm font-semibold leading-6 text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
                          variant="contained"
                          onClick={handlePost}
                        >
                          Post
                        </Button>
                      </div>
                    </div>
                  </div>
                </Dialog.Panel>
              </Transition.Child>
            </div>
          </div>
        </Dialog>
      </Transition> */}
    </>
  );
}

export default PostModal;
