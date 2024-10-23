import TxInfo from "../Domain/TxInfo";
import TxLogInfo from "../Domain/TxLogInfo";


interface ITransactionProvider {
    loadingTxInfo: boolean;
    loadingAllTxInfo: boolean;
    loadingTxLogs: boolean;
    txInfo?: TxInfo;
    allTxInfo?: TxInfo[];
    txLogs?: TxLogInfo[];
    loadTx: (txid: string) => void;
    loadListAllTx: () => void;
    loadTxLogs: (txid: number) => void;
}

export default ITransactionProvider;