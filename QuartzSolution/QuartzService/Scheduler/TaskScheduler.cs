﻿using Quartz;
using Quartz.Impl;
using QuartzService.Jobs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzService.Scheduler
{
    class TaskScheduler : ITaskScheduler
    {
        private IScheduler _scheduler;

        public string Name => GetType().Name;

        public void Run()
        {
            // Get an instance of the Quartz.Net scheduler
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            _scheduler = schedulerFactory.GetScheduler();

            // Define the Job to be scheduled
            IJobDetail customJob = JobBuilder.Create<CustomTask>()
                                    .WithIdentity(new JobKey("", ""))
                                    .RequestRecovery()
                                    .Build();

            // Associate a trigger with the Job
            ITrigger customTrigger = TriggerBuilder.Create()
                                        .WithIdentity(new TriggerKey("", ""))
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
