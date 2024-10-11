using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;

namespace Core.Domain
{
    public interface IBornContract
    {
        Task<IEnumerable<BigInteger>> CanBreed(string ownerAddress, BigInteger parent, IEnumerable<BigInteger> candidates);
        Task<BigInteger> BreedCost(BigInteger parent1, BigInteger parent2);

    }
}
