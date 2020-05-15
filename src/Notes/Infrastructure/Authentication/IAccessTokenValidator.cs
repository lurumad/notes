using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Notes.Infrastructure.Authentication
{
    public interface IAccessTokenValidator
    {
        public Task<ClaimsPrincipal> Validate(HttpRequest request);
    }
}
