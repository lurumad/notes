import React from "react";

const Notification = ({ message }) => {
  if (message) {
    return <div className="error">{message}</div>;
  }

  return null;
};

export default Notification;
