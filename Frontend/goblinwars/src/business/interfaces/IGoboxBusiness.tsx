import BusinessResult from "../../dto/business/BusinessResult";
import { GoboxInfo } from "../../dto/domain/GoboxInfo";
import { ItemInfo } from "../../dto/domain/ItemInfo";
import { IGoboxService } from "../../services/interfaces/IGoboxService";
import { IAuthBusiness } from "./IAuthBusiness";

export default interface IGoboxBusiness {
  init: (goboxService: IGoboxService, authBusiness: IAuthBusiness) => void;
  list: () => Promise<BusinessResult<GoboxInfo[]>>;
  listMyBox: () => Promise<BusinessResult<GoboxInfo[]>>;
  getbygobox: (boxType: number) => Promise<BusinessResult<GoboxInfo>>;
  buybox: (box: number, qtdy: number) => Promise<BusinessResult<boolean>>;
  openbox: (box: number) => Promise<BusinessResult<number>>;
  openitembox: (box: number) => Promise<BusinessResult<ItemInfo[]>>;
}