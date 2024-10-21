import { ItemInfo } from "./ItemInfo";

export interface GoblinEquipmentInfo {
  head: ItemInfo;
  chest: ItemInfo;
  hand: ItemInfo;
  foot: ItemInfo;
  rightHand: ItemInfo;
  leftHand: ItemInfo;
  miningbonus: number;
  huntingbonus: number;
  resistencebonus: number;
  attackbonus: number;
  socialbonus: number;
  tailoringbonus: number;
  blacksmithbonus: number;
  steathbonus: number;
  magicbonus: number;
  goblinBag: ItemInfo[];
}