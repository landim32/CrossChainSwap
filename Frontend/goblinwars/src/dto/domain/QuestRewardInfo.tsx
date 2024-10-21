import { QuestRewardItemInfo } from "./QuestRewardItemInfo";

export interface QuestRewardInfo {
  gold: number;
  xp: number;
  items: QuestRewardItemInfo[];
}