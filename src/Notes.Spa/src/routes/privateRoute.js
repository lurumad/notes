import React from "react";
import { Route } from "react-router-dom";
import { useSelector } from "react-redux";
import Login from "../components/Login";

const PrivateRoute = ({ component: Component, ...rest }) => {
  const user = useSelector((state) => state.user);
  return (
    <Route
      {...rest}
      render={(props) => (!user ? <Login /> : <Component {...props} />)}
    />
  );
};

export default PrivateRoute;
