import React, { useEffect } from "react";
import userManager from "../utils/userManager";

const Login = () => {
  useEffect(() => {
    userManager.signinRedirect();
  }, []);

  useEffect(() => {
    async function completeSigninRedirect() {
      await userManager.signinRedirect();
    }

    completeSigninRedirect();
  }, []);

  return <></>;
};

export default Login;
