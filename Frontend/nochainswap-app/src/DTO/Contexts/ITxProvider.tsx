import TxInfo from "../Domain/TxInfo";
import TxLogInfo from "../Domain/TxLogInfo";
import ProviderResult from "./ProviderResult";


interface ITxProvider {
    loadingTxInfo: boolean;
    loadingAllTxInfo: boolean;
    loadingTxLogs: boolean;
    txInfo?: TxInfo;
    allTxInfo?: TxInfo[];
    txLogs?: TxLogInfo[];
    setTxInfo: (txInfo: TxInfo) => void;
    loadTx: (txid: string) => Promise<ProviderResult>;
    loadListAllTx: () => Promise<ProviderResult>;
    loadTxLogs: (txid: number) => Promise<ProviderResult>;
}

export default ITxProvider;