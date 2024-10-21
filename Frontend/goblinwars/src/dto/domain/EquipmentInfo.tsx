import { BodyPartEnum } from "../enum/BodyPartEnum";
import { EquipmentTypeEnum } from "../enum/EquipmentTypeEnum";

export interface EquipmentInfo {
  weight: number;
  imageAsset: string;
  itemType: EquipmentTypeEnum;
  part: BodyPartEnum[];
  isTwoHanded: boolean;
  binded: boolean;
  mining?: number;
  hunting?: number;
  resistence?: number;
  attack?: number;
  social?: number;
  tailoring?: number;
  blacksmith?: number;
  stealth?: number;
  magic?: number;  
}