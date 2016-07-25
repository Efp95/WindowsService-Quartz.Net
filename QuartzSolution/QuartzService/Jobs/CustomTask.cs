using Quartz;
using System;

namespace QuartzService.Jobs
{
    class CustomTask : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            var x = string.Empty;
        }
    }
}
