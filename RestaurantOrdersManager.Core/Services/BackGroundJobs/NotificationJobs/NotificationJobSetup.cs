using Microsoft.Extensions.Options;
using Quartz;
using RestaurantOrdersManager.Core.Services.BackGroundJobs.ReservationJobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.Services.BackGroundJobs.NotificationJobs
{
    public class NotificationJobSetup : IConfigureOptions<QuartzOptions>
    {
        public void Configure(QuartzOptions options)
        {
            var jobKey = JobKey.Create(nameof(NotificationJob));
            options
                .AddJob<NotificationJob>(jobBuilder => jobBuilder.WithIdentity(jobKey));

            options
                .AddTrigger(trigger =>
                    trigger
                        .ForJob(jobKey)
                        .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(15,14))
                        .Build());

            options
                .AddTrigger(trigger =>
                    trigger
                        .ForJob(jobKey)
                        .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(15, 15))
                        .Build());
        }
    }
}