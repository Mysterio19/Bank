using System.Security.Claims;
using System.Security.Principal;

namespace Bank.Web.Extensions
{
    public static class UserExtensions
    {
        public static int GetId(this ClaimsPrincipal user)
        {
            return int.Parse(user.FindFirst(ClaimTypes.Sid).Value);
        }
    }
}