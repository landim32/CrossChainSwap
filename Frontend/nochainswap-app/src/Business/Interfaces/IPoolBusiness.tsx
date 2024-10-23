import BusinessResult from "../../DTO/Business/BusinessResult";
import { PoolResult } from "../../DTO/Services/PoolResult";
import { IPoolService } from "../../Services/Interfaces/IPoolService";

export interface IPoolBusiness {
  init: (poolService: IPoolService) => void;
  getPoolInfo: () => Promise<BusinessResult<PoolResult>>;
}