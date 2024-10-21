import { GoblinInfo } from "./GoblinInfo";
import { MiningGoblinInfo } from "./MiningGoblinInfo";

export interface MiningInfo {
  id: number;
  iduser: number;
  lastmining: string;
  name: string;
  hashpower: number;
  goblinqtde: number;
  rewardpermonth: number;
  rewardpersecond: number;
  gobi: number;
  ranking: number;
  minhashpower: number;
  totalhashpower: number;
  dailyreward: number;
  goblins?: GoblinInfo[];
}