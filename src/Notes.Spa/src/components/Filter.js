import React from "react";
import { useDispatch, useSelector } from "react-redux";
import { setFilter } from "../actions";
import Button from "./Button";

const Filter = () => {
  const dispatch = useDispatch();
  const showAll = useSelector((state) => state.showAll);
  return (
    <Button
      className="btn"
      id="show"
      text={showAll ? "important" : "all"}
      onClick={() => dispatch(setFilter(!showAll))}
    />
  );
};

export default Filter;
