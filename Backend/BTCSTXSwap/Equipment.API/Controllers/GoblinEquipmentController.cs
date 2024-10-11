using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth.Domain.Interfaces.Services;
using Equipment.API.DTO;
using GoblinWars.Domain.Interfaces.Services;
using GoblinWars.DTO.Goblin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Equipment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GoblinEquipmentController : Controller
    {

        private IUserService _userService;
        private IGoblinService _goblinService;
        private IEquipmentService _equipmentService;
        private IItemService _itemService;

        public GoblinEquipmentController(IUserService userService, IGoblinService goblinService, IEquipmentService equipmentService, IItemService itemService)
        {
            _userService = userService;
            _goblinService = goblinService;
            _equipmentService = equipmentService;
            _itemService = itemService;
        }


        [HttpPost("equipPart")]
        public async Task<ActionResult<GoblinResult>> EquipPart(EquipPartParam param)
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }
                if (!_goblinService.IsOwner(user.Id, param.GoblinId))
                    return StatusCode(401, "Not Authorized");

                var item = _itemService.GetItemModelByKey(param.ItemKey);
                _equipmentService.EquipGoblinPart(param.GoblinId, item, param.Part, user.Id);
                await _goblinService.BuildGoblinImage(param.TokenId);
                var goblinRet = _goblinService.GetGoblinFromDatabase(param.TokenId);
                goblinRet.GoblinEquipment = _equipmentService.GetEquipmentInfo(goblinRet.Id);
                return new GoblinResult()
                {
                    Sucesso = true,
                    Goblin = goblinRet
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
