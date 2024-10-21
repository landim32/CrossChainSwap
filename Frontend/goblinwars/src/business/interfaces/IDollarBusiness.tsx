import BusinessResult from "../../dto/business/BusinessResult";

export interface IDollarBusiness {
  getDollar: () => Promise<BusinessResult<boolean>>;
}