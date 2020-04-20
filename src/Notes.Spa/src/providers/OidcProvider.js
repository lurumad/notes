import React, { useEffect } from "react";
import { useDispatch } from "react-redux";
import { userFound } from "../actions";

const OidcProvider = (props) => {
  const dispatch = useDispatch();
  const userManager = props.userManager;
  useEffect(() => {
    const onUserLoaded = (user) => {
      console.log("userFound");
      dispatch(userFound(user));
    };

    userManager.events.addUserLoaded(onUserLoaded);

    return () => {
      userManager.events.removeUserLoaded(onUserLoaded);
    };
  }, [userManager, dispatch]);

  return <>{props.children}</>;
};

export default OidcProvider;
