
import "./Home.css";

import Flow from "./Flow/Flow";
import PostInput from "./PostInput/PostInput";

function Home() {
  

  return (
    <div>
      <div className="home-main">
        <div>
          <PostInput />
        </div>
        <div className="flow-main">
          <Flow />
        </div>
      </div>
    </div>
  );
}

export default Home;
