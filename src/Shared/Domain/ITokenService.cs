using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Shared.Domain
{
    public interface ITokenService
    {
        Task<string> CreateToken(IdentityUser user);
    }
}