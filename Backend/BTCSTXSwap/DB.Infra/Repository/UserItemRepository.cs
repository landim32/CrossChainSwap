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
    public class UserItemRepository : IUserItemRepository<IUserItemModel, IUserItemDomainFactory>
    {
        private GoblinWarsContext _goblinContext;

        public UserItemRepository(GoblinWarsContext goblinContext)
        {
            _goblinContext = goblinContext;
        }

        private IUserItemModel DbToModel(IUserItemDomainFactory factory, UserItem item)
        {
            if (item == null) {
                return null;
            }
            var md = factory.BuildUserItemModel();
            md.IdItem = item.IdItem;
            md.ItemKey = item.ItemKey;
            md.IdUser = item.IdUser;
            md.Qtde = item.Qtde;
            md.PosX = item.PosX;
            md.PosY = item.PosY;
            return md;
        }

        private void ModelToDb(UserItem info, IUserItemModel md)
        {
            info.IdItem = md.IdItem;
            info.ItemKey = md.ItemKey;
            info.IdUser = md.IdUser;
            info.Qtde = md.Qtde;
            info.PosX = md.PosX;
            info.PosY = md.PosY;
        }

        public IEnumerable<IUserItemModel> ListByUid(IUserItemDomainFactory factory, long idUser)
        {
            return _goblinContext.UserItems
                .Where(x => x.IdUser == idUser)
                .ToList()
                .Select(i => DbToModel(factory, i));
        }
        public IUserItemModel GetByKey(IUserItemDomainFactory factory, long idUser, long key)
        {
            return DbToModel(factory, 
                _goblinContext.UserItems
                .Where(x => x.IdUser == idUser && x.ItemKey == key)
                .FirstOrDefault());
        }

        public IUserItemModel GetById(IUserItemDomainFactory factory, long idItem)
        {
            return DbToModel(factory, _goblinContext.UserItems.Find(idItem));
        }

        public IUserItemModel GetByPosition(IUserItemDomainFactory factory, long idUser, int x, int y)
        {
            return DbToModel(factory,
                _goblinContext.UserItems
                .Where(i => i.IdUser == idUser && i.PosX == x && i.PosY == y)
                .FirstOrDefault());
        }

        public long Insert(IUserItemModel md)
        {
            var info = new UserItem();
            ModelToDb(info, md);
            _goblinContext.UserItems.Add(info);
            _goblinContext.SaveChanges();
            return info.IdItem;
        }

        public long Update(IUserItemModel md)
        {
            var info = _goblinContext.UserItems.Find(md.IdItem);
            ModelToDb(info, md);
            _goblinContext.SaveChanges();
            return info.IdItem;
        }

        public void Delete(long idItem)
        {
            var info = _goblinContext.UserItems.Find(idItem);
            //ModelToDb(info, md);
            _goblinContext.UserItems.Remove(info);
            _goblinContext.SaveChanges();
        }
    }
}
