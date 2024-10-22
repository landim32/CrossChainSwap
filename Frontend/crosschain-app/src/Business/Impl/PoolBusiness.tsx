import BusinessResult from "../../DTO/Business/BusinessResult";
import { PoolResult } from "../../DTO/Services/PoolResult";
import { IPoolService } from "../../Services/Interfaces/IPoolService";
import { IPoolBusiness } from "../Interfaces/IPoolBusiness";

let _poolService: IPoolService;

const PoolBusiness: IPoolBusiness = {
  init: function (poolService: IPoolService): void {
    _poolService = poolService;
  },
  getPoolInfo: async () => {
    try {
      let ret: BusinessResult<PoolResult> = null;
      let retPool = await _poolService.getPoolInfo();
      if (retPool.sucesso) {
        return {
          ...ret,
          dataResult: retPool,
          sucesso: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          mensagem: retPool.mensagem
        };
      }
    } catch {
      throw new Error("Failed to get pool information");
    }
  }
}

export { PoolBusiness };