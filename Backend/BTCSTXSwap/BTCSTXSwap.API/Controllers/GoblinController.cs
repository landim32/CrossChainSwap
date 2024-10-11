using Auth.Domain.Interfaces.Services;
using BTCSTXSwap.API.DTO;
using BTCSTXSwap.Domain.Interfaces.Services;
using BTCSTXSwap.DTO.Goblin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BTCSTXSwap.Domain.Impl.Core;
using System.Linq;
using System.Numerics;
using Auth.Domain.Interfaces.Models;
using BTCSTXSwap.DTO.Domain;

namespace BTCSTXSwap.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GoblinController : ControllerBase
    {
        private IGoblinService _goblinService;
        private IGoblinBreedService _goblinBreedService;
        private IGoblinUserService _goblinUserService;
        private IUserService _userService;
        private IConfiguration _configuration;
        private IGoblinMiningService _goblinMiningService;
        private IMiningService _miningService;
        private readonly IEquipmentService _equipmentService;

        public GoblinController(IConfiguration configuration, IGoblinService goblinService, IGoblinUserService goblinUserService,
            IMiningService miningService, IUserService userService, IGoblinBreedService goblinBreedService,
            IGoblinMiningService goblinMiningService, IEquipmentService equipmentService)
        {
            _goblinService = goblinService;
            _goblinUserService = goblinUserService;
            _userService = userService;
            _goblinBreedService = goblinBreedService;
            _configuration = configuration;
            _goblinMiningService = goblinMiningService;
            _miningService = miningService;
            _equipmentService = equipmentService;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<NftResult> Nft([FromQuery] long nft)
        {
            try
            {
                var goblin = _goblinService.GetNftFromDatabase(nft);
                var result = new NftResult()
                {
                    Name = goblin.Name,
                    Description = goblin.RaceName + " goblin",
                    Image = goblin.ImageURL,
                    TokenId = goblin.IdToken
                };
                result.Attributes = new List<NftAttribute>();
                result.Attributes.Add(new NftAttribute()
                {
                    TraittType = "Rarity",
                    Value = GoblinUtils.GetGoblinEnumRarity(goblin.Rarity).ToString()
                });
                result.Attributes.Add(new NftAttribute()
                {
                    TraittType = "Mining Power",
                    Value = goblin.MiningPower.ToString()
                });
                result.Attributes.Add(new NftAttribute()
                {
                    TraittType = "Race",
                    Value = goblin.RaceName
                });
                result.Attributes.Add(new NftAttribute()
                {
                    TraittType = "Ear",
                    Value = goblin.EarName
                });
                result.Attributes.Add(new NftAttribute()
                {
                    TraittType = "Skin",
                    Value = goblin.SkinName
                });
                result.Attributes.Add(new NftAttribute()
                {
                    TraittType = "Hair",
                    Value = goblin.HairName
                });
                result.Attributes.Add(new NftAttribute()
                {
                    TraittType = "Eye",
                    Value = goblin.EyeName
                });
                result.Attributes.Add(new NftAttribute()
                {
                    TraittType = "Mouth",
                    Value = goblin.MountName
                });
                return result;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /*[HttpGet("syncbyuser")]
        public async Task<ActionResult<StatusResult>> SyncByUser()
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                    return StatusCode(401, "Not Authorized");
                return new StatusResult()
                {
                    Sucesso = await _goblinService.SyncByUser(user.Id)
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }*/

        [HttpGet("goblin")]
        [AllowAnonymous]
        public ActionResult<GoblinResult> Goblin([FromQuery] long idToken)
        {
            try
            {
                var goblin = _goblinService.GetGoblinByToken(idToken);
                var user = _userService.GetUserInSession(HttpContext);
                if(user != null && goblin != null && user.Id == goblin.IdUser)
                    goblin.GoblinEquipment = _equipmentService.GetEquipmentInfo(goblin.Id);
                return new GoblinResult()
                {
                    Goblin = goblin
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("updateGoblinName")]
        public ActionResult<GoblinResult> UpdateGoblinName(UpdateGoblinParam param)
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }
                if (!(_goblinService.IsOwnerByToken(user.Id, param.TokenId)))
                {
                    return StatusCode(401, "Not Authorized");
                }

                return new GoblinResult()
                {
                    Goblin = _goblinService.SetGoblinName(param.TokenId, param.Name)
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("recharge")]
        public ActionResult<GoblinResult> RechargeGoblin(UpdateGoblinParam param)
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }
                var goblin = _goblinService.GetByTokenId(param.TokenId);
                if (goblin == null)
                {
                    return StatusCode(401, "BTCSTXSwap not found");
                }
                if (!(_goblinService.IsOwner(user.Id, goblin.Id)))
                {
                    return StatusCode(401, "Not Authorized");
                }

                _goblinMiningService.DoRecharge(user.Id, goblin.Id, false);
                //_goblinMiningService.DoRecharge(user.Id, (long)param.GoblinId, param.TokenId, false);
                _miningService.RefreshMining();
                return new GoblinResult()
                {
                    Goblin = _goblinService.GetGoblinByToken(param.TokenId)
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("goblinBrothers")]
        [AllowAnonymous]
        public ActionResult<GoblinListResult> GoblinBrothers([FromQuery] long idToken, int page)
        {
            try
            {
                int totalPages = 0;
                var goblins = _goblinService.ListBrothers(idToken, page, out totalPages);
                return new GoblinListResult()
                {
                    Goblins = goblins,
                    Page = page,
                    TotalPages = totalPages
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("goblinSons")]
        [AllowAnonymous]
        public ActionResult<GoblinListResult> GoblinSons([FromQuery] long idToken, int page)
        {
            try
            {
                int totalPages = 0;
                var goblins = _goblinService.ListSons(idToken, page, out totalPages);
                return new GoblinListResult()
                {
                    Goblins = goblins,
                    Page = page,
                    TotalPages = totalPages
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("spouseCandidates")]
        public ActionResult<GoblinListResult> SpouseCandidates([FromQuery] long idToken, int cursorGob)
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }
                if (!(_goblinService.IsOwnerByToken(user.Id, idToken)))
                {
                    return StatusCode(401, "Not Authorized");
                }
                var ret = _goblinBreedService.ListGoblinCanBreed(idToken, cursorGob);
                return ret;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("goblinscanfuse")]
        public ActionResult<GoblinListResult> GoblinsCanFuse([FromQuery] long idToken)
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }
                if (!(_goblinService.IsOwnerByToken(user.Id, idToken)))
                {
                    return StatusCode(401, "Not Authorized");
                }
                var goblin = _goblinService.GetGoblinByToken(idToken);
                if (goblin == null) {
                    throw new Exception("BTCSTXSwap not found.");
                }
                return new GoblinListResult()
                {
                    Goblins = _goblinService.ListGoblinsCanFuse(user.Id, goblin.Id),
                    Sucesso = true
                }; ;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("breedCost")]
        public ActionResult<BreedResult> BreedCost([FromQuery] long parent1, long parent2)
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }
                if (!(_goblinService.IsOwnerByToken(user.Id, parent1)))
                {
                    return StatusCode(401, "Not Authorized");
                }
                if (!(_goblinService.IsOwnerByToken(user.Id, parent2)))
                {
                    return StatusCode(401, "Not Authorized");
                }

                return new BreedResult()
                {
                    Sucesso = true,
                    BreedCost = _goblinBreedService.GetBreedCost(parent1, parent2),
                    BreedRarity = (int) _goblinBreedService.GetBreedRarity(parent1, parent2)
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("listbyuser")]
        public ActionResult<GoblinListResult> ListByUser([FromQuery] int page, int itemsPerPage)
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                    return StatusCode(401, "Not Authorized");

                int balance = 0;
                var goblins = _goblinService.ListByUser(user.Id, page == 0 ? 1 : page, itemsPerPage, out balance);
                return new GoblinListResult() {
                    Goblins = goblins,
                    Page = page,
                    //TotalPages = (long)Math.Ceiling((await _goblinUserService.GetBalance(user.PublicAddress)).GoblinBalance / int.Parse(_configuration["Contract:ItensForPage"]))
                    TotalPages = balance
                };
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("listinfinity")]
        public ActionResult<GoblinListResult> ListInfinity([FromQuery] int cursorGob)
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                    return StatusCode(401, "Not Authorized");

                return _goblinService.ListByCursor(user.PublicAddress, cursorGob);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("breed")]
        public ActionResult<GoblinTokenResult> Breed([FromQuery] long token1, long token2)
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }
                if (!(_goblinService.IsOwnerByToken(user.Id, token1)))
                {
                    return StatusCode(401, "Not Authorized");
                }
                if (!(_goblinService.IsOwnerByToken(user.Id, token2)))
                {
                    return StatusCode(401, "Not Authorized");
                }
                return new GoblinTokenResult
                { 
                    Sucesso = true,
                    TokenId = _goblinBreedService.Breed(user.Id, token1, token2)
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("fusion")]
        public ActionResult<GoblinTokenResult> Fusion([FromQuery] long token1, long token2)
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }
                if (!(_goblinService.IsOwnerByToken(user.Id, token1)))
                {
                    return StatusCode(401, "Not Authorized");
                }
                if (!(_goblinService.IsOwnerByToken(user.Id, token2)))
                {
                    return StatusCode(401, "Not Authorized");
                }
                return new GoblinTokenResult
                {
                    Sucesso = true,
                    TokenId = _goblinBreedService.Fusion(user.Id, token1, token2)
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("fusionCost")]
        public ActionResult<BreedResult> FusionCost([FromQuery] long tokenId)
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }

                return new BreedResult { 
                    Sucesso = true,
                    BreedCost = _goblinBreedService.GetFusionCost(tokenId)
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("transfer")]
        public ActionResult<StatusResult> Transfer([FromQuery] long tokenId, string address)
        {
            try
            {
                var user = _userService.GetUserInSession(HttpContext);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }
                if (!(_goblinService.IsOwnerByToken(user.Id, tokenId)))
                {
                    return StatusCode(401, "Not Authorized");
                }
                _goblinService.Transfer(tokenId, address);
                return new StatusResult
                {
                    Sucesso = true
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /*[HttpGet("migrateAllToDb")]
        public async Task<ActionResult> MigrateAllToDb()
        {
            try
            {
                try
                {
                    var users = _userService.GetAllUserAddress();
                    var indiceProcessamento = 1;
                    Console.WriteLine("Reconstruindo goblins de " + users.Count() + " usuários");
                    foreach (var user in users)
                    {
                        Console.WriteLine("Progresso " + indiceProcessamento + "/" + users.Count());
                        Console.WriteLine("Reconstruindo goblins do usuário " + user.PublicAddress);
                        try
                        {
                            await _goblinService.SyncByUser(user.Id);
                        } catch (Exception err)
                        {
                            Console.WriteLine("Falha ao reconstruir os goblins: " + err.Message);
                        }
                        indiceProcessamento++;
                    }
                    Console.WriteLine("A sincronização de " + users.Count() + " usuários finalizada com sucesso.");
                    return Ok();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                    return StatusCode(500, e.Message); ;
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }*/

        [HttpGet("syncDoAmor")]
        [AllowAnonymous]
        public async Task<bool> Sync([FromQuery] int page)
        {
            try
            {
                try
                {
                    var users = _userService.GetAllUserAddress();
                    var indiceProcessamento = 1;
                    Console.WriteLine("Reconstruindo goblins de " + users.Count() + " usuários");
                    foreach (var user in users)
                    {
                        Console.WriteLine("Progresso " + indiceProcessamento + "/" + users.Count());
                        Console.WriteLine("Reconstruindo goblins do usuário " + user.PublicAddress);
                        var goblins = _goblinService.GetAllUserGoblins(user.Id);
                        var goblinsNotSync = goblins.Count();
                        Console.WriteLine("Usuário " + user.PublicAddress + " possui " + goblinsNotSync + " goblins");
                        var flagSync = false;
                        int cursor = 0;
                        foreach(var goblin in goblins)
                        {
                            try
                            {
                                Console.WriteLine("Sincronizando imagem do goblin " + goblin.TokenId);
                                await _goblinService.BuildGoblinImage(goblin.TokenId);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Falha desconhecida ao sincronizar a imagem do goblin " + goblin.TokenId + "\nDescrição: " + e.Message);
                                continue;
                            }
                        }
                        indiceProcessamento++;
                    }
                    Console.WriteLine("A sincronização de " + users.Count() + " usuários finalizada com sucesso.");
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /*[HttpGet("syncDoAmorUser")]
        public async Task<bool> SyncUser()
        {
            try
            {
                try
                {
                    var users = new List<IUserModel>()
                    {
                        _userService.GetUSerByID(721),
                    };
                    var countGoblins = 0;
                    var indiceProcessamento = 1;
                    Console.WriteLine("Reconstruindo goblins de " + users.Count() + " usuários");
                    foreach (var user in users)
                    {
                        Console.WriteLine("Progresso " + indiceProcessamento + "/" + users.Count());
                        Console.WriteLine("Reconstruindo goblins do usuário " + user.PublicAddress);
                        var goblins = _goblinService.GetAllUserGoblins(user.Id);
                        var goblinsNotSync = goblins.Count();
                        Console.WriteLine("Usuário " + user.PublicAddress + " possui " + goblinsNotSync + " goblins ativos antes da sincronização");
                        Console.WriteLine("Resetando data de update dos goblins do usuário " + user.PublicAddress);
                        foreach (var goblin in goblins)
                        {
                            _goblinService.DisableGoblin(user.Id, goblin.IdToken);
                        }
                        var flagSync = false;
                        long cursor = 0;
                        while (!flagSync)
                        {
                            try
                            {
                                Console.WriteLine("Acessando os goblins a partir do cursor " + cursor);
                                var goblinResult = await _goblinService.ListByCursor(user.PublicAddress, cursor);
                                if (goblinResult.Sucesso)
                                {
                                    if (goblinResult.CursorGob != cursor)
                                    {
                                        foreach (var goblinAtivo in goblinResult.Goblins)
                                        {
                                            _goblinService.EnableGoblin(user.Id, BigInteger.Parse(goblinAtivo.IdToken));
                                            if (goblinAtivo.Status == 3 && !_goblinMiningService.HasRecharge(goblinAtivo.Id))
                                            {
                                                _goblinMiningService.DoRecharge(user.Id, goblinAtivo.Id, long.Parse(goblinAtivo.IdToken.ToString()), true);
                                            }
                                        }
                                        cursor = goblinResult.CursorGob;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Sincronização dos goblins do usuário " + user.PublicAddress + " finalizada com sucesso");
                                        flagSync = true;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Falha de rede ao sincronizar os goblins do usuário " + user.PublicAddress);
                                    flagSync = true;
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Falha desconhecida ao sincronizar os goblins do usuário " + user.PublicAddress + "\nDescrição: " + e.Message);
                                flagSync = true;
                            }
                        }

                        var goblinsSincronizados = _goblinService.GetAllUserGoblins(user.Id);
                        var goblinsSincronizadosCount = goblinsSincronizados.Count();
                        var diferencaGoblins = goblinsNotSync - goblinsSincronizadosCount;
                        if (diferencaGoblins > 0)
                            Console.WriteLine("Durante a sincronização dos goblins do usuário " + user.PublicAddress + " Foi identificada a divergência de ativo em " + diferencaGoblins + " Goblins");
                        countGoblins += goblinsSincronizadosCount;
                        indiceProcessamento++;
                    }
                    Console.WriteLine("A sincronização de " + users.Count() + " usuários finalizada com sucesso.");
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }*/

    }
}
