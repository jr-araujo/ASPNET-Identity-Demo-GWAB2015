using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebAppDemoIdentity_GWAB.Filters
{
    /// <summary>
    /// Esta customização foi devidamente autorizada pelo MVP :: Eduardo Pires
    /// Para maiores informações detalhes sobre a implementação, acesse: http://eduardopires.net.br/2014/08/asp-net-identity-tutorial-completo/
    /// </summary>
    public class ClaimsAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly string _claimType;
        private readonly string _claimValue;

        public ClaimsAuthorizeAttribute(string claimType, string claimValue)
        {
            this._claimType = claimType;
            this._claimValue = claimValue;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var identity = (ClaimsIdentity)httpContext.User.Identity;

            var claim = identity.Claims.FirstOrDefault(c => c.Type == _claimType);

            if (claim != null)
            {
                return claim.Value == _claimValue;
            }

            return false;
        }
    }
}
