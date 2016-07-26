using Common.Logging;
using Quartz;
using System;

namespace QuartzService.Jobs
{
    class CustomTask : IJob
    {
        private readonly ILog log = LogManager.GetLogger<CustomTask>();

        public void Execute(IJobExecutionContext context)
        {
            log.Debug($"Debugging at {DateTime.Now.ToString()}");
        }
    }
}
