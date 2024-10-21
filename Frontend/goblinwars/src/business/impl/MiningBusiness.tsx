import { IAuthBusiness } from "../interfaces/IAuthBusiness";
import BusinessResult from "../../dto/business/BusinessResult";
import { IMiningBusiness } from "../interfaces/IMiningBusiness";
import { IMiningService } from "../../services/interfaces/IMiningService";
import { MiningInfo } from "../../dto/domain/MiningInfo";
import { GoblinInfo } from "../../dto/domain/GoblinInfo";
import { ListGoblinResult } from "../../dto/services/ListGoblinResult";
import { GoblinMining } from "../../dto/domain/GoblinMining";
import { MiningRankingInfo } from "../../dto/domain/MiningRankingInfo";
import { MiningRewardInfo } from "../../dto/domain/MiningRewardInfo";
import StatusRequest from "../../dto/services/StatusRequest";
import AnalyticsFactory from "../factory/AnalyticsFactory";
import { MiningHistoryInfo } from "../../dto/domain/MiningHistoryInfo";
import MiningListResult from "../../dto/services/MiningListResult";

let _authBusiness : IAuthBusiness;
let _miningService : IMiningService;

const MiningBusiness : IMiningBusiness = {
  init: function (miningService: IMiningService, authBusiness: IAuthBusiness): void {
    _authBusiness = authBusiness;
    _miningService = miningService;
  },
  list: async (miningType: string) => {
    try {
      let ret: BusinessResult<MiningListResult> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      let retGoblin = await _miningService.list(miningType, userSession);
      if (retGoblin.sucesso) {
        return {
          ...ret,
          dataResult: retGoblin,
          sucesso: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          mensagem: retGoblin.mensagem
        };
      }
    } catch {
      throw new Error("Failed to get mining list");
    }
  },
  getmining: async () => {
    try {
      let ret: BusinessResult<MiningInfo> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      let retGoblin = await _miningService.getmining(userSession);
      if (retGoblin.sucesso) {
        return {
          ...ret,
          dataResult: retGoblin.mining,
          sucesso: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          mensagem: retGoblin.mensagem
        };
      }
    } catch {
      throw new Error("Failed to get mining");
    }
  },
  startmining: async (tokenId: number) => {
    try {
      let ret: BusinessResult<boolean> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      let retGoblin = await _miningService.startmining(tokenId, userSession);
      if (retGoblin.sucesso) {
        AnalyticsFactory.Analytics.sendEvent('Mining', 'Goblin start mining');
        return {
          ...ret,
          dataResult: retGoblin.sucesso,
          sucesso: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          mensagem: retGoblin.mensagem
        };
      }
    } catch {
      throw new Error("Failed to start mining");
    }
  },
  stopmining: async (tokenId: number) => {
    try {
      let ret: BusinessResult<boolean> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      let retGoblin = await _miningService.stopmining(tokenId, userSession);
      if (retGoblin.sucesso) {
        AnalyticsFactory.Analytics.sendEvent('Mining', 'Goblin stop mining');
        return {
          ...ret,
          dataResult: retGoblin.sucesso,
          sucesso: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          mensagem: retGoblin.mensagem
        };
      }
    } catch {
      throw new Error("Failed to stop mining");
    }
  },
  listGoblinsMining: async () => {
    try {
      let ret: BusinessResult<GoblinInfo[]> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      let retGoblin = await _miningService.listGoblinsMining(userSession);
      if (retGoblin.sucesso) {
        return {
          ...ret,
          dataResult: retGoblin.goblins,
          sucesso: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          mensagem: retGoblin.mensagem
        };
      }
    } catch {
      throw new Error("Failed to get mining goblins");
    }
  },
  listGoblinsCanMining: async (cursor: number) => {
    try {
      let ret: BusinessResult<ListGoblinResult> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      let retGoblin = await _miningService.listGoblinsCanMining(cursor, userSession);
      if (retGoblin.sucesso) {
        return {
          ...ret,
          dataResult: retGoblin,
          sucesso: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          mensagem: retGoblin.mensagem
        };
      }
    } catch {
      throw new Error("Failed to get goblins that can mining");
    }
  },
  getGoblinMining: async (goblinId: number) => {
    try {
      let ret: BusinessResult<GoblinMining> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      let retGoblin = await _miningService.getGoblinMining(goblinId, userSession);
      if (retGoblin.sucesso) {
        return {
          ...ret,
          dataResult: retGoblin.goblinEnergy,
          sucesso: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          mensagem: retGoblin.mensagem
        };
      }
    } catch {
      throw new Error("Failed to get mining");
    }
  },
  rechargeall: async () => {
    try {
      let ret: BusinessResult<MiningInfo> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      let retGoblin = await _miningService.rechargeall(userSession);
      if (retGoblin.sucesso) {
        AnalyticsFactory.Analytics.sendEvent('Mining', 'Recharge all goblins');
        return {
          ...ret,
          dataResult: retGoblin.mining,
          sucesso: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          mensagem: retGoblin.mensagem
        };
      }
    } catch {
      throw new Error("Failed to get mining");
    }
  },
  listReward: async () => {
    let ret: BusinessResult<MiningRewardInfo[]> = null;
    try {
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      let retGoblin = await _miningService.listreward(userSession);
      if (retGoblin.sucesso) {
        return {
          ...ret,
          dataResult: retGoblin.rewards,
          sucesso: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          mensagem: retGoblin.mensagem
        };
      }
    } catch(err: any) {
      return {
        ...ret,
        sucesso: false,
        mensagem: err.message
      };
    }
  },
  claimReward: async (idReward: number) => {
    let ret: BusinessResult<boolean> = null;
    try {
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        return {
          ...ret,
          sucesso: false,
          dataResult: false,
          mensagem: "Need to login"
        };
      let retGoblin = await _miningService.claimreward(idReward, userSession);
      if (retGoblin.sucesso) {
        AnalyticsFactory.Analytics.sendEvent('Mining', 'Claim reward');
        return {
          ...ret,
          sucesso: true,
          dataResult: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          dataResult: false,
          mensagem: retGoblin.mensagem
        };
      }
    } catch(err: any) {
      return {
        ...ret,
        sucesso: false,
        dataResult: false,
        mensagem: err.message
      };
    }
  },
  listhistorydate: async (miningType: string) => {
    let ret: BusinessResult<string[]> = null;
    try {
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      let retGoblin = await _miningService.listhistorydate(miningType, userSession);
      if (retGoblin.sucesso) {
        return {
          ...ret,
          dataResult: retGoblin.dates,
          sucesso: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          mensagem: retGoblin.mensagem
        };
      }
    } catch(err: any) {
      return {
        ...ret,
        sucesso: false,
        mensagem: err.message
      };
    }
  },
  listhistory: async (miningType: string, rewardDate: string) => {
    let ret: BusinessResult<MiningHistoryInfo[]> = null;
    try {
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      let retGoblin = await _miningService.listhistory(miningType, rewardDate, userSession);
      if (retGoblin.sucesso) {
        return {
          ...ret,
          dataResult: retGoblin.histories,
          sucesso: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          mensagem: retGoblin.mensagem
        };
      }
    } catch(err: any) {
      return {
        ...ret,
        sucesso: false,
        mensagem: err.message
      };
    }
  },
  listHistoryByUser: async () => {
    let ret: BusinessResult<MiningHistoryInfo[]> = null;
    try {
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      let retGoblin = await _miningService.listhistorybyuser(userSession);
      if (retGoblin.sucesso) {
        return {
          ...ret,
          dataResult: retGoblin.histories,
          sucesso: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          mensagem: retGoblin.mensagem
        };
      }
    } catch(err: any) {
      return {
        ...ret,
        sucesso: false,
        mensagem: err.message
      };
    }
  },
  claimrankingreward: async (idMiningHistory: number) => {
    let ret: BusinessResult<boolean> = null;
    try {
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        return {
          ...ret,
          sucesso: false,
          dataResult: false,
          mensagem: "Need to login"
        };
      let retGoblin = await _miningService.claimrankingreward(idMiningHistory, userSession);
      if (retGoblin.sucesso) {
        AnalyticsFactory.Analytics.sendEvent('Mining', 'Claim ranking reward');
        return {
          ...ret,
          sucesso: true,
          dataResult: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          dataResult: false,
          mensagem: retGoblin.mensagem
        };
      }
    } catch(err: any) {
      return {
        ...ret,
        sucesso: false,
        dataResult: false,
        mensagem: err.message
      };
    }
  }
}

export {MiningBusiness};