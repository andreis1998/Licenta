using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LicentaPrototip.Jobs
{
    public class JobScheduler
    {
        public static void Start()
        {
            //Get temperature job
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();

            IJobDetail job = JobBuilder.Create<TemperatureJob>().Build();

            ITrigger trigger = TriggerBuilder.Create()
            .WithIdentity("trigger1", "group1")
            .StartNow()
            .WithSimpleSchedule(x => x
            .WithIntervalInSeconds(30)
            .RepeatForever())
            .Build();

            scheduler.ScheduleJob(job, trigger);

            //Set light intensity job
            IScheduler scheduler2 = StdSchedulerFactory.GetDefaultScheduler();
            scheduler2.Start();

            IJobDetail job2 = JobBuilder.Create<LightIntensityJob>().Build();

            ITrigger trigger2 = TriggerBuilder.Create()
            .WithIdentity("trigger2", "group1")
            .StartNow()
            .WithSimpleSchedule(x => x
            .WithIntervalInSeconds(10)
            .RepeatForever())
            .Build();

            scheduler2.ScheduleJob(job2, trigger2);

            //Log temperature job
            IScheduler scheduler3 = StdSchedulerFactory.GetDefaultScheduler();
            scheduler3.Start();

            IJobDetail job3 = JobBuilder.Create<TemperatureLogJob>().Build();

            ITrigger trigger3 = TriggerBuilder.Create()
            .WithIdentity("trigger3", "group1")
            .StartNow()
            .WithSimpleSchedule(x => x
            .WithIntervalInSeconds(60)
            .RepeatForever())
            .Build();

            scheduler3.ScheduleJob(job3, trigger3);

            //Control Temperature
            IScheduler scheduler4 = StdSchedulerFactory.GetDefaultScheduler();
            scheduler4.Start();

            IJobDetail job4 = JobBuilder.Create<TemperatureControlJob>().Build();

            ITrigger trigger4 = TriggerBuilder.Create()
            .WithIdentity("trigger4", "group1")
            .StartNow()
            .WithSimpleSchedule(x => x
            .WithIntervalInSeconds(8)
            .RepeatForever())
            .Build();

            scheduler4.ScheduleJob(job4, trigger4);

            //Control Door
            IScheduler scheduler5 = StdSchedulerFactory.GetDefaultScheduler();
            scheduler5.Start();

            IJobDetail job5 = JobBuilder.Create<DoorJob>().Build();

            ITrigger trigger5 = TriggerBuilder.Create()
            .WithIdentity("trigger5", "group1")
            .StartNow()
            .WithSimpleSchedule(x => x
            .WithIntervalInSeconds(2)
            .RepeatForever())
            .Build();

            scheduler5.ScheduleJob(job5, trigger5);
        }
    }
}