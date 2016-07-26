namespace QuartzService.Scheduler
{
    interface IJobScheduler
    {
        string Name { get; }

        void Run();
        void Stop();
    }
}
