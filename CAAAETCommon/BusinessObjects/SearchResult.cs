using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAAAETCommon.BusinessObjects
{
    public class SearchResult
    {
        public Int64 MessageId { get; set; }
        public string MessageBody { get; set; }
        public string MessageReceiveTime { get; set; }
        public string StudentName { get; set; }
    }
}
