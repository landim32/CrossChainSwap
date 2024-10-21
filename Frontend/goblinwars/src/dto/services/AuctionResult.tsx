import AuctionInfo from "../domain/AuctionInfo";
import StatusRequest from "./StatusRequest";

export interface AuctionResult extends StatusRequest {
  auction: AuctionInfo;
}