import { UserManager } from "oidc-client";

const clientId = "interactive.public.short";
const authority = "http://localhost:5000";
const scope = "openid profile api";

const settings = {
  authority,
  client_id: clientId,
  redirect_uri: `${window.location.protocol}//${window.location.host}/signin-oidc`,
  post_logout_redirect_uri: `${window.location.protocol}//${window.location.host}`,
  automaticSlientRenew: true,
  loadUserInfo: false,
  response_type: "code",
  scope,
};

const userManager = new UserManager(settings);

export default userManager;
