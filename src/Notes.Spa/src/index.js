import React from "react";
import ReactDOM from "react-dom";
import "bootstrap/dist/css/bootstrap.min.css";
import "./index.css";
import { Provider } from "react-redux";
import store from "./stores/store";
import { BrowserRouter as Router } from "react-router-dom";
import Routes from "./routes/routes";
import OidcProvider from "./providers/OidcProvider";
import userManager from "./utils/userManager";

ReactDOM.render(
  <Provider store={store}>
    <OidcProvider store={store} userManager={userManager}>
      <Router>
        <Routes />
      </Router>
    </OidcProvider>
  </Provider>,
  document.getElementById("root")
);
