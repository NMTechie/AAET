using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CAAAETCommon.Helpers;
using CAAAETCommon;


namespace CAAAETConfigurationUI.Filters
{
    [AttributeUsage(AttributeTargets.Method,AllowMultiple=true,Inherited=false)]
    public class CAAAETAuthorizationFilter : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool isAuthorized = false;
            if (httpContext.User.Identity.IsAuthenticated)
            {
                var roles = GetAuthorizedRoles();                
                var userRoles = System.Web.Security.Roles.GetRolesForUser(HttpContext.Current.User.Identity.Name);
                if (roles != null && roles.Count() > 0 && userRoles != null && userRoles.Count() > 0)
                {
                    isAuthorized = CommonHelper.IsUserAuthorized(userRoles, roles);
                }
            }
            return isAuthorized;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
            //filterContext.Result = new RedirectResult("~/Home/Unauthorized");
        }

        private string[] GetAuthorizedRoles() 
        {
            string[] roles = null;
            var appSettings = ConfigurationManager.AppSettings[CAAAETAppConstants.roleADMIN];
            if (!string.IsNullOrEmpty(appSettings))
            {
                appSettings = appSettings + "," + ConfigurationManager.AppSettings[CAAAETAppConstants.roleSTAFF];
            }
            else
            {
                appSettings = ConfigurationManager.AppSettings[CAAAETAppConstants.roleSTAFF];
            }
            if (!string.IsNullOrEmpty(appSettings)) 
            {                 
                roles = appSettings.Split(','); 
            }
            return roles;
        }
    }
}