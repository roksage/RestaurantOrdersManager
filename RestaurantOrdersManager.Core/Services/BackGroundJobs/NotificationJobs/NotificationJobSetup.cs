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

            //send notification at 08:00
            options
                .AddTrigger(trigger =>
                    trigger
                        .ForJob(jobKey)
                        .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(08,00))
                        .Build());
            //send notification at 20:00
            options
                .AddTrigger(trigger =>
                    trigger
                        .ForJob(jobKey)
                        .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(20, 00))
                        .Build());
        }
    }
}