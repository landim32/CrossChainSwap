import StatusRequest from "../services/StatusRequest";

interface BusinessResult<T> extends StatusRequest {
  dataResult: T
}

export default BusinessResult;