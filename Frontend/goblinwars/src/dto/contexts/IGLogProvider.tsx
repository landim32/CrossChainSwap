import GLogListResult from "../services/GLogListResult";
import ProviderResult from "./ProviderResult";

interface IGLogProvider {
    list: (page: number) => Promise<ProviderResult>;
    loading: boolean;
    glogList: GLogListResult;
}

export default IGLogProvider;