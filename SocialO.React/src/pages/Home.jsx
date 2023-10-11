import Navbar from "../components/Navbar";
import PostModal from "../components/PostModal";

function Home() {
  return (
    <>
      {/* navbar */}
      <Navbar />
      {/* Modal */}
      <div className="flex justify-center flex-row items-center mt-10 md:mx-auto md:w-full md:max-w-md mx-2 border-b-2 pb-2 border-gray-300">
        <PostModal />
      </div>
      {/* Flow */}
    </>
  );
}

export default Home;
