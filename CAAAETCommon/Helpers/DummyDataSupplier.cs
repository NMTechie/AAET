using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAAAETCommon.BusinessObjects;


namespace CAAAETCommon.Helpers
{
    public class DummyDataSupplier
    {
        public const string dateFormatString = "dd/MM/yyyy";
        public const string dateTimeFormatString = "dd/MM/yyyy hh:mm:ss";
        public static List<SearchResult> GetResultData(bool getResult)
        {
            List<SearchResult> _lst = new List<SearchResult>();
            if (getResult)
            {
                SearchResult item1 = new SearchResult();
                item1.MessageId = 1;
                item1.MessageBody = "jksahdjksahd";
                item1.MessageReceiveTime = DateTime.UtcNow.ToString();
                item1.StudentName = "Student1";
                _lst.Add(item1);
                //
                SearchResult item2 = new SearchResult();
                item2.MessageId = 2;
                item2.MessageBody = "jksahdjksahd2";
                item2.MessageReceiveTime = DateTime.UtcNow.AddMinutes(2).ToString();
                item2.StudentName = "Student2";
                _lst.Add(item2);
                //
                SearchResult item3 = new SearchResult();
                item3.MessageId = 3;
                item3.MessageBody = "jksahdjksahd3";
                item3.MessageReceiveTime = DateTime.UtcNow.AddMinutes(3).ToString();
                item3.StudentName = "Student3";
                _lst.Add(item3);
                //
                SearchResult item4 = new SearchResult();
                item4.MessageId = 4;
                item4.MessageBody = "jksahdjksahd4";
                item4.MessageReceiveTime = DateTime.UtcNow.AddMinutes(4).ToString();
                item4.StudentName = "Student4";
                _lst.Add(item4);
            }
            return _lst;
        }

        public static IEnumerable<SearchResult> GetResultData(bool getResult, DataTransferObjects.SearchParams searchParams, string orderByParam, string orderByDirection, out int totalRecords, out int filteredRecords)
        {
            List<SearchResult> _lst = new List<SearchResult>();
            if (getResult)
            {
                #region StaticData
                //SearchResult item1 = new SearchResult();
                //item1.MessageId = 1;
                //item1.MessageBody = "jksahdjksahd";
                //item1.MessageReceiveTime = DateTime.UtcNow.ToString(dateFormatString);
                //item1.StudentName = "Student1";
                //_lst.Add(item1);
                ////
                //SearchResult item2 = new SearchResult();
                //item2.MessageId = 2;
                //item2.MessageBody = "jksahdjksahd2";
                //item2.MessageReceiveTime = DateTime.UtcNow.AddMinutes(2).ToString(dateFormatString);
                //item2.StudentName = "Student2";
                //_lst.Add(item2);
                ////
                //SearchResult item3 = new SearchResult();
                //item3.MessageId = 3;
                //item3.MessageBody = "jksahdjksahd3";
                //item3.MessageReceiveTime = DateTime.UtcNow.AddMinutes(3).ToString(dateFormatString);
                //item3.StudentName = "Student3";
                //_lst.Add(item3);
                ////
                //SearchResult item4 = new SearchResult();
                //item4.MessageId = 4;
                //item4.MessageBody = "jksahdjksahd4";
                //item4.MessageReceiveTime = DateTime.UtcNow.AddMinutes(4).ToString(dateFormatString);
                //item4.StudentName = "Student4";
                //_lst.Add(item4); 
                #endregion


                SearchResult item;
                for (int i = 1; i <= 50; i++)
                {
                    item = new SearchResult();
                    item.MessageId = i;
                    item.MessageBody = string.Format("jksahdjksahd{0}", i);
                    item.MessageReceiveTime = DateTime.UtcNow.AddHours(i).ToString(dateTimeFormatString);
                    item.StudentName = string.Format("Student{0}", i);
                    _lst.Add(item);
                }

            }
            totalRecords = _lst.Count;

            if (searchParams.MessageId.HasValue)
            {
                _lst = _lst.Where(o => o.MessageId == searchParams.MessageId.Value).ToList();
            }
            if (!string.IsNullOrEmpty(searchParams.MessageBody))
            {
                _lst = _lst.Where(o => o.MessageBody.IndexOf(searchParams.MessageBody, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }
            if (searchParams.MessageReceiveTime.HasValue)
            {
                _lst = _lst.Where(o => o.MessageReceiveTime.IndexOf(searchParams.MessageReceiveTime.Value.ToString(dateTimeFormatString), StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }
            if (!string.IsNullOrEmpty(searchParams.StudentName))
            {
                _lst = _lst.Where(o => o.StudentName.IndexOf(searchParams.StudentName, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }

            var pi = typeof(SearchResult).GetProperty(orderByParam);

            switch (orderByDirection.ToUpper())
            {
                case "DESC":
                    _lst = _lst.OrderByDescending(x => pi.GetValue(x, null)).ToList();
                    break;
                default:
                    _lst = _lst.OrderBy(x => pi.GetValue(x, null)).ToList();
                    break;
            }

            //_lst = _lst.Skip(start).Take(length).ToList();

            filteredRecords = _lst.Count;
            return _lst;
        }

        public static void GetResults()
        {

        }
    }
}
