using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Linq;
using System.Diagnostics;

namespace ApplicationBuildValidator.UserAccessControlXML
{
    public class UserAccessControlValidator
    {
        public int ValidateMenuSchema()
        {
            int retVal = 1;
            try
            {                
                XDocument menuCntrlXML = XDocument.Load("UserAccessControl1.xml");
                String msg = string.Empty;
                var roles = menuCntrlXML.Descendants("role");

                foreach (var role in roles)
                {
                    var menus = role.Elements();
                    foreach (var menu in menus)
                    {
                        ValidateMenu(menu);
                    }
                }
            }
            catch (Exception ex)
            {
                retVal = ex.Message.Length;
            }
            return retVal;
        }
        private void ValidateMenu(XElement menu)
        {
            bool isLeaf = Convert.ToBoolean(menu.Attribute("IsLeaf").Value);
            var menuText = menu.Attribute("MenuText");
            if (menuText == null)
            {
                throw new Exception("Menu defined without text");
            }
            if (isLeaf)
            {
                var actionName = menu.Attribute("ActionName");
                var controllerName = menu.Attribute("ControllerName");
                var screen = menu.Attribute("Screen");

                if (actionName == null || controllerName == null)
                {
                    throw new Exception("Menu created without web link");
                }
            }
            else
            {
                var subMenus = menu.Elements();
                if (subMenus.Count() == 0)
                {
                    throw new Exception("No submenu defined under non leaf menu");
                }
                foreach (var submenu in subMenus)
                {
                    ValidateMenu(submenu);
                }
            }
        }
    }
}
