using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Configuration;
using Topshelf;
using Topshelf.ServiceConfigurators;
using CAAAETCommon.ApplicationMessages;
using CAAAETMQPullService.ServiceLogic;
using CAAAETCommon.DataTransferObjects;
using CAAAETCommon.CustomException;
using CAAAETInfraStructure.Logging;


namespace CAAAETMQPullService
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceParams param = new ServiceParams();
            //
            param.ServiceName = ConfigurationManager.AppSettings["ServiceName"];
            param.ServiceInstanceName = ConfigurationManager.AppSettings["InstanceName"]; 
            param.Interval = Convert.ToDouble(ConfigurationManager.AppSettings["Interval"]);
            //
            #region The Top Self Service Backbone Code            
            Host serviceHost = HostFactory.New(x =>
                {
                    x.SetServiceName(param.ServiceName);
                    x.SetInstanceName(param.ServiceInstanceName);
                    x.SetDisplayName(param.ServiceName);
                    x.SetDescription(ApplicationMessages.CAAAETMQPullService_002);
                    x.RunAsLocalSystem();
                    x.StartAutomatically();
                    x.Service<IMQPullNDBSave>(s =>
                    {
                        s.ConstructUsing(name => new MQPullNDBSave(param));
                        s.WhenStarted(serLogic => serLogic.StartService());
                        s.WhenStopped(serLogic => serLogic.StopService());
                    });                    
                }
            );
            serviceHost.Run();
            #endregion              
        }        
    }
}
