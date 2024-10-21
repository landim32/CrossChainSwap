import { AuthSession } from "../domain/AuthSession";
import SelectedRoute from "../enum/SelectedRoute";
import ProviderResult from "./ProviderResult";


interface IInicioProvider {
    checkSession: () => ProviderResult;
    setSelectedFlow: (flow: SelectedRoute) => void;
    checkNetwork: () => Promise<ProviderResult>;
    checkVersion: () => Promise<ProviderResult>;
    selectedFlow: SelectedRoute;
}

export default IInicioProvider;