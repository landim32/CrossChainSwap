import { BalanceInfo } from "../domain/BalanceInfo";
import ProviderResult from "./ProviderResult";


interface IGoblinUserProvider {
    loadBalance: () => Promise<ProviderResult>;
    balance: BalanceInfo;
    loading: boolean;
    buyGoblinLoading: boolean;
}

export default IGoblinUserProvider;