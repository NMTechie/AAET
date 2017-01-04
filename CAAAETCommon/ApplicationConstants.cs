using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAAAETCommon
{
    public class CAAAETAppConstants
    {
        #region ROLE
        public const string roleSTAFF = "STAFF";
        public const string roleADMIN = "ADMIN";        
        #endregion

        #region GRID SERACH FUNCTIONALITIES
        public const string sortASC = "ASC";
        public const string sortDESC = "DESC";
        public const string sortDirKey = "order[0][dir]";
        public const string sortColKey = "order[0][column]";
        public const string columnNameKey = "columns[{0}][name]";
        #endregion

        #region MENU HELPER
        public const string XMLFileName = "UserAccessControl.xml";
        #endregion

        #region DataBase
        public const string SQLConnString = "SQLConnection";
        #endregion
    }
}
