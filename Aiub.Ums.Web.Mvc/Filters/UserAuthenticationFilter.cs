using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Aiub.Ums.Web.Mvc.Filters
{
    public class UserAuthentication: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["UserId"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    {"controller", "Account"},
                    {"action", "Login"}
                });
            }
            else
            {
                base.OnActionExecuting(filterContext);
            }
        }
    }
}