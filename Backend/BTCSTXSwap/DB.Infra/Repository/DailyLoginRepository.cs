using Core.Domain.Repository;
using DB.Infra.Context;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Infra.Repository
{
    public class DailyLoginRepository : IDailyLoginRepository<IDailyLoginModel, IDailyLoginDomainFactory>
    {
        private GoblinWarsContext _goblinContext;
        private IDailyLoginDayDomainFactory _dailyDayFactory;

        public DailyLoginRepository(GoblinWarsContext goblinContext, IDailyLoginDayDomainFactory dailyDayFactory)
        {
            _goblinContext = goblinContext;
            _dailyDayFactory = dailyDayFactory;
        }

        public void Delete(long id)
        {
            var md = _goblinContext.DailyLogins.Find(id);
            if (md != null) {
                _goblinContext.DailyLogins.Remove(md);
                _goblinContext.SaveChanges();
            }
        }

        public long Insert(IDailyLoginDomainFactory factory, IDailyLoginModel m)
        {
            var md = new DailyLogin {
                IdUser = m.IdUser,
                InsertDate = m.InsertDate,
                DailyLoginDays = m.Days.Select(x => new DailyLoginDay { 
                    LimitDate = x.LimitDate,
                    Day = x.Day,
                    ItemKey = x.ItemKey,
                    Success = x.Success
                }).ToList()
            };
            _goblinContext.DailyLogins.Add(md);
            _goblinContext.SaveChanges();
            return m.Id;
        }

        public void Update(IDailyLoginDomainFactory factory, IDailyLoginModel m)
        {
            var md = new DailyLogin
            {
                Id = m.Id,
                IdUser = m.IdUser,
                InsertDate = m.InsertDate,
                DailyLoginDays = m.Days.Select(x => new DailyLoginDay
                {
                    IdDay = x.IdDay,
                    IdDaily = x.IdDaily,
                    LimitDate = x.LimitDate,
                    Day = x.Day,
                    ItemKey = x.ItemKey,
                    Success = x.Success
                }).ToList()
            };
            _goblinContext.DailyLogins.Update(md);
            _goblinContext.SaveChanges();
        }

        private IDailyLoginDayModel EntityDayToModel(DailyLoginDay d)
        {
            var md = _dailyDayFactory.BuildDailyLoginDayModel();
            md.IdDay = d.IdDay;
            md.IdDaily = d.IdDaily;
            md.Day = d.Day;
            md.ItemKey = d.ItemKey;
            md.Success = d.Success;
            return md;
        }

        private IDailyLoginModel EntityToModel(IDailyLoginDomainFactory factory, DailyLogin d)
        {
            var md = factory.BuildDailyLoginModel();
            md.Id = d.Id;
            md.IdUser = d.IdUser;
            md.InsertDate = d.InsertDate;
            md.Days = d.DailyLoginDays.Select(x => EntityDayToModel(x)).ToList();
            return md;
        }

        public IDailyLoginModel GetLastDailyByUser(IDailyLoginDomainFactory factory, long idUser)
        {
            return _goblinContext.DailyLogins
                .Where(x => x.IdUser == idUser)
                .OrderByDescending(x => x.InsertDate)
                .Select(x => EntityToModel(factory, x))
                .FirstOrDefault();
        }
    }
}
