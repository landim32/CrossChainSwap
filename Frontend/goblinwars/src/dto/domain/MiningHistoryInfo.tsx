export interface MiningHistoryInfo {
    id: number;
    iduser: number;
    name: string;
    rewardtype: string;
    rewarddate: string;
    rewarddatestr: string;
    ranking: number;
    goblinqtde: number;
    hashpower: number;
    hashforweek?: number;
    hashformonth?: number;
    boxtype: number;
    claimed: boolean;
  }