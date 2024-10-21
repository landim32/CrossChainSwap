import BusinessResult from "../../dto/business/BusinessResult";

export default interface IGoblinContractBusiness {
  transferFrom: (to: string, tokenId: number) => Promise<BusinessResult<string>>;
}