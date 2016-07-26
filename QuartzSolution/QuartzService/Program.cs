namespace QuartzService
{
    static class Program
    {
        static void Main()
        {
#if DEBUG
            // Run as Console Application
            var scheduler = new Scheduler.JobScheduler();
            scheduler.Run();
#else
            // Run as Windows Service
            ServiceBase.Run(new MainService());
#endif
        }
    }
}
