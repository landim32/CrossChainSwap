using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Models.Gobox
{
    public interface IGoboxModel
    {
        long Id { get; set; }
        long IdUser { get; set; }
        GoboxEnum BoxType { get; set; }
        int Qtdy { get; set; }

        IEnumerable<IGoboxModel> ListByUser(long idUser);
        IGoboxModel GetByGobox(long idUser, GoboxEnum boxType);
        bool CheckOpenedGoblinBox(long idUser);
        bool CheckBuyGoblinBox(long idUser);
        int GetBoxQtdy(long idUser, GoboxEnum boxType);
        void Insert();
        void Update();
        void Delete(long idBox);
    }
}
