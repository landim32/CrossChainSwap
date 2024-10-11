using Core.Domain.Repository;
using DB.Infra.Context;
using BTCSTXSwap.Domain.Impl.Core;
using BTCSTXSwap.Domain.Interfaces.Factory.Gobox;
using BTCSTXSwap.Domain.Interfaces.Models.Gobox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Infra.Repository
{
    public class GoboxRepository : IGoboxRepository<IGoboxModel, IGoboxDomainFactory>
    {
        private GoblinWarsContext _goblinContext;

        public GoboxRepository(GoblinWarsContext goblinContext)
        {
            _goblinContext = goblinContext;
        }

        private IGoboxModel DbToModel(IGoboxDomainFactory factory, Gobox item)
        {
            if (item == null)
            {
                return null;
            }
            var md = factory.BuildGoboxModel();
            md.Id = item.Id;
            md.IdUser = item.IdUser;
            md.BoxType = (GoboxEnum) item.BoxType;
            md.Qtdy = item.Qtdy;
            return md;
        }

        private void ModelToDb(Gobox info, IGoboxModel md)
        {
            info.Id = md.Id;     
            info.IdUser = md.IdUser;
            info.BoxType = (int)md.BoxType;
            info.Qtdy = md.Qtdy;
        }

        public IEnumerable<IGoboxModel> ListByUser(IGoboxDomainFactory factory, long idUser)
        {
            return _goblinContext.Goboxes
                .Where(x => x.IdUser == idUser)
                .ToList()
                .Select(i => DbToModel(factory, i));
        }

        public IGoboxModel GetGobox(IGoboxDomainFactory factory, long idUser, int boxType)
        {
            return DbToModel(factory, _goblinContext.Goboxes
                .Where(x => x.IdUser == idUser && x.BoxType == boxType)
                .FirstOrDefault()
            );
        }

        public int GetBoxQtdy(long idUser, int boxType)
        {
            return _goblinContext.Goboxes
                .Where(x => x.IdUser == idUser && x.BoxType == boxType)
                .Select(x => x.Qtdy)
                .FirstOrDefault();
        }

        public void Insert(IGoboxModel md)
        {
            var info = new Gobox();
            ModelToDb(info, md);
            _goblinContext.Goboxes.Add(info);
            _goblinContext.SaveChanges();
        }

        public void Update(IGoboxModel md)
        {
            var info = _goblinContext.Goboxes.Find(md.Id);
            ModelToDb(info, md);
            _goblinContext.SaveChanges();
        }

        public void Delete(long idBox)
        {
            var info = _goblinContext.Goboxes.Find(idBox);
            _goblinContext.Goboxes.Remove(info);
            _goblinContext.SaveChanges();
        }

        public bool CheckOpenedGoblinBox(long idUser)
        {
            return _goblinContext.Logs.Where(x => x.IdUser == idUser && x.LogType == LogType.OpenGoblinBox.ToString()).Any();
        }

        public bool CheckBuyGoblinBox(long idUser)
        {
            return _goblinContext.Logs.Where(x => x.IdUser == idUser && x.LogType == LogType.BuyGoblinBox.ToString()).Any();
        }
    }
}
