using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;
using System.Configuration;

namespace Loggers
{
    public class AdapterLog4Net : ILogger
    {
        private ILog _log; 

        public AdapterLog4Net(Type tClass) 
        {
            log4net.Config.XmlConfigurator.Configure();
            _log = LogManager.GetLogger(tClass);
        }
        public void WriteToLog(string msg)
        {
            _log.Debug(msg);
        }
    }
}
