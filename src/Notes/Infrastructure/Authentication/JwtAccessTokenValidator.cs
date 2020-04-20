using IdentityModel;
using IdentityModel.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Notes.Infrastructure.Authentication
{
    public class JwtAccessTokenValidator : IAccessTokenValidator
    {
        private const string BEARER = "Bearer ";
        private readonly IHttpClientFactory clientFactory;
        private readonly JwtSettings jwtSecurity;

        public JwtAccessTokenValidator(IHttpClientFactory clientFactory, JwtSettings jwtSecurity)
        {
            this.clientFactory = clientFactory ?? throw new System.ArgumentNullException(nameof(clientFactory));
            this.jwtSecurity = jwtSecurity ?? throw new System.ArgumentNullException(nameof(jwtSecurity));
        }

        public async Task<ClaimsPrincipal> Validate(HttpRequest request)
        {
            string token = string.Empty;
            string authorization = request.Headers[HeaderNames.Authorization];

            if (string.IsNullOrWhiteSpace(authorization))
            {
                return NotAuthenticated();
            }

            if (authorization.StartsWith(BEARER, System.StringComparison.OrdinalIgnoreCase))
            {
                token = authorization.Substring(BEARER.Length).Trim();
            }

            if (string.IsNullOrWhiteSpace(token))
            {
                return NotAuthenticated();
            }

            return await ValidateJwt(token);
        }


        private async Task<ClaimsPrincipal> ValidateJwt(string jwt)
        {
            var disco = await clientFactory.CreateClient().GetDiscoveryDocumentAsync(jwtSecurity.Authority);

            var keys = new List<SecurityKey>();

            foreach (var webKey in disco.KeySet.Keys)
            {
                var e = Base64Url.Decode(webKey.E);
                var n = Base64Url.Decode(webKey.N);

                var key = new RsaSecurityKey(new RSAParameters { Exponent = e, Modulus = n })
                {
                    KeyId = webKey.Kid
                };

                keys.Add(key);
            }

            var parameters = new TokenValidationParameters
            {
                ValidIssuer = disco.Issuer,
                ValidAudience = jwtSecurity.Audience,
                IssuerSigningKeys = keys,

                NameClaimType = JwtClaimTypes.Name,
                RoleClaimType = JwtClaimTypes.Role
            };

            var handler = new JwtSecurityTokenHandler();
            handler.InboundClaimTypeMap.Clear();

            return handler.ValidateToken(jwt, parameters, out var _);
        }

        private ClaimsPrincipal NotAuthenticated()
        {
            return new ClaimsPrincipal(new ClaimsIdentity());
        }
    }
}
