import BusinessResult from "../../dto/business/BusinessResult";
import { GoblinInfo } from "../../dto/domain/GoblinInfo";
import { GoblinMining } from "../../dto/domain/GoblinMining";
import { MiningHistoryInfo } from "../../dto/domain/MiningHistoryInfo";
import { MiningInfo } from "../../dto/domain/MiningInfo";
import { MiningRewardInfo } from "../../dto/domain/MiningRewardInfo";
import { ListGoblinResult } from "../../dto/services/ListGoblinResult";
import { MiningHistoryDateResult } from "../../dto/services/MiningHistoryDateResult";
import MiningListResult from "../../dto/services/MiningListResult";
import { IMiningService } from "../../services/interfaces/IMiningService";
import { IAuthBusiness } from "./IAuthBusiness";

export interface IMiningBusiness {
  init: (miningService: IMiningService, authBusiness: IAuthBusiness) => void;
  list: (miningType: string) => Promise<BusinessResult<MiningListResult>>;
  listGoblinsMining: () => Promise<BusinessResult<GoblinInfo[]>>;
  listGoblinsCanMining: (cursor: number) => Promise<BusinessResult<ListGoblinResult>>;
  getmining: () => Promise<BusinessResult<MiningInfo>>;
  rechargeall: () => Promise<BusinessResult<MiningInfo>>;
  getGoblinMining: (goblinId: number) => Promise<BusinessResult<GoblinMining>>;
  startmining: ( tokenId: number ) => Promise<BusinessResult<boolean>>;
  stopmining: ( tokenId: number ) => Promise<BusinessResult<boolean>>;
  listReward: () => Promise<BusinessResult<MiningRewardInfo[]>>;
  claimReward: (idReward: number) => Promise<BusinessResult<boolean>>;
  listhistorydate: (miningType: string) => Promise<BusinessResult<string[]>>;
  listhistory: (miningType: string, rewardDate: string) => Promise<BusinessResult<MiningHistoryInfo[]>>;
  listHistoryByUser: () => Promise<BusinessResult<MiningHistoryInfo[]>>;
  claimrankingreward: (idMiningHistory: number) => Promise<BusinessResult<boolean>>;
}