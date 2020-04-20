import { USER_FOUND } from "../actions";

const oidcReducer = (state = null, action) => {
  switch (action.type) {
    case USER_FOUND:
      console.log("user found reducer", action.payload);
      return action.payload;
    default:
      return state;
  }
};

export default oidcReducer;
