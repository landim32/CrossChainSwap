import BusinessResult from "../../dto/business/BusinessResult";

export default interface IGoblinAuctionBusiness {
  getPrice: (tokenId: number) => Promise<BusinessResult<number>>;
  inAuction: (tokenId: number) => Promise<BusinessResult<boolean>>;
  newAuction: (tokenId: number, price: number) => Promise<BusinessResult<boolean>>;
  cancelAuction: (tokenId: number) => Promise<BusinessResult<boolean>>;
  buy: (price: number, tokenId: number) => Promise<BusinessResult<boolean>>;
}