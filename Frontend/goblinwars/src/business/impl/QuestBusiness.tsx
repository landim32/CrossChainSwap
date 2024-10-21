import { IAuthBusiness } from "../interfaces/IAuthBusiness";
import BusinessResult from "../../dto/business/BusinessResult";
import { BalanceInfo } from "../../dto/domain/BalanceInfo";
import { IQuestBusiness } from "../interfaces/IQuestBusiness";
import { IQuestService } from "../../services/interfaces/IQuestService";
import { UserQuestInfo } from "../../dto/domain/UserQuestInfo";
import { QuestEstimateInfo } from "../../dto/domain/QuestEstimateInfo";
import { ListGoblinResult } from "../../dto/services/ListGoblinResult";
import { UrlWithStringQuery } from "url";
import { JobCategoryInfo } from "../../dto/domain/JobCategoryInfo";

let _questService : IQuestService;
let _authBusiness : IAuthBusiness;

const QuestBusiness : IQuestBusiness = {
  init: (questService: IQuestService, authBusiness: IAuthBusiness) => {
    _questService = questService;
    _authBusiness = authBusiness;
  },
  list: async () => {
    try {
      let ret: BusinessResult<UserQuestInfo[]> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      let retGoblin = await _questService.list(userSession);
      if (retGoblin.sucesso) {
        return {
          ...ret,
          dataResult: retGoblin.quests,
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
      throw new Error("Failed to get quests list");
    }
  },
  listjobs: async () => {
    try {
      let ret: BusinessResult<UserQuestInfo[]> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      let retGoblin = await _questService.listjobs(userSession);
      if (retGoblin.sucesso) {
        return {
          ...ret,
          dataResult: retGoblin.quests,
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
      throw new Error("Failed to get quests list");
    }
  },
  listjobscategories: async () => {
    try {
      let ret: BusinessResult<JobCategoryInfo[]> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      let retGoblin = await _questService.listjobscategories(userSession);
      if (retGoblin.sucesso) {
        return {
          ...ret,
          dataResult: retGoblin.categories,
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
      throw new Error("Failed to get quests list");
    }
  },
  listactivejobs: async () => {
    try {
      let ret: BusinessResult<UserQuestInfo[]> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      let retGoblin = await _questService.listactivejobs(userSession);
      if (retGoblin.sucesso) {
        return {
          ...ret,
          dataResult: retGoblin.quests,
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
      throw new Error("Failed to get quests list");
    }
  },
  getbyid: async (idQuest: number) => {
    try {
      let ret: BusinessResult<UserQuestInfo> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      let retGoblin = await _questService.getbyid(idQuest, userSession);
      if (retGoblin.sucesso) {
        return {
          ...ret,
          dataResult: retGoblin.quest,
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
      throw new Error("Failed to get quest");
    }
  },
  getbykey: async (keyQuest: number) => {
    try {
      let ret: BusinessResult<UserQuestInfo> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      let retGoblin = await _questService.getbykey(keyQuest, userSession);
      if (retGoblin.sucesso) {
        return {
          ...ret,
          dataResult: retGoblin.quest,
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
      throw new Error("Failed to get quest");
    }
  },
  calculate: async (idQuest: number, questKey: number, goblins: number[]) => {
    try {
      let ret: BusinessResult<QuestEstimateInfo> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      let retGoblin = await _questService.calculate(idQuest, questKey, goblins, userSession);
      if (retGoblin.sucesso) {
        return {
          ...ret,
          dataResult: retGoblin.estimate,
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
      throw new Error("Failed to calculate");
    }
  },
  start: async (idQuest: number, questKey: number, goblins: number[]) => {
    try {
      let ret: BusinessResult<boolean> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      let retGoblin = await _questService.start(idQuest, questKey, goblins, userSession);
      if (retGoblin.sucesso) {
        return {
          ...ret,
          dataResult: true,
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
      throw new Error("Failed to start quest");
    }
  },
  execute: async (idQuest: number, goblins: number[]) => {
    try {
      let ret: BusinessResult<UserQuestInfo> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      let retGoblin = await _questService.execute(idQuest, goblins, userSession);
      if (retGoblin.sucesso) {
        return {
          ...ret,
          dataResult: retGoblin.quest,
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
      throw new Error("Failed to execute quest");
    }
  },
  claim: async (idQuest: number) => {
    try {
      let ret: BusinessResult<UserQuestInfo> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      let retGoblin = await _questService.claim(idQuest, userSession);
      if (retGoblin.sucesso) {
        return {
          ...ret,
          dataResult: retGoblin.quest,
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
      throw new Error("Failed to claim quest");
    }
  },
  listGoblins: async (keyQuest: number, cursorGob: number) => {
    try {
      let ret: BusinessResult<ListGoblinResult> = null;
      let userSession = _authBusiness.getGokenSession();
      let retGoblins = await _questService.listGoblins(keyQuest, cursorGob, userSession);
      if (retGoblins.sucesso) {
        return {
          ...ret,
          dataResult: retGoblins
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          mensagem: retGoblins.mensagem
        };
      }
    } catch {
      throw new Error("Failed to get goblin list");
    }
  }
}

export {QuestBusiness};