using System.Collections.Generic;
using CAAAETBusinessLayer.Interface.UI;
using CAAAETCommon.DataTransferObjects;
using CAAAETDataAccessLayer.Interface.UI;


namespace CAAAETBusinessLayer.UI
{
    public class UserAccessControl: IUserAccessControlBAL
    {
        IUserAccessControlDAL _userDALObj;
        public UserAccessControl(IUserAccessControlDAL userDALObj)
        {
            _userDALObj = userDALObj;       
        }
        public List<MenuItem> GetMenuForUser(string role)
        {
            List<MenuItem> menus = _userDALObj.GetRoleNodeXML(role);            
            return menus;
        }
    }
}
