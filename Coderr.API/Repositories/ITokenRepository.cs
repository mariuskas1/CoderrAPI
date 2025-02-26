using Microsoft.AspNetCore.Identity;

namespace Coderr.API.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
