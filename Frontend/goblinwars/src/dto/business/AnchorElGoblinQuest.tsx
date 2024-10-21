import { GoblinInfo } from "../domain/GoblinInfo";
import { QuestInfo } from "../domain/QuestInfo";

export interface AnchorElGoblinQuest {
  anchorEl: any;
  goblin: GoblinInfo;
  quest: QuestInfo;
  open: boolean;
}