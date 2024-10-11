using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public interface IGobiContract
    {
        Task<BigInteger> GobiBalance(string adress);
    }
}
