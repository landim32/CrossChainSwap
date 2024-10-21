import AuctionEquipmentFilterInfo from "../../dto/domain/AuctionEquipmentFilterInfo";
import AuctionFilterInfo from "../../dto/domain/AuctionFilterInfo";
import AuctionInsertInfo from "../../dto/domain/AuctionInsertInfo";
import { AuctionListResult } from "../../dto/services/AuctionListResult";
import { AuctionResult } from "../../dto/services/AuctionResult";
import StatusRequest from "../../dto/services/StatusRequest";
import IHttpClient from "../../infra/interface/IHttpClient";


export default interface IAuctionService {
    init: (htppClient : IHttpClient) => void;
    searchgoblin: (filter: AuctionFilterInfo, tokenAuth: string) => Promise<AuctionListResult>;
    searchequipment: (filter: AuctionEquipmentFilterInfo, tokenAuth: string) => Promise<AuctionListResult>;
    listbyauction: (auction: number, page: number, tokenAuth: string) => Promise<AuctionListResult>;
    listbyuser: (auction: number, tokenAuth: string) => Promise<AuctionListResult>;
    listsameequipment: (itemkey: number, tokenAuth: string) => Promise<AuctionListResult>;
    getbytoken: (tokenId: number, tokenAuth: string) => Promise<AuctionResult>;
    getbyid: (IdAuction: number, tokenAuth: string) => Promise<AuctionResult>;
    insert: (param: AuctionInsertInfo, tokenAuth: string) => Promise<StatusRequest>;
    buy: (idAuction: number, tokenAuth: string) => Promise<StatusRequest>;
    cancel: (idAuction: number, tokenAuth: string) => Promise<StatusRequest>;
}