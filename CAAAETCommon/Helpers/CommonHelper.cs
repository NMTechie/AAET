using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CAAAETCommon.Helpers
{
    public class CommonHelper
    {
        public static string GetApplicationRole(string [] loggedInUserRole)
        {
            string appRoles = string.Empty;

            appRoles = ConfigurationManager.AppSettings[CAAAETAppConstants.roleADMIN];
            if (loggedInUserRole.Any(role => appRoles.Split(',').Any(approle => approle.Trim().ToLower().Equals(role.Trim().ToLower()))))
            {
                return CAAAETAppConstants.roleADMIN;
            }
            appRoles = ConfigurationManager.AppSettings[CAAAETAppConstants.roleSTAFF];
            if (loggedInUserRole.Any(role => appRoles.Split(',').Any(approle => approle.Trim().ToLower().Equals(role.Trim().ToLower()))))
            {
                return CAAAETAppConstants.roleSTAFF;
            }
            return string.Empty;
        }
        public static bool IsUserAuthorized(string[] loggedInUserRole,string[] validRolesInApplication)
        {
            return loggedInUserRole.Any(role => validRolesInApplication.Any(validRole => validRole.Trim().ToLower().Equals(role.Trim().ToLower())));
        }        
    }
}
