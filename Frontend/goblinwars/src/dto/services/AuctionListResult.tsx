import AuctionInfo from "../domain/AuctionInfo";
import StatusRequest from "./StatusRequest";

export interface AuctionListResult extends StatusRequest {
  auctions: AuctionInfo[];
  page: number;
  totalpages: number;
}