import React from "react";

import { useState } from "react";

import { Link } from "react-router-dom";

//css
import "./Search.css";

function Search() {
  const [filteredWord, setFilteredWord] = useState("");

  let handleChange = (e) => {
    setFilteredWord(e.target.value);
  };

  return (
    <div className="search-container">
      <input
        type="text"
        name="search"
        placeholder="Search..."
        className="search-input"
        onChange={handleChange}
      />
      <Link className="search-btn" to={`/events/search/${filteredWord}`}>
        <i className="fas fa-search"></i>
      </Link>
    </div>
  );
}

export default Search;
