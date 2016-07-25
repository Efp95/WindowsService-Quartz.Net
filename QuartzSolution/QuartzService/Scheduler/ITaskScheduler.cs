namespace QuartzService.Scheduler
{
    interface ITaskScheduler
    {
        string Name { get; }

        void Run();
        void Stop();
    }
}
