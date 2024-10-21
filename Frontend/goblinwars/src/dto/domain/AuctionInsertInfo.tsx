export default interface AuctionInsertInfo {
  auction: number;
  tokenid?: number;
  boxType?: number;
  itemKey?: number;
  price: number;
  qtdy: number;
}