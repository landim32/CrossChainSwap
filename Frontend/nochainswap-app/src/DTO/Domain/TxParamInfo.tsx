export default interface TxParamInfo {
  btcToStx: boolean;
  btcAddress: string;
  stxAddress: string;
  btcTxid?: string;
  stxTxid?: string;
  btcAmount?: number;
  stxAmount?: number;
}