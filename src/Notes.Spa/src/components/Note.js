import React from 'react'

const Note = ({ note, toggleImportance }) => {
    const important = note.important
        ? 'list__circle__important' : 'list__circle';

    return (
        <li className={"list__item"}><span className={important}></span>
            <div className="list__text" onClick={toggleImportance}>{note.content}</div>
        </li>
    )
}

export default Note