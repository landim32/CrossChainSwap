using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Repository
{
    public interface IReferralUserRepository<TModel, TFactory>
    {
        IEnumerable<TModel> ListByUser(TFactory factory, long idUser);
    }
}
