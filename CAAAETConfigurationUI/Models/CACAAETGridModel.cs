using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CAAAETCommon.BusinessObjects;
using CAAAETCommon.DataTransferObjects;

namespace CAAAETConfigurationUI.Models
{
    public class CACAAETGridModel
    {
        public Int64 draw { get; set; }
        public Int32 start { get; set; }
        public Int32 length { get; set; }
        public Int64 ColumnsIndexToSort { get; set; }
        public String SortDirection { get; set; }
        public String ColumnNameToSort { get; set; }
        public Int64 recordsTotal { get; set; }
        public Int64 recordsFiltered { get; set; }
        public IEnumerable<SearchResult> ResultSet { get; set; }
        public string error { get; set; }

        public Int64? searchMessageId { get; set; }
        public String searchMessageBody { get; set; }
        public DateTime? searchMessageReceiveTime { get; set; }
        public String searchStudentName { get; set; }


    }
}