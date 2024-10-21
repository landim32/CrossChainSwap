import { QuestStatus } from "../enum/QuestStatus";
import { QuestInfo } from "./QuestInfo";
import { UserQuestGoblinInfo } from "./UserQuestGoblinInfo";

export interface UserQuestInfo {
  id: number;
  iduser: number;
  questkey: number;
  insertdate: string;
  expiredate: string;
  startdate?: string;
  enddate?: string;
  status: QuestStatus;
  percent: number; 
  quest: QuestInfo;
  goblins: UserQuestGoblinInfo[];
}
