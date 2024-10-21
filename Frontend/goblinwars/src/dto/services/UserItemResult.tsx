import { UserItemInfo } from "../domain/UserItemInfo";
import StatusRequest from "./StatusRequest";

export interface UserItemResult extends StatusRequest {
  item: UserItemInfo;
}