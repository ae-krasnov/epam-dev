using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Loggers
{
    public class MyLogger : ILogger
    {
        public void WriteToLog(string msg)
        {
            using (StreamWriter _logStrem=new StreamWriter("myLog.txt",true))
            {
                StringBuilder _msgToLog = new StringBuilder(DateTime.Now.ToString());
                _msgToLog.Append(" ");
                _msgToLog.Append("Message:");
                _msgToLog.Append(msg);
                _logStrem.WriteLine(_msgToLog.ToString());
            }
        }
    }
}
