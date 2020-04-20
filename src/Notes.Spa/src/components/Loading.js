import React from "react";
import { useSelector } from "react-redux";

const Loading = () => {
  const loading = useSelector((state) => state.loading);

  return loading ? <div className="loading">Loading&#8230;</div> : <></>;
};

export default Loading;
