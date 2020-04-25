import React, { useEffect } from "react";
import { useDispatch } from "react-redux";
import {
  userFound,
  silentRenewError,
  accessTokenExpired,
  accessTokenExpiring,
  userUnloaded,
  userSignedOut,
} from "../actions";

const OidcProvider = (props) => {
  const dispatch = useDispatch();
  const userManager = props.userManager;
  useEffect(() => {
    const onUserLoaded = (user) => {
      dispatch(userFound(user));
    };

    const onSilentRenewError = (error) => {
      dispatch(silentRenewError(error));
    };

    const onAccessTokenExpired = () => {
      dispatch(accessTokenExpired());
    };

    const onAccessTokenExpiring = () => {
      dispatch(accessTokenExpiring());
    };

    const onUserUnloaded = () => {
      dispatch(userUnloaded());
    };

    const onUserSignedOut = () => {
      dispatch(userSignedOut());
    };

    userManager.events.addUserLoaded(onUserLoaded);
    userManager.events.addSilentRenewError(onSilentRenewError);
    userManager.events.addAccessTokenExpired(onAccessTokenExpired);
    userManager.events.addAccessTokenExpiring(onAccessTokenExpiring);
    userManager.events.addUserUnloaded(onUserUnloaded);
    userManager.events.addUserSignedOut(onUserSignedOut);

    return () => {
      userManager.events.removeUserLoaded(onUserLoaded);
      userManager.events.removeUserLoaded(onSilentRenewError);
      userManager.events.removeUserLoaded(onAccessTokenExpired);
      userManager.events.removeUserLoaded(onAccessTokenExpiring);
      userManager.events.removeUserLoaded(onUserUnloaded);
      userManager.events.removeUserLoaded(onUserSignedOut);
    };
  }, [userManager, dispatch]);

  return <>{props.children}</>;
};

export default OidcProvider;
