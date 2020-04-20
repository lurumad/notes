import React, { useEffect, useState } from "react";
import userManager from "../utils/userManager";
import { Redirect } from "react-router-dom";

const Callback = () => {
  const [toHome, setToHome] = useState(false);
  useEffect(() => {
    async function completeSignin(){
      await userManager.signinRedirectCallback();
      setToHome(true);
    }

    completeSignin();
  }, []);
  return <>{toHome ? <Redirect to="/" /> : null}</>;
};

export default Callback;
