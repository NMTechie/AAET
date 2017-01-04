using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CAAAETConfigurationUI.Models;
using CAAAETCommon;
using CAAAETCommon.Helpers;
using CAAAETCommon.BusinessObjects;
using System.Data;

namespace CAAAETConfigurationUI.Controllers
{
    public class SearchController : Controller
    {
        public ActionResult SearchResult(CACAAETGridModel model)
        {
            int recordsTotal, recordsFiltered;
            
            model.SortDirection = GridHelper.GetSortDirection(Request.QueryString[CAAAETAppConstants.sortDirKey].ToString());
            model.ColumnsIndexToSort = GridHelper.GetColumnPosition(Request.QueryString[CAAAETAppConstants.sortColKey]);
            model.ColumnNameToSort = GridHelper.GetColumnName(Request, model.ColumnsIndexToSort);

            #region SearchParams
            var searchParams = new CAAAETCommon.DataTransferObjects.SearchParams();

            searchParams.MessageId = model.searchMessageId;
            searchParams.MessageBody = model.searchMessageBody;
            searchParams.StudentName = model.searchStudentName;
            searchParams.MessageReceiveTime = model.searchMessageReceiveTime;

            #endregion

            model.ResultSet = CAAAETCommon.Helpers.DummyDataSupplier.GetResultData(true, searchParams, model.ColumnNameToSort, model.SortDirection, out recordsTotal, out recordsFiltered).Skip(model.start).Take(model.length).ToList();


            model.recordsTotal = recordsTotal;
            model.recordsFiltered = recordsFiltered;            
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult MenuDemo()
        {
            return View();
        }


    }
}
