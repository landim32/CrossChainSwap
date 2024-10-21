import { GoblinInfo } from "./GoblinInfo";
import { ItemInfo } from "./ItemInfo";

export default interface AuctionInfo {
  id: number;
  iduser: number;
  idgoblin: number;
  boxtype: number;
  itemkey: number;
  qtdy: number;
  insertdate: string;
  price: number;
  auctiontype: number;
  status: number;
  goblin?: GoblinInfo;
  item?: ItemInfo;
}