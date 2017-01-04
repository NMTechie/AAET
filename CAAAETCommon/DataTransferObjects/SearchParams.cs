using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAAAETCommon.DataTransferObjects
{
    public class SearchParams
    {
        public Int64? MessageId { get; set; }
        public String MessageBody { get; set; }
        public DateTime? MessageReceiveTime { get; set; }
        public String StudentName { get; set; }
    }
}
