using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationBuildValidator.UserAccessControlXML;

namespace ApplicationBuildValidator
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args!=null && args.Length > 0 && args[0].Trim().ToUpper().Equals("XML"))
            {
                UserAccessControlValidator validateXMLSchema = new UserAccessControlValidator();
                return validateXMLSchema.ValidateMenuSchema();
            }
            return 1;
        }
    }
}
