import React from "react";
import { useDispatch, useSelector } from "react-redux";
import { toggleImportance, removeNote } from "../actions";
import Note from "./Note";

const Notes = () => {
  const dispatch = useDispatch();
  const notes = useSelector((state) =>
    state.showAll ? state.notes : state.notes.filter((note) => note.important)
  );

  return (
    <ul className="list" id="list">
      {notes.map((note, i) => (
        <Note
          key={i}
          note={note}
          toggleImportance={() => dispatch(toggleImportance(note))}
          remove={() => dispatch(removeNote(note.id))}
        />
      ))}
    </ul>
  );
};

export default Notes;
