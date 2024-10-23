using System;
using System.Linq;
using System.Threading.Tasks;
using NoChainSwap.Domain.Interfaces.Services;

namespace NoChainSwap.BackgroundService
{
    public class GWScheduleTask
    {
        private IUserService _userService;
        //private IConfigurationService _configurationService;

        //public GWScheduleTask(IUserService userService, IConfigurationService configurationService)
        public GWScheduleTask(IUserService userService)
        {
            _userService = userService;
            //_configurationService = configurationService;
        }

        public void CalculateDaily()
        {
            //_configurationService.CalculateDaily();
        }

        public void DoMinning()
        {
            try
            {
                var users = _userService.GetAllUserAddress();
                /*
                var indiceProcessamento = 1;
                Console.WriteLine("Preparando a mineração de " + users.Count() + " usuários as " + DateTime.UtcNow.ToLongTimeString());
                foreach (var user in users)
                {
                    Console.WriteLine("Progresso " + indiceProcessamento + "/" + users.Count());
                    Console.WriteLine("Checando se o usuário " + user.PublicAddress + " está minerando");
                    var goblins = _goblinService.GetAllUserGoblins(user.Id);
                    Console.WriteLine("Usuário " + user.PublicAddress + " possui " + goblins.Count() + " goblins ativos");
                    var flagNeedSync = false;
                    foreach(var goblin in goblins)
                    {
                        Console.WriteLine("Verificando se o usuário é o dono do goblin " + goblin.TokenId);
                        if (!(await _goblinService.CheckGoblinOwner(user.PublicAddress, goblin.TokenId)))
                        {
                            //É necessário fazer a mesma verificação n vezes para se certificar se não é algum erro de comunicação com a smart chain
                            
                            bool flagDesativa = false;
                            for(var i = 0; i < 3; i++)
                            {
                                await Task.Delay(1000);
                                var flagGoblinOwner = true;
                                try
                                {
                                    flagGoblinOwner = await _goblinService.CheckGoblinOwner(user.PublicAddress, goblin.TokenId);
                                }
                                catch(Exception err)
                                {
                                    Console.WriteLine("Falha ao verificar o owner do goblin: " + err.Message);
                                    flagGoblinOwner = true;
                                }
                                
                                if (!flagGoblinOwner)
                                    flagDesativa = true;
                            }
                            
                            if(flagDesativa)
                            {
                                Console.WriteLine("O usuário não é mais o dono do goblin " + goblin.TokenId + ". Atualizando goblin.");
                                try
                                {
                                    _goblinService.GetGoblinByToken(goblin.TokenId);
                                } catch (Exception err)
                                {
                                    Console.WriteLine("Falha ao sincronizar o goblin. " + err.Message);
                                    Console.WriteLine("Desativando o goblin.");
                                    _goblinService.DisableGoblin(user.Id, goblin.TokenId);
                                }
                                flagNeedSync = true;
                            }
                            
                        }
                    }
                    if(flagNeedSync)
                    {
                        
                    }

                    Console.WriteLine("Sincronização dos goblins do usuário " + user.PublicAddress + " finalizada com sucesso");
                    indiceProcessamento++;
                }
                */
                Console.WriteLine("Executando procedure de mining");
                //_miningService.RefreshMining();
                Console.WriteLine("Procedure executada com sucesso");
                Console.WriteLine("A mineração de " + users.Count() + " usuários finalizada com sucesso.");
            } catch(Exception e)
            {
                Console.WriteLine("Erro ao executar a rotina de mineração");
            }
        }
    }
}
