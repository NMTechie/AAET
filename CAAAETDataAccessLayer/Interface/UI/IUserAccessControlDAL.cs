using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAAAETCommon;
using CAAAETCommon.DataTransferObjects;

namespace CAAAETDataAccessLayer.Interface.UI
{
   public interface IUserAccessControlDAL
    {
        List<MenuItem> GetRoleNodeXML(string role);
    }
}
