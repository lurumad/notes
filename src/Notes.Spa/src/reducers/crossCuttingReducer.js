import { LOADING, LOADED } from "../actions";

const crossCuttingReducer = (state = [], action) => {
  switch (action.type) {
    case LOADING:
      return action.loading;
    case LOADED:
      return action.loading;
    default:
      return state;
  }
};

export default crossCuttingReducer;
