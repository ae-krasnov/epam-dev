using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NLog;

namespace Loggers
{
    public class AdapterNLog : ILogger
    {
        private static Logger _log = LogManager.GetCurrentClassLogger();

        public void WriteToLog(string msg)
        {
            _log.Trace(msg);    
        }
    }
}
