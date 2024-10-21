import { RarityEnum } from "../enum/RarityEnum";
import { GoblinMining } from "./GoblinMining";

export interface MinerPosInfo {
  idtoken: number;
  sprite: string;
  top: string;
  left: string;
  inverted: boolean;
  start: number;
  exhausted: boolean;
  spriteTired: string;
  goblinMining: GoblinMining;
  rarityenum: RarityEnum;
}