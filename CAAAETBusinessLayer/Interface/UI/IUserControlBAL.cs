using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAAAETCommon.DataTransferObjects;

namespace CAAAETBusinessLayer.Interface.UI
{
    public interface IUserAccessControlBAL 
    {
        List<MenuItem> GetMenuForUser(string role);
    }
}
