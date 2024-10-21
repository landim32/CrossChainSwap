import { LoadingMining } from "../business/LoadingMining";
import { GoblinInfo } from "../domain/GoblinInfo";
import { GoblinMining } from "../domain/GoblinMining";
import { MinerPosInfo } from "../domain/MinerPosInfo";
import { MiningGoblinInfo } from "../domain/MiningGoblinInfo";
import { MiningHistoryInfo } from "../domain/MiningHistoryInfo";
import { MiningInfo } from "../domain/MiningInfo";
import { MiningRankingInfo } from "../domain/MiningRankingInfo";
import { MiningRewardInfo } from "../domain/MiningRewardInfo";
import ProviderResult from "./ProviderResult";
import ProviderResultDetail from "./ProviderResultDetail";


interface IMiningProvider {
    listRankTop100: () => Promise<ProviderResult>;
    listRankMonthly: () => Promise<ProviderResult>;
    listRankWeekly: () => Promise<ProviderResult>;
    listGoblinsMining: () => Promise<ProviderResult>;
    listGoblinsCanMining: (reset: boolean) => Promise<ProviderResult>;
    info: (quiet: boolean) => Promise<ProviderResult>;
    rechargeall: () => Promise<ProviderResult>;
    startMining: (goblin: GoblinInfo) => Promise<ProviderResult>;
    stopMining: (goblin: GoblinInfo) => Promise<ProviderResult>;
    rechargeGoblin: (tokenId: number) => Promise<ProviderResult>;
    getGoblinMining: (goblinId: number) => Promise<ProviderResultDetail<GoblinMining>>;
    listReward: () => Promise<ProviderResult>;
    claimReward: (idReward: number) => Promise<ProviderResultDetail<boolean>>;
    listHistoryDateMonth: () => Promise<ProviderResult>;
    listHistoryDateWeek: () => Promise<ProviderResult>;
    listHistoryMonth: (rewardDate: string) => Promise<ProviderResult>;
    listHistoryWeek: (rewardDate: string) => Promise<ProviderResult>;
    listHistoryByUser: () => Promise<ProviderResult>;
    claimRankingReward: (idMiningHistory: number) => Promise<ProviderResult>;
    goblinsMining: GoblinInfo[];
    goblinsCanMining: GoblinInfo[];
    selectedGoblin: GoblinInfo;
    rankingTop100: MiningRankingInfo[];
    rankingMonthlyDate: string;
    rankingMonthly: MiningRankingInfo[];
    rankingWeeklyDate: string;
    rankingWeekly: MiningRankingInfo[];
    myMining: MiningInfo;
    minerPos: MinerPosInfo[];
    loading: LoadingMining;
    gobCanMiningCursor: number;
    myRewardGobi: number;
    rewards: MiningRewardInfo[];
    historyDateMonth: string[];
    historyDateWeek: string[];
    historyMonth: MiningHistoryInfo[];
    historyWeek: MiningHistoryInfo[];
    historyOfUser: MiningHistoryInfo[];
}

export default IMiningProvider;