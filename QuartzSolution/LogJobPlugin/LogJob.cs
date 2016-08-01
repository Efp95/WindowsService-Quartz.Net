using LogJobPlugin.Services;
using Quartz;
using System;

namespace LogJobPlugin
{
    public class LogJob : IJob
    {
        private readonly ILogService _logService;

        public LogJob(ILogService logService)
        {
            _logService = logService;
        }

        public void Execute(IJobExecutionContext context)
        {
            _logService.Debug($"Debugging at {DateTime.Now.ToString()}");
        }
    }
}
