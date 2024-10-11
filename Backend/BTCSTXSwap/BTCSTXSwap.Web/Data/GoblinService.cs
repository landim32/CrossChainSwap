using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Auth.Domain.Interfaces.Models;
using Auth.Domain.Interfaces.Services;
using BTCSTXSwap.Domain.Impl.Models.Races;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Models;
using BTCSTXSwap.Domain.Interfaces.Services;
using BTCSTXSwap.DTO.Domain;
using BTCSTXSwap.DTO.Enum;

namespace BTCSTXSwap.Web.Data
{
    public class GoblinService
    {
        private IGoblinService _goblinService;
        private IUserService _userService;
        private IMiningService _miningService;
        

        public GoblinService(IGoblinService goblinService, IUserService userService, IMiningService miningService)
        {
            _goblinService = goblinService;
            _userService = userService;
            _miningService = miningService;
        }

        public async Task<Boolean> RebuildGoblins()
        {

            /*try
            {
                var users = _userService.GetAllUserAddress();
                var countGoblins = 0;
                var indiceProcessamento = 1;
                Console.WriteLine("Reconstruindo goblins de " + users.Count() + " usuários");
                foreach (var user in users)
                {
                    Console.WriteLine("Progresso " + indiceProcessamento + "/" + users.Count());
                    Console.WriteLine("Reconstruindo goblins do usuário " + user.PublicAddress);
                    var goblins = _goblinService.GetAllUserGoblins(user.Id);
                    var goblinOnMining = goblins.Where(x => x.Status == GoblinWars.Domain.Impl.Models.Goblins.GoblinStatusEnum.Minning);
                    var goblinsNotSync = goblinOnMining.Count();
                    Console.WriteLine("Usuário " + user.PublicAddress + " possui " + goblinsNotSync + " goblins ativos antes na mineração");
                    if (goblinsNotSync > 16)
                    {
                        Console.WriteLine("Usuário " + user.PublicAddress + " possui mais goblins do que o permitido na mineração");
                        Console.WriteLine("Resetando data de update e status dos goblins do usuário " + user.PublicAddress);
                        foreach (var goblin in goblinOnMining.Skip(16))
                        {
                            _goblinService.DisableGoblin(user.Id, goblin.IdToken);
                        }
                        Console.WriteLine("Criando os objetos de mineração do usuário " + user.PublicAddress);
                        //await _miningService.StartGenerateImageMine(user.Id, user.PublicAddress);
                        Console.WriteLine("Objetos de mineração criados " + user.PublicAddress);
                    }
                    Console.WriteLine("Sincronização dos goblins do usuário " + user.PublicAddress + " finalizada com sucesso");
                    indiceProcessamento++;
                }
                Console.WriteLine("A sincronização de " + users.Count() + " usuários finalizada com sucesso.");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return false;
            }*/
            return false;
        }

        public String BuildGoblinImage(BigInteger genetic, BigInteger equipment)
        {
            //try
            //{
                //var imgGoblin = _goblinService.BuildGoblinImage(genetic, equipment);
                //string data = Convert.ToBase64String((byte[])new ImageConverter().ConvertTo(imgGoblin, typeof(byte[])));

                return "";
            //}
            //catch (Exception ex)
            //{
            //    throw;
            //}
        }

    }
}
