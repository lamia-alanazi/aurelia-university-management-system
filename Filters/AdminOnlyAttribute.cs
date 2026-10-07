using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace lamia12771.Filters
{
    public class AdminOnlyAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(
            HttpContextBase httpContext)
        {
            if (httpContext == null)
            {
                return false;
            }

            object adminSession =
                httpContext.Session["IsAdmin"];

            return adminSession is bool
                && (bool)adminSession;
        }


        protected override void HandleUnauthorizedRequest(
            AuthorizationContext filterContext)
        {
            filterContext.Result =
                new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new
                        {
                            controller = "Admin",
                            action = "Login"
                        }
                    )
                );
        }
    }
}