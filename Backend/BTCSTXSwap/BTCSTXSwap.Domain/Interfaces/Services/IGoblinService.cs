using BTCSTXSwap.Domain.Impl.Models.Goblins;
using BTCSTXSwap.Domain.Interfaces.Models;
using BTCSTXSwap.Domain.Interfaces.Models.Goblins;
using BTCSTXSwap.DTO.Goblin;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Interfaces.Services
{
    public interface IGoblinService
    {
        IGoblinModel GetByUid(long idGoblin);
        IGoblinModel GetByTokenId(long tokenId);
        long GetIdbyTokenId(long tokenId);
        GoblinInfo GetInfoByUid(long idGoblin);
        IEnumerable<GoblinInfo> ListByUser(long idUser, int page, int itemsPerPage, out int balance);
        GoblinListResult ListByCursor(string userAddress, int cursor);
        GoblinInfo GetGoblinByToken(long tokenId);
        GoblinInfo GetGoblinFromDatabase(long tokenId);
        GoblinInfo GetNftFromDatabase(long tokenId);
        IEnumerable<GoblinInfo> ListBrothers(long tokenId, int page, out int balance);
        IEnumerable<GoblinInfo> ListSons(long tokenId, int page, out int balance);
        Task<long> SonsBalance(BigInteger tokenId);
        Task<long> BrothersBalance(BigInteger tokenId);
        GoblinInfo ModelToInfo(IGoblinModel g);
        Task<bool> GenerateImage(long idGoblin);
        //Task<bool> CheckGoblinOwner(string userAddress, BigInteger tokenId);
        Task BuildGoblinImage(long tokenId);
        GoblinInfo SetGoblinName(long tokenId, string name);
        void UpdateStatus(long tokenId, GoblinStatusEnum status, DateTime? busy = null);
        void CheckImageMine(long tokenId);
        GoblinListResult ListMiningByCursor(long userId, int cursorGob);
        GoblinListResult ListCanMiningByCursor(long userId, int cursorGob);
        IEnumerable<IGoblinModel> GetAllUserGoblins(long idUser);
        [Obsolete]
        GoblinInfo GetLastUserGoblin(string userAddress);
        IEnumerable<GoblinInfo> ListGoblinsCanFuse(long idUser, long idGoblin);
        void Transfer(long tokenId, string userAddress);
        bool IsOwner(long idUser, long idGoblin);
        bool IsOwnerByToken(long idUser, long tokenId);
        void RefreshParents(long idUser);
    }
}
