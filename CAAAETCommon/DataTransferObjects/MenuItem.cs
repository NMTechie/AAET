using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAAAETCommon.DataTransferObjects
{
    public class MenuItem
    {
        private List<MenuItem> menuList;
        private Boolean isSubMenu;
        public List<MenuItem> MenuList
        {
            get { return menuList; }
        }

        public Boolean IsSubMenu
        {
            get { return isSubMenu; }
            set { isSubMenu = value; }
        }
        public String MenuText { get; set; }
        public String ActionName { get; set; }
        public String ControllerName { get; set; }
        public String Screen { get; set; }

        public void AddSubMenuItem(MenuItem item)
        {
            if (this.menuList == null)
            {
                this.menuList = new List<MenuItem>();
            }
            this.menuList.Add(item);
        }
    }
}
