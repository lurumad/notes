import {
  NEW_NOTE,
  TOGGLE_IMPORTANCE,
  REMOVE_NOTE,
  REMOVE_ALL_NOTES,
  INIT_NOTES,
} from "../actions";

const noteReducer = (state = [], action) => {
  switch (action.type) {
    case NEW_NOTE:
      return state.concat(action.data);
    case TOGGLE_IMPORTANCE:
      return state.map((note) =>
        note.id !== action.data.id ? note : action.data
      );
    case REMOVE_NOTE:
      return state.filter((note) => note.id !== action.id);
    case REMOVE_ALL_NOTES:
      return action.data;
    case INIT_NOTES:
      return action.data;
    default:
      return state;
  }
};

export default noteReducer;
