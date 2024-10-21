import { QuestDifficultyEnum } from "../enum/QuestDifficultyEnum";
import { QuestPeriod } from "../enum/QuestPeriod";
import { QuestType } from "../enum/QuestType";
import { QuestRequirementInfo } from "./QuestRequirementInfo";
import { QuestRewardInfo } from "./QuestRewardInfo";

export interface QuestInfo {
  key: number;
  period: QuestPeriod;
  questtype: QuestType;
  name: string;
  category: string;
  description: string;
  imageasset: string;
  tired: boolean;
  timemin: number;
  timemax: number;
  percentmin: number;
  percentmax: number;
  qtdemin: number;
  qtdemax: number;
  minpowerhash: number;
  maxpowerhash: number;
  requeriments: QuestRequirementInfo;
  reward: QuestRewardInfo;
  difficulty: QuestDifficultyEnum;
}