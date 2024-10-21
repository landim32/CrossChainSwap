import ProviderResult from "./ProviderResult";

interface ProviderResultDetail<T> extends ProviderResult {
  dataResult: T;
}

export default ProviderResultDetail;