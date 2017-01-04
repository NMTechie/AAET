using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CAAAETInfraStructure;
using CAAAETInfraStructure.DataBase;
using CAAAETInfraStructure.Logging;
using CAAAETCommon.CustomException;
using CAAAETCommon.Enums;
using System.Data.SqlClient;
using System.Data.Common;

namespace AppInvokerForTesting
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            try
            {
                InitializeComponent();
                //LogHelper.GetLogger().WriteInfo("Hi");
                //LogHelper.GetLogger().WriteWarning("Warning");

                ////Exception ex = new Exception("Error");
                ////throw ex;
                //CAAAETException ex1 = new CAAAETException("This is business exception");
                //throw ex1;
                

                DbParameter p = CAAAETDataBaseFactory.GetDataBase(CAAAETApplicationDBEnums.SQL).CreateParameter("N", DbType.Int16, ParameterDirection.Input);
                var obj = CAAAETDataBaseFactory.GetDataBase(CAAAETApplicationDBEnums.SQL).ExecuteStoredProc("Hello",p);
                
                
            }
            catch (CAAAETException ex)
            {
                LogHelper.GetLogger().WriteBusinessException(ex);
            }
            catch (Exception ex)
            {
                LogHelper.GetLogger().WriteException(ex);
            }
        }
    }
}
