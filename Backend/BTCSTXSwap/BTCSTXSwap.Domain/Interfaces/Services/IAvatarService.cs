using System;
using System.Drawing;
using BTCSTXSwap.Domain.Impl.Models;
using BTCSTXSwap.Domain.Interfaces.Models.Goblins;
using BTCSTXSwap.DTO.Goblin;

namespace BTCSTXSwap.Domain.Interfaces.Services
{
    public interface IAvatarService
    {
        AvatarInfo GeneToAvatar(GeneInfo g);
        AvatarInfo GoblinInfoToAvatar(IGoblinModel g);
        BuildAvatarInfo GenerateAvatar(AvatarInfo avatar);
    }
}
