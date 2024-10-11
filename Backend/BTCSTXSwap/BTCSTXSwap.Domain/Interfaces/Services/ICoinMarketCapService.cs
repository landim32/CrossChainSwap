using BTCSTXSwap.DTO.CoinMarketCap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Services
{
    public interface ICoinMarketCapService
    {
        CoinSwapInfo GetCurrentPrice(string slugOrig, string sligDest);
    }
}
