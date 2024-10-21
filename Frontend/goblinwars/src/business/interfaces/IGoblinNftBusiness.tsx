import BusinessResult from "../../dto/business/BusinessResult";
import { ListGoblinResult } from "../../dto/services/ListGoblinResult";
import IGoblinNftService from "../../services/interfaces/IGoblinNftService";
import { IAuthBusiness } from "./IAuthBusiness";
import IGoblinContractBusiness from "./IGoblinContractBusiness";

export default interface IGoblinNftBusiness {
  init: (goblinNftService: IGoblinNftService, goblinContractBusiness: IGoblinContractBusiness, authBusiness: IAuthBusiness) => void;
  list: () => Promise<BusinessResult<ListGoblinResult>>;
  mint: (tokenId: number) => Promise<BusinessResult<boolean>>;
  claim: (tokenId: number) => Promise<BusinessResult<boolean>>;
  deposit: (tokenId: number) => Promise<BusinessResult<boolean>>;
}