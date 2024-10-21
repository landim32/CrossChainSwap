import { UserQuestInfo } from "../domain/UserQuestInfo";
import StatusRequest from "./StatusRequest";

export interface UserQuestResult extends StatusRequest {
  quest: UserQuestInfo;
}