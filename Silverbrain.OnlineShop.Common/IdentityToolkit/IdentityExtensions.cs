using System;
using System.Globalization;
using System.Security.Claims;
using System.Security.Principal;

namespace Silverbrain.OnlineShop.Common.IdentityToolkit
{
    public static class IdentityExtensions
    {
        public static T GetUserId<T>(this IIdentity identity) where T : IConvertible
        {
            var firstValue = identity?.GetUserClaimValue(ClaimTypes.NameIdentifier);
            return firstValue != null
                ? (T)Convert.ChangeType(firstValue, typeof(T), CultureInfo.InvariantCulture)
                : default;
        }

        public static string GetUserId(this IIdentity identity)
        {
            return "0a0fc099-5265-46a3-a11b-ffa70e50adab0a0fc099-5265-46a3-a11b-ffa70e50adab";
            //return identity?.GetUserClaimValue(ClaimTypes.NameIdentifier);
        }

        public static string GetUserClaimValue(this IIdentity identity, string claimType)
        {
            var identity1 = identity as ClaimsIdentity;
            return identity1?.FindFirstValue(claimType);
        }

        public static string FindFirstValue(this ClaimsIdentity identity, string claimType)
        {
            return identity?.FindFirst(claimType)?.Value;
        }
    }
}