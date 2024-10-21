import { ItemDestroyRewardInfo } from "./ItemDestroyRewardInfo";

export interface DestroyRewardInfo {
  goldmin: number;
  goldmax: number;
  grantedqtdy: number;
  randomqtdy: number;
  grantedreward: ItemDestroyRewardInfo[];
  randomreward: ItemDestroyRewardInfo[];
}