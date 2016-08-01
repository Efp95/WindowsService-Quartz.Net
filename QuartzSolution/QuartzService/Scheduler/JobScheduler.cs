using Ninject;
using Quartz;
using Quartz.Impl;
using QuartzService.Container;

namespace QuartzService.Scheduler
{
    class JobScheduler : IJobScheduler
    {
        IScheduler _scheduler;
        readonly IKernel _kernel = NinjectConfig.Container;

        public string Name => GetType().Name;

        public void Run()
        {
            // Configurartion loaded from app.config
            ISchedulerFactory sf = new StdSchedulerFactory();
            _scheduler = sf.GetScheduler();
            // Set NInjectFactory to apply Dependency Injection at Job Creation
            _scheduler.JobFactory = new NinjectJobFactory(_kernel);
            // Start Scheduler
            _scheduler.Start();
        }

        public void Stop()
        {
            if (_scheduler != null)
                _scheduler.Shutdown();
        }
    }
}
