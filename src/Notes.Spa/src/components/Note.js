import React from "react";
import {
  TrashFill,
  ExclamationCircleFill,
  ExclamationCircle,
} from "react-bootstrap-icons";

const Note = ({ note, toggleImportance, remove }) => {
  const important = note.important ? "list__circle__important" : "list__circle";

  return (
    <li className={"list__item"}>
      <div className="d-flex align-center">
        {note.important ? (
          <ExclamationCircleFill className={important} />
        ) : (
          <ExclamationCircle className={important} />
        )}
        <div className="list__text" onClick={toggleImportance}>
          {note.content}
        </div>
      </div>
      <TrashFill className="list__icon" onClick={remove} />
    </li>
  );
};

export default Note;
