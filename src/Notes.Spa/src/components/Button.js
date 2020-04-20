import React from "react";

const Button = ({ id, className, text, onClick }) => {
  return (
    <button className={className} id={id} onClick={onClick}>
      {text}
    </button>
  );
};

export default Button;
