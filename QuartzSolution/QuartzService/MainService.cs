using QuartzService.Scheduler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace QuartzService
{
    partial class MainService : ServiceBase
    {
        ITaskScheduler scheduler;

        public MainService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            scheduler = new Scheduler.TaskScheduler();
            scheduler.Run();
        }

        protected override void OnStop()
        {
            if (scheduler != null)
            {
                scheduler.Stop();
            }
        }
    }
}
