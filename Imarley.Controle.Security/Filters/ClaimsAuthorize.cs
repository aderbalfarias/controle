using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Imarley.Controle.Security.Filters
{
    public class ClaimsAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly string _claimName;
        private readonly string _claimValue;

        public ClaimsAuthorizeAttribute(string claimName, string claimValue)
        {
            _claimName = claimName;
            _claimValue = claimValue;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var identity = (ClaimsIdentity)httpContext.User.Identity;

            var claim = identity.Claims.FirstOrDefault(c => c.Type == _claimName);

            if (claim != null)
            {
                return claim.Value == _claimValue;
            }

            return false;
        }
    }
}
