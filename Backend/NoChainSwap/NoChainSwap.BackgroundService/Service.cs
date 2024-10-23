using System;
using System.Threading;
using System.Threading.Tasks;
using NoChainSwap.BackgroundService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using NCrontab;

namespace NoChainSwapBackgroundService
{
    public class ServiceDaily : BackgroundService
    {
        private IConfiguration _configuration;

        private CrontabSchedule _schedule;
        private DateTime _nextRun;
        private readonly GWScheduleTask _gwScheduleTask;

        public ServiceDaily(GWScheduleTask gwScheduleTask, IConfiguration configuration)
        {
            _configuration = configuration;
            _schedule = CrontabSchedule.Parse(_configuration["Schedule:Cron"], new CrontabSchedule.ParseOptions { IncludingSeconds = true });
            _nextRun = _schedule.GetNextOccurrence(DateTime.UtcNow);
            _gwScheduleTask = gwScheduleTask;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            do
            {
                var now = DateTime.UtcNow;
                var nextrun = _schedule.GetNextOccurrence(now);
                if (now > _nextRun)
                {
                    _gwScheduleTask.DoMinning();
                    _nextRun = _schedule.GetNextOccurrence(DateTime.UtcNow);
                }
                await Task.Delay(120000, stoppingToken);
            }
            while (!stoppingToken.IsCancellationRequested); ;
        }
    }
}
