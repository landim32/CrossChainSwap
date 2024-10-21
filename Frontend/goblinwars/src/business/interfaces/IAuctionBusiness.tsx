import BusinessResult from "../../dto/business/BusinessResult";
import AuctionEquipmentFilterInfo from "../../dto/domain/AuctionEquipmentFilterInfo";
import AuctionFilterInfo from "../../dto/domain/AuctionFilterInfo";
import AuctionInfo from "../../dto/domain/AuctionInfo";
import AuctionInsertInfo from "../../dto/domain/AuctionInsertInfo";
import { AuctionListResult } from "../../dto/services/AuctionListResult";
import IAuctionService from "../../services/interfaces/IAuctionService";
import { IAuthBusiness } from "./IAuthBusiness";

export default interface IAuctionBusiness {
  init: (auctionService: IAuctionService, authBusiness: IAuthBusiness) => void;
  searchGoblin: (filter: AuctionFilterInfo) => Promise<BusinessResult<AuctionListResult>>;
  searchEquipment: (filter: AuctionEquipmentFilterInfo) => Promise<BusinessResult<AuctionListResult>>;
  listbyauction: (auction: number, page: number) => Promise<BusinessResult<AuctionListResult>>;
  listbyuser: (auction: number) => Promise<BusinessResult<AuctionListResult>>;
  listsameequipment: (itemkey: number) => Promise<BusinessResult<AuctionListResult>>;
  getbytoken: (tokenId: number) => Promise<BusinessResult<AuctionInfo>>;
  getbyid: (IdAuction: number) => Promise<BusinessResult<AuctionInfo>>;
  insert: (param: AuctionInsertInfo) => Promise<BusinessResult<boolean>>;
  buy: (idAuction: number) => Promise<BusinessResult<boolean>>;
  cancel: (idAuction: number) => Promise<BusinessResult<boolean>>;
}