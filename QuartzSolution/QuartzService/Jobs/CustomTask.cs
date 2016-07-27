using Common.Logging;
using Quartz;
using System;

namespace QuartzService.Jobs
{
    class CustomTask : IJob
    {
        private readonly ILog log = LogManager.GetLogger<CustomTask>();

        // Injected from JobDataMap
        public string JobParameter { private get; set; }

        public void Execute(IJobExecutionContext context)
        {
            //var jobDataMap = context.JobDetail.JobDataMap;
            //var schedulerName = jobDataMap.GetString("jobParameter");

            log.Debug($"Debugging at {DateTime.Now.ToString()} From [{JobParameter}]");
        }
    }
}
