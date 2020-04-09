const filterReducer = (state = [], action) => {
    switch(action.type){
        case SHOW_ALL_NOTES:
            return action.showAll
        default:
            return state
    }
}

export const SHOW_ALL_NOTES = 'SHOW_ALL_NOTES'

export const setFilter = (value) => {
    return {
        type: SHOW_ALL_NOTES,
        showAll: value
    }
}

export default filterReducer