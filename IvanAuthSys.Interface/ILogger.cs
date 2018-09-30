using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IvanAuthSys.Interface
{
    public interface ILogger
    {
        /// <summary>
        /// 消息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        void Info(object message, Exception e=null);
        /// <summary>
        /// 调试
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        void Debug(object message, Exception e = null);
        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        void Warn(object message, Exception e = null);
        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="message"></param>
        void Error(object message, Exception e = null);
        /// <summary>
        /// 致命
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        void Fatal(object message, Exception e = null);
    }
}
