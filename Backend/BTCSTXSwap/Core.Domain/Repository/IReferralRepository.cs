using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Repository
{
    public interface IReferralRepository<TModel, TFactory>
    {
        TModel GetReferral(TFactory factory, long idUser);
        long Update(TModel md);
    }
}
