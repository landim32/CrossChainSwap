import { ItemInfo } from "./ItemInfo";

export interface UserItemInfo {
  id: number;
  key: number;
  idUser: number;
  qtde: number;
  posX: number;
  posY: number;
  item: ItemInfo;
}