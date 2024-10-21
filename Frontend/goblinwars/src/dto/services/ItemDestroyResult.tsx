import { UserItemInfo } from "../domain/UserItemInfo";
import StatusRequest from "./StatusRequest";

export default interface ItemDestroyResult extends StatusRequest {
    gold: number;
    gobi: number;
    items: UserItemInfo[];
}