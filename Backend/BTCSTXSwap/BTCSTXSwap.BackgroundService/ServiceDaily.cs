using System;
using System.Threading;
using System.Threading.Tasks;
using BTCSTXSwap.BackgroundService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using NCrontab;

namespace BTXSTXSwapBackgroundService
{
    public class Service : BackgroundService
    {
        private IConfiguration _configuration;

        private CrontabSchedule _schedule;
        private DateTime _nextRun;
        private readonly GWScheduleTask _gwScheduleTask;

        public Service(GWScheduleTask gwScheduleTask, IConfiguration configuration)
        {
            _configuration = configuration;
            _schedule = CrontabSchedule.Parse(_configuration["Schedule:CronDaily"], new CrontabSchedule.ParseOptions { IncludingSeconds = true });
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
                    Console.WriteLine("Escalou Daily reward " + DateTime.UtcNow);
                    _gwScheduleTask.CalculateDaily();
                    _nextRun = _schedule.GetNextOccurrence(DateTime.UtcNow);
                }
                
                await Task.Delay(600000, stoppingToken);
            }
            while (!stoppingToken.IsCancellationRequested); ;
        }
    }
}
