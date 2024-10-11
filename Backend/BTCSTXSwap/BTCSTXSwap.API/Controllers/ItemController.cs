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
    public class ItemController : Controller
    {
        private IUserService _userService;
        private IUserItemService _userItemService;
        private IItemService _itemService;

        public ItemController(IUserService userService, IUserItemService userItemService, IItemService itemService)
        {
            _userService = userService;
            _userItemService = userItemService;
            _itemService = itemService;
        }

        /*
        void SellAllTrash(long idUser);
         */

        [HttpGet("list")]
        public ActionResult<UserItemListResult> List()
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }

                return new UserItemListResult
                {
                    Itens = _userItemService.List(user.Id)
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("getbykey")]
        public ActionResult<UserItemResult> GetByKey([FromQuery] long itemKey)
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }
                return new UserItemResult
                {
                    Item = _userItemService.GetByKey(user.Id, itemKey, true)
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost("sell")]
        public ActionResult<StatusResult> Sell(AddRemoveItemParam param)
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }
                _userItemService.Sell(user.Id, param.Key, param.Qtde);
                return new StatusResult();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("move")]
        public ActionResult<StatusResult> Move(MoveItemParam param)
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }
                return new StatusResult
                {
                    Sucesso = _userItemService.Move(user.Id, param.IdItem, param.X, param.Y)
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("destroyitem")]
        public ActionResult<ItemDestroyResult> DestroyItem(DestroyItemParam param)
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }

                return _userItemService.DestroyItem(user.Id, param.IdItem, param.Qtde);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("sellalltrash")]
        public ActionResult<StatusResult> SellAllTrash()
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }
                _userItemService.SellAllTrash(user.Id);
                return new StatusResult();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
