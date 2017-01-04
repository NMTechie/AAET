using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAAAETCommon.DataTransferObjects
{
    public class ServiceParams
    {
        public string ServiceName { get; set; }
        public string ServiceInstanceName { get; set; }        
        public double Interval { get; set; }
    }
}
