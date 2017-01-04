using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAAAETCommon.CustomException
{
    public class CAAAETException : Exception
    {
        public string ErrorId
        {
            get;
            set;
        }

        public CAAAETException(string businessMsg)
            : base(businessMsg)
        {
        }
    }
}
