import { GoblinMiningResult } from "../../dto/services/GoblinMiningResult";
import { ListGoblinResult } from "../../dto/services/ListGoblinResult";
import { MiningHistoryDateResult } from "../../dto/services/MiningHistoryDateResult";
import { MiningHistoryResult } from "../../dto/services/MiningHistoryResult";
import MiningListResult from "../../dto/services/MiningListResult";
import { MiningResult } from "../../dto/services/MiningResult";
import { MiningRewardListResult } from "../../dto/services/MiningRewardListResult";
import StatusRequest from "../../dto/services/StatusRequest";
import IHttpClient from "../../infra/interface/IHttpClient";


export interface IMiningService {
    init: (htppClient : IHttpClient) => void;
    list: (miningType: string, tokenAuth: string) => Promise<MiningListResult>;
    listGoblinsMining: (
        tokenAuth: string
    ) => Promise<ListGoblinResult>;
    listGoblinsCanMining: (
        cursor: number,
        tokenAuth: string
    ) => Promise<ListGoblinResult>;
    getmining: (
        tokenAuth: string
    ) => Promise<MiningResult>;
    rechargeall: (
        tokenAuth: string
    ) => Promise<MiningResult>;
    getGoblinMining: (
        goblinId: number, 
        tokenAuth: string
    ) => Promise<GoblinMiningResult>;
    startmining: (
        tokenId: number,
        tokenAuth: string
    ) => Promise<StatusRequest>;
    stopmining: (
        tokenId: number,
        tokenAuth: string
    ) => Promise<StatusRequest>;
    listreward: (tokenAuth: string) => Promise<MiningRewardListResult>;
    claimreward: (idReward: number, tokenAuth: string) => Promise<StatusRequest>;
    listhistorydate: (miningType: string, tokenAuth: string) => Promise<MiningHistoryDateResult>;
    listhistory: (miningType: string, rewardDate: string, tokenAuth: string) => Promise<MiningHistoryResult>;
    listhistorybyuser: (tokenAuth: string) => Promise<MiningHistoryResult>;
    claimrankingreward: (idMiningHistory: number, tokenAuth: string) => Promise<StatusRequest>;
}