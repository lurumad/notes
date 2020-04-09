import React from 'react'
import { useDispatch} from 'react-redux'
import { createNote } from '../reducers/noteReducer'

const NewNote = () => {
    const dispatch = useDispatch()

    const addNote = (event) => {
        event.preventDefault()
        const content = event.target.note.value
        event.target.note.value = ''
        dispatch(createNote(content))
    }

    return (
        <form onSubmit={addNote}>
            <input
                name="note"
                type="text"
                className="input"
                placeholder="What do you need to do today?" />
            <button type="submit" className="to-do__add" id="add">
                <svg className="to-do__icon">
                    <use href="#plus">
                    </use>
                </svg>
            </button>
        </form>
    )
}

export default NewNote