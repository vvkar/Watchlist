using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Watchlist.Domain.Core.Options;
using Watchlist.Domain.Interfaces.Services;
using Watchlist.Infrastructure.Business.Jobs;
using Watchlist.Infrastructure.Business.Services;

namespace Watchlist.Infrastructure.Business
{
    public static class DependencyInjection
    {
        public static void AddApplications(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IFilmSearchService, ImdbSearchService>();
            services.AddScoped<ISenderService, SenderService>();
            
            services.AddHttpClient<IFilmSearchService, ImdbSearchService>();

            services.AddQuartz(q =>
            {
                q.UseMicrosoftDependencyInjectionJobFactory();

                var options = new PromotionOptions();
                configuration.GetSection(PromotionOptions.Promotion).Bind(options);
                var promotionJobKey = new JobKey(nameof(PromotionJob));

                q.AddJob<PromotionJob>(opts => opts.WithIdentity(promotionJobKey));
                q.AddTrigger(opts => opts
                    .ForJob(promotionJobKey)
                    .WithIdentity($"{nameof(PromotionJob)}-trigger")
                .WithSchedule(CronScheduleBuilder
                    .WeeklyOnDayAndHourAndMinute(options.DayOfWeek, options.Hour, options.Hour)
                    .InTimeZone(TimeZoneInfo.Local)));
                //.WithCronSchedule("0 30 19 ? * SUN *")
                //.WithSimpleSchedule(x => x
                //    .WithIntervalInSeconds(600)
                //    .RepeatForever()));
            });
            services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
        }
    }
}
