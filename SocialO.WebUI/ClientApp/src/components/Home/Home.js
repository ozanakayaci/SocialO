import { useEffect } from "react";

import { useNavigate } from "react-router-dom";

import { useSelector } from "react-redux";

import "./Home.css";

import Flow from "./Flow/Flow";
import PostInput from "./PostInput/PostInput";

function Home() {
  const navigate = useNavigate();

 

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
