import { UserItemInfo } from "../domain/UserItemInfo";
import StatusRequest from "./StatusRequest";

export interface UserItemListResult extends StatusRequest {
  itens: UserItemInfo[];
}