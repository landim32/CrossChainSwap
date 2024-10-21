import { UserQuestInfo } from "../domain/UserQuestInfo";
import StatusRequest from "./StatusRequest";

export interface UserQuestListResult extends StatusRequest {
  quests: UserQuestInfo[];
}