import { ItemInfo } from "./ItemInfo";

export interface ItemDestroyRewardInfo {
  item: ItemInfo;
  percent: number;
  qtdemin: number;
  qtdemax: number;
}