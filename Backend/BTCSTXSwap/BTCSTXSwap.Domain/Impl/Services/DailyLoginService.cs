using Core.Domain.Repository;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Models;
using BTCSTXSwap.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Services
{
    public class DailyLoginService : IDailyLoginService
    {
        private readonly IDailyLoginRepository<IDailyLoginModel, IDailyLoginDomainFactory> _dailyRep;
        private readonly IDailyLoginDomainFactory _dailyFactory;
        private readonly IDailyLoginDayDomainFactory _dailyDayFactory;
        private readonly ILogCore _log;

        public DailyLoginService(
            IDailyLoginDomainFactory dailyFactory,
            IDailyLoginDayDomainFactory dailyDayFactory,
            IDailyLoginRepository<IDailyLoginModel, IDailyLoginDomainFactory> dailyRep,
            ILogCore log
        )
        {
            _dailyFactory = dailyFactory;
            _dailyDayFactory = dailyDayFactory;
            _dailyRep = dailyRep;
            _log = log;
        }

        public void DoLogin(long idUser)
        {
            var dl = GetLastByUser(idUser);
            if (dl != null) {
                
            }
        }

        private IDailyLoginModel NewDailyLogin(long idUser)
        {
            var md = _dailyFactory.BuildDailyLoginModel();
            md.IdUser = idUser;
            md.InsertDate = DateTime.UtcNow;
            md.Days = new List<IDailyLoginDayModel>();
            for (var i = 1; i <= 7; i++)
            {
                var d = _dailyDayFactory.BuildDailyLoginDayModel();
                d.Day = i;
                d.ItemKey = 0;
                d.LimitDate = DateTime.Today.AddDays(i - 1).Add(new TimeSpan(23, 59, 59));
                d.Success = false;

                md.Days.Add(d);
            }
            return md;
        }

        public IDailyLoginModel GetLastByUser(long idUser)
        {
            var md = _dailyRep.GetLastDailyByUser(_dailyFactory, idUser);
            if (md != null)
            {
                if (
                    md.Days.Where(x => x.Success == false).Any() &&
                    DateTime.UtcNow <= md.Days.Select(x => x.LimitDate).Max()
                )
                {
                    return md;
                }
                else {
                    _dailyRep.Delete(md.Id);
                    md = NewDailyLogin(idUser);
                    _dailyRep.Insert(_dailyFactory, md);
                    md = _dailyRep.GetLastDailyByUser(_dailyFactory, idUser);
                }
            }
            else
            {
                md = _dailyRep.GetLastDailyByUser(_dailyFactory, idUser);
            }
            return md;
        }
    }
}
