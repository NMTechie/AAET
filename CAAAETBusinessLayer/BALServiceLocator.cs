using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAAAETBusinessLayer.Interface.UI;
using SimpleInjector;

namespace CAAAETBusinessLayer
{
    public class BALServiceLocator : IBLServiceLocator
    {
        public IUserAccessControlBAL GetUserBLServiceLocator(Container diContainer)
        {
            return diContainer.GetInstance<IUserAccessControlBAL>();
        }
    }
    public interface IBLServiceLocator
    {
        IUserAccessControlBAL GetUserBLServiceLocator(Container diContainer);
    }

}
