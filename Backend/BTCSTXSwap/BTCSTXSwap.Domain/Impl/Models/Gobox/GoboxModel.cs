using Core.Domain;
using Core.Domain.Repository;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory.Gobox;
using BTCSTXSwap.Domain.Interfaces.Models.Gobox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Models.Gobox
{
    public class GoboxModel: IGoboxModel
    {
        private readonly ILogCore _log;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGoboxDomainFactory _goboxFactory;
        private readonly IGoboxRepository<IGoboxModel, IGoboxDomainFactory> _repGobox;

        public GoboxModel(
            ILogCore log,
            IUnitOfWork unitOfWork,
            IGoboxDomainFactory goboxFactory,
            IGoboxRepository<IGoboxModel, IGoboxDomainFactory> repGobox
        )
        {
            _log = log;
            _unitOfWork = unitOfWork;
            _goboxFactory = goboxFactory;
            _repGobox = repGobox;
        }

        public long Id { get; set; }
        public long IdUser { get; set; }
        public GoboxEnum BoxType { get; set; }
        public int Qtdy { get; set; }

        public IEnumerable<IGoboxModel> ListByUser(long idUser)
        {
            return _repGobox.ListByUser(_goboxFactory, idUser);
        }
        public IGoboxModel GetByGobox(long idUser, GoboxEnum boxType)
        {
            return _repGobox.GetGobox(_goboxFactory, idUser, (int)boxType);
        }
        public int GetBoxQtdy(long idUser, GoboxEnum boxType)
        {
            return _repGobox.GetBoxQtdy(idUser, (int)boxType);
        }
        public void Insert()
        {
            _repGobox.Insert(this);
        }
        public void Update()
        {
            _repGobox.Update(this);
        }
        public void Delete(long idBox)
        {
            _repGobox.Delete(idBox);
        }

        public bool CheckOpenedGoblinBox(long idUser)
        {
            return _repGobox.CheckOpenedGoblinBox(idUser);
        }

        public bool CheckBuyGoblinBox(long idUser)
        {
            return _repGobox.CheckBuyGoblinBox(idUser);
        }
    }
}
