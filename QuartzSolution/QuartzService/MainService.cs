using QuartzService.Scheduler;
using System.ServiceProcess;

namespace QuartzService
{
    partial class MainService : ServiceBase
    {
        IJobScheduler scheduler;

        public MainService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            scheduler = new JobScheduler();
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
