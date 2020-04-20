import React from "react";
import { useDispatch } from "react-redux";
import { createNote } from "../actions";
import PlusSvg from "./PlusSvg";

const NewNote = () => {
  const dispatch = useDispatch();

  const addNote = (event) => {
    event.preventDefault();
    const content = event.target.note.value;
    if (content) {
      event.target.note.value = "";
      dispatch(createNote(content));
    }
  };

  return (
    <form onSubmit={addNote}>
      <input
        name="note"
        type="text"
        className="input"
        placeholder="What do you need to do today?"
      />
      <button type="submit" className="to-do__add" id="add">
        <PlusSvg />
      </button>
    </form>
  );
};

export default NewNote;
