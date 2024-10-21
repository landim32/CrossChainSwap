import BusinessResult from "../../dto/business/BusinessResult";

export default interface IGobiBusiness {
  allowance: (spender: string) => Promise<BusinessResult<number>>;
  balanceOf: () => Promise<BusinessResult<number>>;
  approve: (spender: string, amount: number) => Promise<BusinessResult<string>>;
  transfer: (recipient: string, amount: number) => Promise<BusinessResult<string>>;
}