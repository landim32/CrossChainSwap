using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Repository
{
    public interface IGoblinRepository<TModel, TFactory>
    {
        long GetIdByTokenId(long tokenId);
        TModel GetByUid(TFactory factory, long idGoblin);
        TModel GetByTokenId(TFactory factory, long idToken, bool forced = false);
        TModel GetByOldTokenId(TFactory factory, BigInteger oldTokenId);
        int GetSonsCount(long idGoblin);
        IEnumerable<TModel> ListByUserWithCursor(TFactory factory, long idUser, int cursor, int limit);
        IEnumerable<TModel> ListByUser(TFactory factory, long idUser, int page, int itemsPerPage, out int totalPages);
        IEnumerable<TModel> ListSons(TFactory factory, long idGoblin, int page, out int totalPages);
        IEnumerable<TModel> ListBrothers(TFactory factory, long idGoblin, int page, out int totalPages);
        [Obsolete]
        IEnumerable<TModel> ListByUserOld(TFactory factory, long idUser);
        IEnumerable<TModel> ListMiningByUser(TFactory factory, long idUser, int cursor, int limit);
        IEnumerable<TModel> ListCanMiningByUser(TFactory factory, long idUser, int cursor, int limit);
        IEnumerable<TModel> ListAvaliableByUser(TFactory factory, long idUser);
        IEnumerable<TModel> ListGoblinCanBreed(TFactory factory, long idGoblin, int cursor, int limit);
        void Insert(TModel goblin);
        void Update(TModel goblin);
        void SetBaseImagePath(long idGoblin, string baseImagePath);
        //void DisableGoblin(long idUser, BigInteger idToken);
        //void EnableGoblin(long idUser, BigInteger idToken);
        IEnumerable<TModel> GetAllUserGoblins(long idUser, TFactory factory);
        IEnumerable<TModel> GetGoblinsCanFuse(long idGoblin, long idUser, TFactory factory);
        int GetMiningPowerBonus(long idGoblin);
        long GetLastToken();
        bool IsOwner(long idUser, long idGoblin = 0, long tokenId = 0);
        void ChangeUser(long IdGoblin, long newIdUser);
        void DoMint(long idGoblin, long IdUser);
        void Deposit(long idGoblin, long IdUser);
        void Claimed(long idGoblin, long IdUser);
        void SetGoblinParents(long idGoblin, long? idFather, long? idMother);
    }
}
