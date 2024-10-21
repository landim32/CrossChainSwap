import IItemProvider from "../contexts/IItemProvider";
import { UserItemInfo } from "../domain/UserItemInfo";

export interface ItemSlotParam {
  userItemInfo: UserItemInfo;
  context?: IItemProvider;
  children?: any;
  x?: number;
  y?: number;
  moveCb?: (idItem: number, x: number, y: number) => void;
  canDropCb?: (idItem: number, x: number, y: number) => boolean;
  selectItemCb?: (userItemInfo: UserItemInfo) => void;
}