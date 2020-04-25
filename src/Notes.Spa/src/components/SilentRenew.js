import React, { useEffect } from "react";
import userManager from "../utils/userManager";

const SilentRenew = () => {
  useEffect(() => {
    async function silentRenew() {
      await userManager.signinSilentCallback();
    }

    silentRenew();
  }, []);

  return <></>;
};

export default SilentRenew;
