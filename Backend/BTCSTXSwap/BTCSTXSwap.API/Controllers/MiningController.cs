using Auth.Domain.Interfaces.Services;
using BTCSTXSwap.API.DTO;
using BTCSTXSwap.Domain.Interfaces.Models.Mining;
using BTCSTXSwap.Domain.Interfaces.Services;
using BTCSTXSwap.DTO.Domain;
using BTCSTXSwap.DTO.Goblin;
using BTCSTXSwap.DTO.Mining;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BTCSTXSwap.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MiningController : Controller
    {
        private IUserService _userService;
        private IMiningService _miningService;
        private IGoblinMiningService _goblinMiningService;
        private IGoblinService _goblinService;

        public MiningController(IUserService userService, IMiningService miningService, IGoblinService goblinService, IGoblinMiningService goblinMiningService)
        {
            _userService = userService;
            _miningService = miningService;
            _goblinService = goblinService;
            _goblinMiningService = goblinMiningService;
        }

        [HttpGet("getmining")]
        public ActionResult<MiningResult> GetMining()
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }
                return new MiningResult
                {
                    Mining = _miningService.GetMining(user.Id)
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("getgoblinmining")]
        public ActionResult<GoblinEnergyMiningResult> GetGoblinMining([FromQuery] long idGoblin)
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }
                return new GoblinEnergyMiningResult
                {
                    GoblinEnergy = _goblinMiningService.BuildGoblinMining(idGoblin)
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("rechargeall")]
        public ActionResult<MiningResult> RechargeAll()
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                    return StatusCode(401, "Not Authorized");

                _goblinMiningService.RechargeAll(user.Id);
                _miningService.RefreshMining();
                return new MiningResult
                {
                    Mining = _miningService.GetMining(user.Id)
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("list")]
        public ActionResult<MiningListResult> List([FromQuery] string miningType)
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }
                var miningReward = (MiningRewardTypeEnum)miningType[0];
                return _miningService.ListRanking(user.Id, miningReward);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("listgoblinsmining")]
        public ActionResult<GoblinListResult> ListGoblinsMining()
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }
                return _goblinService.ListMiningByCursor(user.Id, 0);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("listgoblinscanmining")]
        public ActionResult<GoblinListResult> ListGoblinsCanMining([FromQuery] int cursor)
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }
                return _goblinService.ListCanMiningByCursor(user.Id, cursor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("startmining")]
        public ActionResult<StatusResult> StartMining(MiningParam param)
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
                    Sucesso = _miningService.StartMining(user.Id, param.TokenId)
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("stopmining")]
        public ActionResult<StatusResult> StopMining(MiningParam param)
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
                    Sucesso = _miningService.StopMining(user.Id, param.TokenId)
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("listreward")]
        public ActionResult<MiningRewardListResult> ListReward()
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }
                return new MiningRewardListResult
                {
                    Rewards = _miningService.ListReward(user.Id)
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("claimreward")]
        public ActionResult<StatusResult> ClaimReward([FromQuery] long idReward)
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }
                _miningService.ClaimReward(idReward);
                return new StatusResult{ Sucesso = true };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("listhistorydate")]
        public ActionResult<MiningHistoryDateResult> ListHistoryDate([FromQuery] string miningType)
        {
            try
            {
                if (string.IsNullOrEmpty(miningType))
                {
                    throw new Exception("Mining type not informed");
                }
                var miningReward = (MiningRewardTypeEnum)miningType[0];
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }
                return new MiningHistoryDateResult
                {
                    Dates = _miningService.ListHistoryDate(miningReward)
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("listhistory")]
        public ActionResult<MiningHistoryResult> ListHistory([FromQuery] string miningType, DateTime rewardDate)
        {
            try
            {
                if (string.IsNullOrEmpty(miningType))
                {
                    throw new Exception("Mining type not informed");
                }
                var miningReward = (MiningRewardTypeEnum)miningType[0];
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }
                return new MiningHistoryResult
                {
                    Histories = _miningService.ListHistory(miningReward, rewardDate)
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("listhistorybyuser")]
        public ActionResult<MiningHistoryResult> ListHistoryByUser()
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }
                return new MiningHistoryResult
                {
                    Histories = _miningService.ListHistoryByUser(user.Id)
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("claimrankingreward")]
        public ActionResult<StatusResult> ClaimRankingReward([FromQuery] long idMiningHistory)
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }
                _miningService.ClaimRankingReward(user.Id, idMiningHistory);
                return new StatusResult { Sucesso = true };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
