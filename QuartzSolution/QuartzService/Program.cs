using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace QuartzService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            var scheduler = new Scheduler.JobScheduler();
#if DEBUG
            scheduler.Run();
#else
            ServiceBase.Run(new MainService());
#endif
        }
    }
}
