using NLayer_Workflow.Core.Bussiness.CustomLogger;
using NLog;
using System;


namespace NLayer_Workflow.Bussiness.CustomLogger.NLogLogger
{
    public class NLogLogger : ICustomLogger
    {
        public void Log(string message)
        {
            var logger=LogManager.GetLogger("loggerFile");
            logger.Log(LogLevel.Error, message);
        }
    }
}
