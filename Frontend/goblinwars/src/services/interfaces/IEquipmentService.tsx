import { BodyPartEnum } from "../../dto/enum/BodyPartEnum";
import { GoblinResult } from "../../dto/services/GoblinResult";
import IHttpClient from "../../infra/interface/IHttpClient";

export interface IEquipmentService {
  init: (htppClient : IHttpClient) => void;
  equipPart: (goblinId: number, tokenId: number, itemKey: number, part: BodyPartEnum, tokenAuth: string) => Promise<GoblinResult>;
}