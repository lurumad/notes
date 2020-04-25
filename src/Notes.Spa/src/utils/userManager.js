import { UserManager } from "oidc-client";

const clientId = "interactive.public.short";
const authority = "https://demo.identityserver.io";
const scope = "openid profile api";

const settings = {
  authority,
  client_id: clientId,
  redirect_uri: `${window.location.protocol}//${window.location.host}/signin-oidc`,
  post_logout_redirect_uri: `${window.location.protocol}//${window.location.host}`,
  silent_redirect_uri: `${window.location.protocol}//${window.location.host}/silent-renew`,
  automaticSilentRenew: true,
  loadUserInfo: false,
  response_type: "code",
  scope,
};

console.log("oidc settings", settings);

const userManager = new UserManager(settings);

export default userManager;
