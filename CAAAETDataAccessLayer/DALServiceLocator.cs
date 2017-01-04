using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAAAETDataAccessLayer.Interface.UI;
using SimpleInjector;

namespace CAAAETDataAccessLayer
{
    class DALServiceLocator : IDIDALServiceLocator
    {
        public IUserAccessControlDAL GetUserDALServiceLocator(Container diContainer)
        {
            return diContainer.GetInstance<IUserAccessControlDAL>();
        }
    }

    public interface IDIDALServiceLocator
    {
        IUserAccessControlDAL GetUserDALServiceLocator(Container diContainer);
    }
}
