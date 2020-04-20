import { createStore, combineReducers, applyMiddleware } from "redux";
import thunk from "redux-thunk";
import { composeWithDevTools } from "redux-devtools-extension";
import noteReducer from "../reducers/noteReducer";
import filterReducer from "../reducers/filterReducer";
import crossCuttingReducer from "../reducers/crossCuttingReducer";
import oidcReducer from "../reducers/oidcReducer";

const reducer = combineReducers({
  notes: noteReducer,
  loading: crossCuttingReducer,
  showAll: filterReducer,
  user: oidcReducer,
});

const store = createStore(reducer, composeWithDevTools(applyMiddleware(thunk)));

export default store;
