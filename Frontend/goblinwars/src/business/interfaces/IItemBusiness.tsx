import BusinessResult from "../../dto/business/BusinessResult";
import { CraftInfo } from "../../dto/domain/CraftInfo";
import { UserItemInfo } from "../../dto/domain/UserItemInfo";
import ItemDestroyResult from "../../dto/services/ItemDestroyResult";
import { IItemService } from "../../services/interfaces/IItemService";
import { IAuthBusiness } from "./IAuthBusiness";

export interface IItemBusiness {
  init: (itemService: IItemService, authBusiness: IAuthBusiness) => void;
  list: () => Promise<BusinessResult<UserItemInfo[]>>;
  getbykey: (idItem: number) => Promise<BusinessResult<UserItemInfo>>;
  getcraftinfo: (idItem: number) => Promise<BusinessResult<CraftInfo>>;
  sell: (key: number, qtde:number) => Promise<BusinessResult<boolean>>;
  move: (idItem: number, x: number, y: number) => Promise<BusinessResult<boolean>>;
  destroyitem: (idItem: number, qtde:number) => Promise<BusinessResult<ItemDestroyResult>>;
  sellalltrash: () => Promise<BusinessResult<boolean>>;
}