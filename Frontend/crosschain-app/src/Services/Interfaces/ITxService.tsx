import TxParamInfo from "../../DTO/Domain/TxParamInfo";
import StatusRequest from "../../DTO/Services/StatusRequest";
import { TxListResult } from "../../DTO/Services/TxListResult";
import { TxLogListResult } from "../../DTO/Services/TxLogListResult";
import { TxResult } from "../../DTO/Services/TxResult";
import IHttpClient from "../../Infra/Interface/IHttpClient";


export interface ITxService {
    init: (httpClient : IHttpClient) => void;
    createTx: (param: TxParamInfo) => Promise<StatusRequest>;
    getTx: (txid: string) => Promise<TxResult>;
    listAllTx: () => Promise<TxListResult>;
    listTxLogs: (txid: number) => Promise<TxLogListResult>;
}