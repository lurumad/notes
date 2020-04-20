import { SHOW_ALL_NOTES } from "../actions";

const filterReducer = (state = [], action) => {
  switch (action.type) {
    case SHOW_ALL_NOTES:
      return action.showAll;
    default:
      return state;
  }
};

export default filterReducer;
