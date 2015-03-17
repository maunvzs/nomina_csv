using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.Reflection;
using System.IO;

namespace EnviaNomina
{

    public class Logger
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static ILog set
        {
            get
            {
                log4net.Config.XmlConfigurator.Configure(new FileInfo("~/App.config"));
                return Log;
            }
        }

        public static void Initialize(string path)
        {
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(path));
        }
    }
}