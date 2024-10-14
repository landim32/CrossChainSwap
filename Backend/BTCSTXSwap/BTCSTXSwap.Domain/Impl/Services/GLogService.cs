using BTCSTXSwap.Domain.Impl.Core;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Factory.GLog;
using BTCSTXSwap.Domain.Interfaces.Models.GLog;
using BTCSTXSwap.Domain.Interfaces.Services;
using BTCSTXSwap.DTO.GLog;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Services
{
    public class GLogService : IGLogService
    {
        private readonly ILogCore _log;
        private readonly IConfiguration _configuration;
        private readonly IGLogDomainFactory _logFactory;
        private readonly IUserDomainFactory _userFactory;

        public GLogService(
            ILogCore log,
            IConfiguration configuration,
            IGLogDomainFactory logFactory,
            IUserDomainFactory userFactory
        )
        {
            _log = log;
            _configuration = configuration;
            _logFactory = logFactory;
            _userFactory = userFactory;
        }

        public void AddLog(long idUser, string msg, LogType logType, string Ip = "")
        {
            var md = _logFactory.BuildGLogModel();
            md.IdUser = idUser;
            md.InsertDate = DateTime.Now;
            md.Ip = Ip;
            md.Message = msg;
            md.LogType = logType.ToString();
            md.Insert();
        }

        private GlogInfo ModelToInfo(IGLogModel md)
        {
            return new GlogInfo
            {
                IdLog = md.IdLog,
                IdUser = md.IdUser,
                Ip = md.Ip,
                InsertDate = md.InsertDate,
                Message = ProccessMessage(md.Message),
                LogType = md.LogType
            };
        }

        private string ProccessMessageGoblin(string msg)
        {
            const string REGEX = @"(__GOBLIN\((\d*)\)__)";
            var mt = Regex.Match(msg, REGEX);
            if (!mt.Success)
            {
                return msg;
            }
            if (mt.Groups.Count >= 3)
            {
                var chave = mt.Groups[1].Value;
                var idStr = mt.Groups[2].Value;
                long idGoblin = 0;
                if (long.TryParse(idStr, out idGoblin))
                {
                    /*
                    var goblin = _goblinFactory.BuildGoblinModel().GetById(idGoblin);
                    if (goblin != null)
                    {
                        return msg.Replace(chave, goblin.Name + " #" + goblin.TokenId.ToString());
                    }
                    else {
                        return msg.Replace(chave, "Unknown #" + idGoblin.ToString());
                    }
                    */
                }
            }
            return msg;
        }

        private string ProccessMessageUser(string msg)
        {
            const string REGEX = @"(__USER\((\d*)\)__)";
            var mt = Regex.Match(msg, REGEX);
            if (!mt.Success)
            {
                return msg;
            }
            if (mt.Groups.Count >= 3)
            {
                var chave = mt.Groups[1].Value;
                var idStr = mt.Groups[2].Value;
                long idUser = 0;
                if (long.TryParse(idStr, out idUser))
                {
                    var user = _userFactory.BuildUserModel().GetById(idUser, _userFactory);
                    if (user != null)
                    {
                        string publicAddr = user.BtcAddress;
                        publicAddr = publicAddr.Substring(0, 6) + "..." + publicAddr.Substring(publicAddr.Length - 4);

                        //return msg.Replace(chave, string.Format("{0} ({1})", user.Name, publicAddr));
                        return msg.Replace(chave, string.Format("{0} ({1})", user.BtcAddress, publicAddr));
                    }
                    else
                    {
                        return msg.Replace(chave, "Unknown");
                    }
                }
            }
            return msg;
        }

        private string ProccessMessageQuest(string msg)
        {
            const string REGEX = @"(__QUEST\((\d*)\)__)";
            var mt = Regex.Match(msg, REGEX);
            if (!mt.Success)
            {
                return msg;
            }
            if (mt.Groups.Count >= 3)
            {
                var chave = mt.Groups[1].Value;
                var idStr = mt.Groups[2].Value;
                int keyQuest = 0;
                if (int.TryParse(idStr, out keyQuest))
                {
                    /*
                    var md = _userQuestDomainFactory.BuildUserQuestModel();
                    md.QuestKey = keyQuest;
                    var q = md.GetQuest();
                    if(q != null)
                        return msg.Replace(chave, string.Format("{0}", q.Name));
                    */
                }
            }
            return msg;
        }

        private string ProccessMessageItem(string msg)
        {
            const string REGEX = @"(__ITEM\((\d*)\)__)";
            var mt = Regex.Match(msg, REGEX);
            if (!mt.Success)
            {
                return msg;
            }
            if (mt.Groups.Count >= 3)
            {
                var chave = mt.Groups[1].Value;
                var idStr = mt.Groups[2].Value;
                long itemKey = 0;
                if (long.TryParse(idStr, out itemKey))
                {
                    /*
                    var usrMd = _userItemDomainFactory.BuildUserItemModel();
                    usrMd.ItemKey = itemKey;
                    try
                    {
                        var itemMd = usrMd.GetItem();
                        if (itemMd != null)
                            return msg.Replace(chave, string.Format("{0}", itemMd.Name));
                    }
                    catch(Exception)
                    {
                        return msg;
                    }
                    */
                }
            }
            return msg;
        }

        private string ProccessMessageBNB(string msg)
        {
            const string REGEX = @"(__BNB\(((\d+(.|,))+(\d+))\)__)";
            var mt = Regex.Match(msg, REGEX);
            if (!mt.Success)
            {
                return msg;
            }
            if (mt.Groups.Count >= 3)
            {
                var chave = mt.Groups[1].Value;
                var bnbStr = mt.Groups[2].Value;
                decimal bnbValue = 0;
                bnbStr = bnbStr.Replace(',', '.');
                if (decimal.TryParse(bnbStr, out bnbValue))
                {
                    return msg.Replace(chave, string.Format("{0:N5} BNB", bnbValue));
                }
            }
            return msg.Replace("  ", " ");
        }

        private string ProccessMessageGOBI(string msg)
        {
            var loop = true;
            const string REGEX = @"(__GOBI\(((\-*\d+(.|,))*(\d+))\)__)";
            var mt = Regex.Match(msg, REGEX);
            if (!mt.Success)
            {
                return msg;
            }
            while (mt.Success && loop)
            {
                if (mt.Groups.Count >= 3)
                {
                    var chave = mt.Groups[1].Value;
                    var bnbStr = mt.Groups[2].Value;
                    decimal bnbValue = 0;
                    bnbStr = bnbStr.Replace(',', '.');
                    if (decimal.TryParse(bnbStr, out bnbValue))
                    {
                        msg = msg.Replace(chave, string.Format("{0:N4} GOBI", bnbValue));
                    }
                    mt = Regex.Match(msg, REGEX);
                }
                else
                {
                    loop = false;
                }
            }
            return msg.Replace("  ", " ");
        }

        private string ProccessMessageGOLD(string msg)
        {
            var loop = true;
            const string REGEX = @"(__GOLD\(((\-*\d+(.|,))*(\d+))\)__)";
            var mt = Regex.Match(msg, REGEX);
            if (!mt.Success)
            {
                return msg;
            }
            while (mt.Success && loop)
            {
                if (mt.Groups.Count >= 3)
                {
                    var chave = mt.Groups[1].Value;
                    var bnbStr = mt.Groups[2].Value;
                    decimal bnbValue = 0;
                    bnbStr = bnbStr.Replace(',', '.');
                    if (decimal.TryParse(bnbStr, out bnbValue))
                    {
                        msg = msg.Replace(chave, string.Format("{0:N4} GOLD COIN", bnbValue));
                    }
                    mt = Regex.Match(msg, REGEX);
                }
                else
                {
                    loop = false;
                }
            }
            return msg.Replace("  ", " ");
        }

        private string ProccessMessage(string msg)
        {
            var msgValue = msg;
            msgValue = ProccessMessageGoblin(msgValue);
            msgValue = ProccessMessageGoblin(msgValue);
            msgValue = ProccessMessageBNB(msgValue);
            msgValue = ProccessMessageGOBI(msgValue);
            msgValue = ProccessMessageGOBI(msgValue);
            msgValue = ProccessMessageUser(msgValue);
            msgValue = ProccessMessageUser(msgValue);
            msgValue = ProccessMessageQuest(msgValue);
            msgValue = ProccessMessageItem(msgValue);
            msgValue = ProccessMessageGOLD(msgValue);
            return msgValue;
        }

        public GLogListResult List(long idUser, int page)
        {
            int balance = 0;
            var logs = _logFactory.BuildGLogModel().List(idUser, page, out balance)
                .Select(x => ModelToInfo(x))
                .ToList();

            return new GLogListResult
            {
                Logs = logs,
                TotalPages = (int)Math.Ceiling((decimal)balance / 100),
                Page = page
            };
        }
    }
}
