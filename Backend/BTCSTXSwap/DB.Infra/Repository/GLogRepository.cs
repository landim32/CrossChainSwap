using Core.Domain.Repository;
using DB.Infra.Context;
using BTCSTXSwap.Domain.Interfaces.Factory.GLog;
using BTCSTXSwap.Domain.Interfaces.Models.GLog;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Infra.Repository
{
    public class GLogRepository: IGLogRepository<IGLogModel, IGLogDomainFactory>
    {
        private GoblinWarsContext _goblinContext;
        private IConfiguration _configuration;

        public GLogRepository(GoblinWarsContext goblinContext, IConfiguration configuration)
        {
            _goblinContext = goblinContext;
            _configuration = configuration;
        }


        private IGLogModel DbToModel(IGLogDomainFactory factory, Log info)
        {
            if (info == null)
            {
                return null;
            }
            var md = factory.BuildGLogModel();
            md.IdLog = info.IdLog;
            md.IdUser = info.IdUser;
            md.Ip = info.Ip;
            md.InsertDate = info.InsertDate;
            md.Message = info.Message;
            md.LogType = info.LogType;
            return md;
        }

        private void ModelToDb(Log info, IGLogModel md)
        {
            info.IdLog = md.IdLog;
            info.IdUser = md.IdUser;
            info.Ip = md.Ip;
            info.InsertDate = md.InsertDate;
            info.Message = md.Message;
            info.LogType = md.LogType;
        }

        public IEnumerable<IGLogModel> List(IGLogDomainFactory factory, long idUser, int page, out int balance)
        {
            var q = _goblinContext.Logs.Where(x => x.IdUser == idUser);
            int maxPages = 100;
            balance = q.Count();
            int pg = page;
            if (pg < 1)
            {
                pg = 1;
            }
            int skip = maxPages * (pg - 1);

            return q.OrderByDescending(x => x.InsertDate).Skip(skip).Take(maxPages).ToList()
                .Select(i => DbToModel(factory, i));
        }
        public void Insert(IGLogModel md)
        {
            Log info = new Log();
            ModelToDb(info, md);
            _goblinContext.Logs.Add(info);
            _goblinContext.SaveChanges();
            md.IdLog = info.IdLog;
        }
    }
}
