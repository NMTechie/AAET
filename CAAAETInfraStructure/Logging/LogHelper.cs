using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

using CAAAETCommon.CustomException;


namespace CAAAETInfraStructure.Logging
{
    /// <summary>
    /// This will act as the abstraction layer for the actual logging implementation
    /// </summary>
    public sealed class LogHelper
    {
        private static LogHelper _logHelper;
        private static Object _sync = new object();
        private static readonly ILog log4NetLogger = LogManager.GetLogger(typeof(LogHelper));

        private LogHelper()
        {
            
        }

        public static LogHelper GetLogger()
        {
            if (_logHelper == null)
            {
                lock (_sync)
                {
                    _logHelper = new LogHelper();                    
                }
            }
            return _logHelper;
        }

        public bool WriteInfo(string message)
        {
            bool status = false;
            try
            {
                log4NetLogger.Info(message);
                status = true;
            }
            catch
            {

            }
            return status;
        }

        public bool WriteWarning(string message)
        {
            bool status = false;
            try
            {
                log4NetLogger.Warn(message);
                status = true;
            }
            catch
            {

            }
            return status;
        }

        public bool WriteException(Exception exception)
        {
            bool status = false;
            try
            {
                log4NetLogger.Error(exception.Message, exception);
                status = true;
            }
            catch 
            {
            }
            return status;
        }

        public string WriteBusinessException(CAAAETException exception)
        {
            string errorId = string.Empty;
            try
            {
                errorId = exception.ErrorId.Trim().Count() > 0 ? exception.ErrorId : Guid.NewGuid().ToString();
                GlobalContext.Properties["ErrorId"] = errorId;
                log4NetLogger.Error(exception.Message, exception);
            }
            catch 
            {
                errorId = string.Empty;
            }
            return errorId;
        }
    }
}
