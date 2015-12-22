using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace ArtGallery.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetDisplayName(this IIdentity identity)
        {
            return ((ClaimsIdentity)identity).FindFirst("DisplayName").Value;
        }

        public static string GetClaimValue(this IIdentity identity, string Name)
        {
            IEnumerable<Claim> Claims = ((ClaimsIdentity)identity).Claims;
            
            return Claims.Any(x => x.Type == Name) ? Claims.First(x => x.Type == Name).Value : string.Empty;
        }
    }
}