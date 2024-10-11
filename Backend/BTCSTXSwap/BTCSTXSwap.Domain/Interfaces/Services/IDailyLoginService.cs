using BTCSTXSwap.Domain.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Services
{
    public interface IDailyLoginService
    {
        IDailyLoginModel GetLastByUser(long idUser);
        void DoLogin(long idUser);
    }
}
