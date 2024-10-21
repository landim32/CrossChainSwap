import BusinessResult from "../../dto/business/BusinessResult";
import { BalanceInfo } from "../../dto/domain/BalanceInfo";
import { JobCategoryInfo } from "../../dto/domain/JobCategoryInfo";
import { QuestEstimateInfo } from "../../dto/domain/QuestEstimateInfo";
import { UserQuestInfo } from "../../dto/domain/UserQuestInfo";
import { ListGoblinResult } from "../../dto/services/ListGoblinResult"; 
import { IQuestService } from "../../services/interfaces/IQuestService";
import { IAuthBusiness } from "./IAuthBusiness";

export interface IQuestBusiness {
  init: (questService: IQuestService, authBusiness: IAuthBusiness) => void;
  list: () => Promise<BusinessResult<UserQuestInfo[]>>;
  listjobs: () => Promise<BusinessResult<UserQuestInfo[]>>;
  listactivejobs: () => Promise<BusinessResult<UserQuestInfo[]>>;
  listjobscategories: () => Promise<BusinessResult<JobCategoryInfo[]>>;
  getbyid: (idQuest: number) => Promise<BusinessResult<UserQuestInfo>>;
  getbykey: (keyQuest: number) => Promise<BusinessResult<UserQuestInfo>>;
  calculate: (idQuest: number, questKey: number, goblins: number[]) => Promise<BusinessResult<QuestEstimateInfo>>;
  start: (idQuest: number, questKey: number, goblins: number[]) => Promise<BusinessResult<boolean>>;
  execute: (idQuest: number, goblins: number[]) => Promise<BusinessResult<UserQuestInfo>>;
  claim: (idQuest: number) => Promise<BusinessResult<UserQuestInfo>>;
  listGoblins: (keyQuest: number, cursorGob: number) => Promise<BusinessResult<ListGoblinResult>>;
}