import { ItemInfo } from "./ItemInfo";
import { QuestInfo } from "./QuestInfo";

export interface CraftInfo {
  origins: QuestInfo[];
  destinations: QuestInfo[];
  chests: ItemInfo[];
}