using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAAAETCommon.Helpers
{
    public class GridHelper
    {
        public static string GetSortDirection(string sortDir)
        {
            if (sortDir.Trim().ToUpper().Equals(CAAAETAppConstants.sortASC))
            {
                return CAAAETAppConstants.sortASC;
            }
            return CAAAETAppConstants.sortDESC;
        }

        public static Int64 GetColumnPosition(string colPos)
        {
            return Convert.ToInt16(colPos);
        }

        public static string GetColumnName(System.Web.HttpRequestBase Request, Int64 colPos)
        {
            return Request.QueryString[string.Format(CAAAETAppConstants.columnNameKey, colPos)];
        }
    }
}
