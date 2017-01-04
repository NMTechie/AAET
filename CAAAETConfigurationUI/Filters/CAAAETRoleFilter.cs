using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using CAAAETCommon.Helpers;

namespace CAAAETConfigurationUI.Filters
{
    public class CAAAETRoleFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            filterContext.ActionParameters["userRole"] = CommonHelper.GetApplicationRole(Roles.GetRolesForUser(HttpContext.Current.User.Identity.Name));
        }
    }
}