using Quartz;
using System;

namespace QuartzService.Jobs
{
    class CustomTask : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            throw new NotImplementedException();
        }
    }
}
