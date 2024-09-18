using Microsoft.Extensions.Options;
using Quartz;

namespace RestaurantOrdersManager.Core.Services.BackGroundJobs.ReservationJobs;

public class ReservationSystemJobSetup : IConfigureOptions<QuartzOptions>
{
    public void Configure(QuartzOptions options)
    {
        var jobKey = JobKey.Create(nameof(ReservationSystemJob));
        options
            .AddJob<ReservationSystemJob>(jobBuilder => jobBuilder.WithIdentity(jobKey))
            .AddTrigger(trigger =>
                trigger
                    .ForJob(jobKey)
                    .WithSimpleSchedule(schedule =>
                        schedule.WithIntervalInSeconds(5).RepeatForever()));
    }
}