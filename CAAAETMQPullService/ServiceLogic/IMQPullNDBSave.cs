using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAAAETMQPullService.ServiceLogic
{
    interface IMQPullNDBSave
    {
        void StartService();
        void StopService();
    }
}
