using QuartzService.Container;
using QuartzService.Scheduler;

namespace QuartzService
{
    static class Program
    {
        static void Main()
        {
            NinjectConfig.Initialize();

#if DEBUG
            // Run as Console Application
            var scheduler = new JobScheduler();
            scheduler.Run();
#else
            // Run as Windows Service
            ServiceBase.Run(new MainService());
#endif
        }
    }
}
