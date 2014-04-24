using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NLog;

namespace FactoriesDAL
{
    class NLogger
    {
        private static Logger _log = LogManager.GetCurrentClassLogger();

        public static void WriteErrorInLog(string msg)
        {
            _log.Error(msg);
        }
    }
}
