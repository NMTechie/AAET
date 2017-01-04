using System.Web;
using System.Web.Mvc;
using CAAAETConfigurationUI.Filters;
using CAAAETCommon;

namespace CAAAETConfigurationUI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new CAAAETAuthorizationFilter());
        }
    }
}