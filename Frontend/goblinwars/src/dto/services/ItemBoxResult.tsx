import { ItemInfo } from "../domain/ItemInfo";
import StatusRequest from "./StatusRequest";

export interface ItemBoxResult extends StatusRequest {
  itens: ItemInfo[];
}