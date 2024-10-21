import { QuestRequerimentItemInfo } from "./QuestRequirementItemInfo";

export interface QuestRequirementInfo {
  usemining: boolean;
  usehunting: boolean;
  useresistence: boolean;
  useattack: boolean;
  usesocial: boolean;
  usetailoring: boolean;
  useblacksmith: boolean;
  usestealth: boolean;
  usemagic: boolean;
  items: QuestRequerimentItemInfo[];
  gold: number;
  gobi: number;
}