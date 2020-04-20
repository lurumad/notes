import React, { useEffect } from "react";
import userManager from "../utils/userManager";

const Login = () => {
  useEffect(() => {
    userManager.signinRedirect();
  }, []);

  return <></>;
};

export default Login;
