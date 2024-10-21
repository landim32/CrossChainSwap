import { BodyPartEnum } from "../../dto/enum/BodyPartEnum";
import { GoblinResult } from "../../dto/services/GoblinResult";
import IHttpClient from "../../infra/interface/IHttpClient";
import { IEquipmentService } from "../interfaces/IEquipmentService";

let _httpClient : IHttpClient;

const EquipmentService : IEquipmentService = {
  init: function (htppClient: IHttpClient): void {
    _httpClient = htppClient;
  },
  equipPart: async (goblinId: number, tokenId: number, itemKey: number, part: BodyPartEnum, tokenAuth: string) => {
    let ret: GoblinResult;
    let request = await _httpClient.doPostAuth<GoblinResult>("api/GoblinEquipment/equipPart", {
      TokenId: tokenId,
      GoblinId: goblinId,
      ItemKey: itemKey,
      Part: part
    }, tokenAuth);
    if (request.success) {
      return request.data;
    }
    else {
      ret = {
        mensagem: request.messageError,
        sucesso: false,
        ...ret
      };
    }
    return ret;
  }
}

export default EquipmentService;