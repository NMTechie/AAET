using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using CAAAETDataAccessLayer.Interface.UI;
using CAAAETCommon;
using CAAAETCommon.DataTransferObjects;

namespace CAAAETDataAccessLayer.UI
{
    public class UserAccessControlDAL : IUserAccessControlDAL
    {
        public List<MenuItem> GetRoleNodeXML(string role)
        {
            XDocument userXML = GetResourceXMLFile(CAAAETAppConstants.XMLFileName);
            var roleElement = from element in userXML.Root.Elements("role")
                    where element.Attribute("name").Value == role
                              select element;
            return GenerateMenu(roleElement.First());           
        }
        private XDocument GetResourceXMLFile(string filename)
        {
            string result = string.Empty;
            XDocument userXML;

            using (Stream stream = this.GetType().Assembly.
                       GetManifestResourceStream("CAAAETDataAccessLayer.Menudata." + filename))
            {
                userXML = XDocument.Load(stream);
            }
            return userXML;
        }
        private List<MenuItem> GenerateMenu(XElement roleElement)
        {
            List<MenuItem> menu = new List<MenuItem>();
            foreach (XElement mainMenuItem in roleElement.Elements("menu"))
            {
                MenuItem item = new MenuItem();
                item.MenuText = mainMenuItem.Attribute("MenuText").Value;
                if (mainMenuItem.Attribute("IsLeaf").Value.Trim().ToUpper() == "FALSE")
                {
                    item.IsSubMenu = true;
                    BuildSubMenu(mainMenuItem,item);
                }
                else if (mainMenuItem.Attribute("IsLeaf").Value.Trim().ToUpper() == "TRUE")
                {
                    item.IsSubMenu = false;
                    item.ActionName = mainMenuItem.Attribute("ActionName").Value;
                    item.ControllerName = mainMenuItem.Attribute("ControllerName").Value;
                    item.Screen = mainMenuItem.Attribute("Screen").Value;
                }
                menu.Add(item);
            }
            return menu;
        }
        private void BuildSubMenu(XElement mainMenuItem,MenuItem parentItem)
        {            
            foreach (XElement item in mainMenuItem.Elements("menu"))
            {
                MenuItem childMenuItem = new MenuItem();
                childMenuItem.MenuText = item.Attribute("MenuText").Value;
                if (item.Attribute("IsLeaf").Value.Trim().ToUpper() == "FALSE")
                {
                    childMenuItem.IsSubMenu = true;
                    parentItem.AddSubMenuItem(childMenuItem);
                    BuildSubMenu(item,childMenuItem);
                }
                else if (item.Attribute("IsLeaf").Value.Trim().ToUpper() == "TRUE")
                {
                    childMenuItem.IsSubMenu = false;
                    childMenuItem.ActionName = item.Attribute("ActionName").Value;
                    childMenuItem.ControllerName = item.Attribute("ControllerName").Value;
                    childMenuItem.Screen = item.Attribute("Screen").Value;
                    parentItem.AddSubMenuItem(childMenuItem);
                }
            }
        }
    }


}
