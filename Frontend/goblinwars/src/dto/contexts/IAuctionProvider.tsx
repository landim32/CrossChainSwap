import AuctionEquipmentFilterInfo from "../domain/AuctionEquipmentFilterInfo";
import AuctionFilterInfo from "../domain/AuctionFilterInfo";
import AuctionInfo from "../domain/AuctionInfo";
import AuctionInsertInfo from "../domain/AuctionInsertInfo";
import { AuctionListResult } from "../services/AuctionListResult";
import ProviderResult from "./ProviderResult";

interface IAuctionProvider {
    searchGoblin: (filter: AuctionFilterInfo) => Promise<ProviderResult>;
    searchEquipment: (filter: AuctionEquipmentFilterInfo) => Promise<ProviderResult>;
    listByAuction: (auction: number, page: number) => Promise<ProviderResult>;
    listByUser: (auction: number) => Promise<ProviderResult>;
    listsameequipment: (itemkey: number) => Promise<ProviderResult>;
    getbytoken: (tokenId: number) => Promise<ProviderResult>;
    getById: (IdAuction: number) => Promise<ProviderResult>;
    insert: (param: AuctionInsertInfo) => Promise<ProviderResult>;
    cancel: (idAuction: number) => Promise<ProviderResult>;
    buy: (idAuction: number) => Promise<ProviderResult>;
    setFilter: (filter: AuctionFilterInfo) => void;
    filter: AuctionFilterInfo;
    filterEquipment: AuctionEquipmentFilterInfo;
    loading: boolean;
    loadingAction: boolean;
    myAuction: AuctionInfo;
    goblinList: AuctionListResult;
    equipmentList: AuctionListResult;
    auctionList: AuctionListResult;
    myAuctionList: AuctionListResult;
    sameEquipment: AuctionListResult;
}

export default IAuctionProvider;