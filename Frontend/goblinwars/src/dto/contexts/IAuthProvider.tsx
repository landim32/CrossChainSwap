import { AuthSession } from "../domain/AuthSession";
import ProviderResult from "./ProviderResult";


interface IInicioProvider {
    bindMetaMaskWallet: (name: string, email: string, fromReferralCode: string) => Promise<ProviderResult>;
    checkUserRegister: () => Promise<ProviderResult>;
    logout: () => ProviderResult;
    loadUserSession: () => void;
    updateUser: (name: string, email: string) => Promise<ProviderResult>;
    loading: boolean;
    sessionInfo: AuthSession;
}

export default IInicioProvider;