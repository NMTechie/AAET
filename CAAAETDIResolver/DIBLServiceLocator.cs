using CAAAETBusinessLayer.Interface.UI;
using SimpleInjector;

namespace CAAAETDIResolver
{
    public class DIBLServiceLocator : IDIBLServiceLocator
    {
        public IUserAccessControlBAL GetUserBLServiceLocator(Container diContainer)
        {
            return diContainer.GetInstance<IUserAccessControlBAL>();
        }
    }
    public interface IDIBLServiceLocator
    {
        IUserAccessControlBAL GetUserBLServiceLocator(Container diContainer);
    }
}
