using QuartzService.Container;
using QuartzService.Scheduler;
using System.ServiceProcess;
using Topshelf;

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
            HostFactory.Run(h =>
            {
                h.Service<JobScheduler>(s =>
                {
                    s.ConstructUsing(x => new JobScheduler());

                    s.WhenStarted(ws => ws.Run());
                    s.WhenStopped(ws => ws.Stop());

                    s.WhenPaused(ws => ws.Stop());
                    s.WhenContinued(ws => ws.Run());

                    s.WhenShutdown(ws => ws.Stop());
                });

                h.RunAsLocalSystem();

                h.SetDescription("Hosting from Topshelf");
                h.SetDisplayName("My Quartz.Net Service");
                h.SetServiceName("Quartz Scheduler Service");
            });

            // Requires sends 'install' command from CMD to appear in the services window
            // i.e. [QuartzService.exe install]
#endif
        }
    }
}
