import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";

export default function ErrorPage() {
  const navigate = useNavigate();

  const [time, setTime] = useState(10);

  useEffect(() => {
    const countdownInterval = setInterval(() => {
      setTime(time - 1);
    }, 1000);

    return () => {
      clearInterval(countdownInterval);
    };
  }, [time]);

  useEffect(() => {
    if (time === 0) {
      navigate(-1);
    }
  }, [time, navigate]);

  return (
    <>
      <div className="flex justify-center items-center h-screen ">
        <div id="error-page">
          <h1 className="lg:text-6xl mb-2 font-bold text-7xl text-blue-500">
            Oops!
          </h1>
          <p className="text-xl text-black">
            Sorry, an unexpected error has occurred.
          </p>
          <p className="text-3xl text-blue-500">Page Not Found!</p>
          <div className="mt-1">
            Redirected to the previous page in {time} seconds...
          </div>
        </div>
      </div>
    </>
  );
}
