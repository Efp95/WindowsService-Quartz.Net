using Quartz;
using Quartz.Impl;
using QuartzService.Jobs;
using System.Collections.Generic;
using System.Configuration;

namespace QuartzService.Scheduler
{
    class JobScheduler : IJobScheduler
    {
        private IScheduler _scheduler;

        public string Name => GetType().Name;

        public JobScheduler()
        {

        }

        public void Run()
        {
            // Get an instance of the Quartz.Net scheduler
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            _scheduler = schedulerFactory.GetScheduler();

            // Define the Job to be scheduled
            IJobDetail customJob = JobBuilder.Create<CustomTask>()
                                    .WithIdentity(new JobKey("FirstJob", "MyGroup"))
                                    .UsingJobData("jobParameter", Name)
                                    .RequestRecovery()
                                    .Build();

            // Associate a trigger with the Job
            ITrigger customTrigger = TriggerBuilder.Create()
                                        .WithIdentity(new TriggerKey("FirstTrigger", "MyGroup"))
                                        .StartNow()
                                        .WithCronSchedule(ConfigurationManager.AppSettings["CronInterval"])
                                        .Build();

            // Assign the Job to the scheduler
            var dictionary = new Dictionary<IJobDetail, Quartz.Collection.ISet<ITrigger>>();
            dictionary.Add(customJob, new Quartz.Collection.HashSet<ITrigger>() { customTrigger });

            _scheduler.ScheduleJobs(dictionary, false);
            _scheduler.Start();
        }

        public void Stop()
        {
            if (_scheduler != null)
                _scheduler.Shutdown();
        }
    }
}
