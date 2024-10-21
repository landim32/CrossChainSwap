import { DestroyRewardInfo } from "./DestroyRewardInfo";
import { EquipmentInfo } from "./EquipmentInfo";

export interface ItemInfo {
  key: number;
  name: string;
  category: string;
  rarity: number;
  iconAsset: string;
  isTrash: boolean;
  isBag: boolean;
  price: number;
  isEquipment: boolean;
  equipmentInfo: EquipmentInfo;
  destroyInfo?: DestroyRewardInfo;
}