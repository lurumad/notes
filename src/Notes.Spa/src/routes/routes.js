import React from "react";
import { Switch, Route } from "react-router-dom";
import PrivateRoute from "./privateRoute";
import Callback from "../components/Callback";
import SilentRenew from "../components/SilentRenew";
import Login from "../components/Login";
import App from "../App";

const Routes = () => {
  return (
    <Switch>
      <Route path="/login" component={Login} />
      <Route path="/signin-oidc" component={Callback} />
      <Route path="/silent-renew" component={SilentRenew} />
      <PrivateRoute path="/" component={App} />
    </Switch>
  );
};

export default Routes;
