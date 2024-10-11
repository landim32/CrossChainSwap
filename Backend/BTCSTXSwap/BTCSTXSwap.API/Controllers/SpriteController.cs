using Auth.Domain.Interfaces.Services;
using BTCSTXSwap.API.DTO;
using BTCSTXSwap.Domain.Interfaces.Services;
using BTCSTXSwap.DTO.Domain;
using BTCSTXSwap.DTO.Items;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTCSTXSwap.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SpriteController : Controller
    {
        private IUserService _userService;
        private IAvatarService _avatarService;
        private IGoblinService _goblinService;
        private IMiningSpriteService _miningSpriteService;
        private IEquipmentService _equipmentService;

        private const string SPRITE_DIR = @"C:\Sprites";

        public SpriteController(
            IUserService userService, 
            IAvatarService avatarService, 
            IGoblinService goblinService,
            IMiningSpriteService goblinMiningService,
            IEquipmentService equipmentService
        )
        {
            _userService = userService;
            _avatarService = avatarService;
            _goblinService = goblinService;
            _miningSpriteService = goblinMiningService;
            _equipmentService = equipmentService;
        }

        [HttpGet("generateavatar")]
        public ActionResult<StatusResult> GenerateAvatar([FromQuery] long tokenId)
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }
                var goblin = _goblinService.GetByTokenId(tokenId);
                var avatar = _avatarService.GoblinInfoToAvatar(goblin);
                _equipmentService.BuildAvatarEquipment(avatar, goblin.Id);

                var b = _avatarService.GenerateAvatar(avatar);

                var headFile = SPRITE_DIR + string.Format(@"\head-{0}.png", goblin.TokenId);
                var bodyFile = SPRITE_DIR + string.Format(@"\body-{0}.png", goblin.TokenId);
                b.HeadImage.Save(headFile);
                b.FullImage.Save(bodyFile);
                return new StatusResult { Sucesso = true };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /*[HttpGet("generateminingsprite")]
        public async Task<ActionResult<StatusResult>> GenerateMiningSprite([FromQuery] long tokenId)
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }
                var goblin = _goblinService.GetByTokenId(tokenId);
                var avatar = _avatarService.GoblinInfoToAvatar(goblin);
                _equipmentService.BuildAvatarEquipment(avatar, goblin.Id);
                //var avatarRet = _avatarService.GenerateAvatar(avatar);
                await _goblinService.BuildGoblinImage(tokenId);
                goblin = _goblinService.GetByTokenId(tokenId);
                var b = await _miningSpriteService.GenerateSprite(goblin);

                var miningFile = SPRITE_DIR + string.Format(@"\mining-{0}.png", goblin.TokenId);
                var tiredFile = SPRITE_DIR + string.Format(@"\tired-{0}.png", goblin.TokenId);
                b.MiningSprite.Save(miningFile);
                b.TiredSprite.Save(tiredFile);
                return new StatusResult { Sucesso = true };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }*/
    }
}
