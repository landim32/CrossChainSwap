import BusinessResult from "../../dto/business/BusinessResult";

export interface IFuseBusiness {
  fuseCost: (tokenId: number) => Promise<BusinessResult<number>>;
  fuse: (targeTokenId: number, sacrificeTokenId: number) => Promise<BusinessResult<void>>;
}