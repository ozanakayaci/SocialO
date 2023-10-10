import Navbar from "../components/Navbar";
import PostModal from "../components/PostModal";

function Home() {
  return (
    <>
      <Navbar />
      <div className="flex justify-center align-middle flex-row items-center mt-10 md:mx-auto md:w-full md:max-w-md mx-2 border-b-2 pb-2 border-gray-300">
        <PostModal />
      </div>
    </>
  );
}

export default Home;
