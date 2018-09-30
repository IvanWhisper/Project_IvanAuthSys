using IvanAuthSys.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace IvanAuthSys.Logger
{
    public class LoggerConsole : ILogger
    {
        public void Debug(object message, Exception e = null)
        {
            if (e == null)
            {
                MsgFormat("DEBUG", (message == null) ? "" : message.ToString());
            }
            else
            {
                MsgFormat("DEBUG", (message == null) ? "" : message.ToString() + " " + e.ToString());
            }
        }

        public void Error(object message, Exception e = null)
        {
            if (e == null)
            {
                MsgFormat("ERROR", (message == null) ? "" : message.ToString());
            }
            else
            {
                MsgFormat("ERROR", (message == null) ? "" : message.ToString() + " " + e.ToString());
            }
        }

        public void Fatal(object message, Exception e = null)
        {
            if (e == null)
            {
                MsgFormat("Fatal", (message == null) ? "" : message.ToString());
            }
            else
            {
                MsgFormat("Fatal", (message == null) ? "" : message.ToString() + " " + e.ToString());
            }

        }


        public void Info(object message, Exception e = null)
        {
            if (e == null)
            {
                MsgFormat("Info", (message == null) ? "" : message.ToString());
            }
            else
            {
                MsgFormat("Info", (message == null) ? "" : message.ToString() + " " + e.ToString());
            }

        }


        public void Warn(object message, Exception e = null)
        {
            if (e == null)
            {
                MsgFormat("Warn", (message == null) ? "" : message.ToString());
            }
            else
            {
                MsgFormat("Warn", (message == null) ? "" : message.ToString() + " " + e.ToString());
            }

        }
        private void MsgFormat(string level, string msg)
        {
            Console.WriteLine("时间:{0} 级别:{1} 内容:{2}", DateTime.Now, level, msg);
        }
    }
}
