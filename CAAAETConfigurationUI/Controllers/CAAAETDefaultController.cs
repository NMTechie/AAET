using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using CAAAETConfigurationUI.Filters;
using CAAAETCommon;
using CAAAETCommon.DataTransferObjects;
using CAAAETBusinessLayer.Interface.UI;
using CAAAETBusinessLayer;
using SimpleInjector.Integration.Web.Mvc;

namespace CAAAETConfigurationUI.Controllers
{
    public class CAAAETDefaultController : Controller
    {
        IBLServiceLocator _blServiceLocator;
        public CAAAETDefaultController(IBLServiceLocator blServiceLocator)
        {
            _blServiceLocator = blServiceLocator;
        }
        [CAAAETRoleFilter(Order=1)]        
        public ActionResult Index(string userRole)
        {            
            IUserAccessControlBAL cntrlObj = _blServiceLocator.GetUserBLServiceLocator((DependencyResolver.Current as SimpleInjectorDependencyResolver).Container);
            List<MenuItem> menus = cntrlObj.GetMenuForUser(userRole);
            return View(menus);
        }

        public ActionResult ShowResult()
        {
            return View();
        }

        public ActionResult Test()
        {
            return View();
        }
    }
}
