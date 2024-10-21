import BusinessResult from "../../dto/business/BusinessResult";
import { GoblinInfo } from "../../dto/domain/GoblinInfo";
import { BodyPartEnum } from "../../dto/enum/BodyPartEnum";
import { BreedCostResult } from "../../dto/services/BreedCostResult";
import { ListGoblinResult } from "../../dto/services/ListGoblinResult";
import { IEquipmentService } from "../../services/interfaces/IEquipmentService";
import { IGoblinService } from "../../services/interfaces/IGoblinService";
import { IAuthBusiness } from "./IAuthBusiness";

export interface IGoblinBusiness {
  init: (goblinService: IGoblinService, equipmentService: IEquipmentService, authBusiness: IAuthBusiness) => void;
  listByUser: (page: number, itemsPerPage: number) => Promise<BusinessResult<ListGoblinResult>>;
  listInfityGoblins: (cursorGob: number) => Promise<BusinessResult<ListGoblinResult>>;
  myGoblin: (tokenId: number) => Promise<BusinessResult<GoblinInfo>>;
  equipPart: (goblinId: number, tokenId: number, itemKey: number, part: BodyPartEnum) => Promise<BusinessResult<GoblinInfo>>;
  rechargeGoblin: (tokenId: number) => Promise<BusinessResult<GoblinInfo>>;
  lastGoblin: () => Promise<BusinessResult<GoblinInfo>>;
  updateGoblinName: (tokenId: number, name: string) => Promise<BusinessResult<GoblinInfo>>;
  goblin: (tokenId: number) => Promise<BusinessResult<GoblinInfo>>;
  goblinBrothers: (tokenId: number, page: number) => Promise<BusinessResult<ListGoblinResult>>;
  goblinCanFuse: (tokenId: number) => Promise<BusinessResult<ListGoblinResult>>;
  goblinSons: (tokenId: number, page: number) => Promise<BusinessResult<ListGoblinResult>>;
  spouseCandidates: (tokenId: number, cursorGob: number) => Promise<BusinessResult<ListGoblinResult>>;
  //breedGoblin: (goblin1: GoblinInfo, goblin2: GoblinInfo) => Promise<BusinessResult<number>>;
  //buyGoblin: () => Promise<BusinessResult<boolean>>;
  //transferGoblin: (goblin: GoblinInfo, toAddress: string) => Promise<BusinessResult<boolean>>;
  transfer: (tokenId: number, toAddress: string) => Promise<BusinessResult<boolean>>;
  //breedRarity: (tokenId1: number, tokenId2: number) => Promise<BusinessResult<number>>;
  breedCost: (tokenId1: number, tokenId2: number) => Promise<BusinessResult<BreedCostResult>>;
  //getApproved: (tokenId: number) => Promise<BusinessResult<string>>;
  //approve: (to: string, tokenId: number) => Promise<BusinessResult<boolean>>;
  //refreshNftWallet: (tokens: number[]) => Promise<BusinessResult<boolean>>;
  fusionCost: (tokenId: number) => Promise<BusinessResult<BreedCostResult>>;
  fusion: (tokenId1: number, tokenId2: number) => Promise<BusinessResult<number>>;
  breed: (parent1: number, parent2: number) => Promise<BusinessResult<number>>;
}