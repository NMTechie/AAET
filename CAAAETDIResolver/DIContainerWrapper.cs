using System;
using CAAAETBusinessLayer.Interface.UI;
using CAAAETBusinessLayer.UI;
using CAAAETBusinessLayer;
using CAAAETDataAccessLayer.UI;
using CAAAETDataAccessLayer.Interface.UI;
using SimpleInjector;


namespace CAAAETDIResolver
{
    public static class DIContainerWrapper
    {
        public static void RegisterAllDependency(Container diContainer)
        {
            diContainer.Register<IBLServiceLocator, BALServiceLocator>(Lifestyle.Scoped);
            diContainer.Register<IUserAccessControlBAL, UserAccessControl>(Lifestyle.Scoped);
            diContainer.Register<IUserAccessControlDAL, UserAccessControlDAL>(Lifestyle.Scoped);
        }
    }
}
