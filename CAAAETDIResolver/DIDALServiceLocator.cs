using CAAAETDataAccessLayer.Interface.UI;
using SimpleInjector;

namespace CAAAETDIResolver
{
    public class DIDALServiceLocator : IDIDALServiceLocator
    {
        public IUserAccessControlDAL GetUserBLServiceLocator(Container diContainer)
        {
            return diContainer.GetInstance<IUserAccessControlDAL>();
        }
    }

    public interface IDIDALServiceLocator
    {
        IUserAccessControlDAL GetUserBLServiceLocator(Container diContainer);
    }
}
