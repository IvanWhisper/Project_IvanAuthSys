using IvanAuthSys.Interface;
using NLog;
using System;
using System.IO;

namespace IvanAuthSys.Logger
{
    public class LoggerNLog : IvanAuthSys.Interface.ILogger
    {
        private static NLog.Logger logger;
        public LoggerNLog()
        {
            logger = NLog.LogManager.GetLogger("mylog");
        }
        public void Info(object message, Exception e = null)
        {
            if (e == null)
            {
                logger.Info((message == null) ? "" : message);
            }
            else
            {
                logger.Info(((message == null) ? "" : message)+e.Message);
            }
        }
        public void Debug(object message, Exception e = null)
        {
            if (e == null)
            {
                logger.Debug((message == null) ? "" : message);
            }
            else
            {
                logger.Debug(((message == null) ? "" : message) + e.Message);
            }
        }
        public void Warn(object message, Exception e = null)
        {
            if (e == null)
            {
                logger.Warn((message == null) ? "" : message);
            }
            else
            {
                logger.Warn(((message == null) ? "" : message) + e.Message);
            }

        }
        public void Error(object message, Exception e)
        {
            if (e == null)
            {
                logger.Error((message == null) ? "" : message);
            }
            else
            {
                logger.Error(((message == null) ? "" : message) + e.Message);
            }

        }
        public void Fatal(object message, Exception e)
        {
            if (e == null)
            {
                logger.Fatal((message == null) ? "" : message);
            }
            else
            {
                logger.Fatal(((message == null) ? "" : message) + e.Message);
            }

        }
    }
}
