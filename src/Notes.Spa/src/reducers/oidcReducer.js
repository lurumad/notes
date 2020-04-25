import {
  USER_FOUND,
  SILENT_RENEW_ERROR,
  ACCESS_TOKEN_EXPIRED,
  ACCESS_TOKEN_EXPIRING,
  USER_SIGN_OUT,
  USER_UNLOADED,
} from "../actions";

const oidcReducer = (state = null, action) => {
  switch (action.type) {
    case USER_FOUND:
      console.log("user found reducer", action.payload);
      return action.payload;
    case SILENT_RENEW_ERROR:
      console.error("silent renew error", action.payload);
      return null;
    // case ACCESS_TOKEN_EXPIRED:
    //   console.log("access token expired");
    //   return null;
    // case ACCESS_TOKEN_EXPIRING:
    //   console.log("access token expiring");
    //   return null;
    case USER_SIGN_OUT:
      console.log("user signed out");
      return null;
    case USER_UNLOADED:
      console.log("session terminated");
      return null;
    default:
      return state;
  }
};

export default oidcReducer;
