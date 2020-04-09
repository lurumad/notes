import notesService from '../services/notes'

const noteReducer = (state = [], action) => {
    switch (action.type) {
        case NEW_NOTE:
            return state.concat(action.data)
        case TOGGLE_IMPORTANCE:
            return state.map(note => note.id != action.data.id ? note : action.data)
        case INIT_NOTES:
            return action.data
        default:
            return state
    }
}

export const NEW_NOTE = 'NEW_NOTE'

export const createNote = (content) => {
    return async dispatch => {
        const note = {
            content,
            important: true
        }
        const newNote = await notesService.create(note)
        dispatch({
            type: NEW_NOTE,
            data: newNote
        })
    }
}

export const TOGGLE_IMPORTANCE = 'TOGGLE_IMPORTANCE'

export const toggleImportance = (note) => {
    return async dispatch => {
        const changedNote = { ...note, important: !note.important }
        await notesService.update(changedNote.id, changedNote)
        dispatch({
            type: TOGGLE_IMPORTANCE,
            data: changedNote
        })
    }
}

export const INIT_NOTES = 'INIT_NOTES'

export const initializeNotes = () => {
    return async dispatch => {
        const notes = await notesService.getAll()
        dispatch({
            type: INIT_NOTES,
            data: notes
        })
    }
}

export default noteReducer