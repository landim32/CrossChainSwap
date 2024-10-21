import ProviderResultDetail from "./ProviderResultDetail";

interface IDollarProvider {
    getDollar: () => Promise<ProviderResultDetail<number>>;
}

export default IDollarProvider;