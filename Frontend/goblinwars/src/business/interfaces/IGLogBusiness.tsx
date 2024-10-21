import BusinessResult from "../../dto/business/BusinessResult";
import GLogListResult from "../../dto/services/GLogListResult";
import IGLogService from "../../services/interfaces/IGLogService";
import { IAuthBusiness } from "./IAuthBusiness";

export default interface IGLogBusiness {
  init: (glogService: IGLogService, authBusiness: IAuthBusiness) => void;
  list: (page: number) => Promise<BusinessResult<GLogListResult>>;
}