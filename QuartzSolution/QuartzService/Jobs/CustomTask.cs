using Quartz;
using QuartzService.Services;
using System;

namespace QuartzService.Jobs
{
    class CustomTask : IJob
    {
        private readonly ILogService _logService;

        public CustomTask(ILogService logService)
        {
            _logService = logService;
        }

        public void Execute(IJobExecutionContext context)
        {
            _logService.Debug($"Debugging at {DateTime.Now.ToString()}");
        }
    }
}
