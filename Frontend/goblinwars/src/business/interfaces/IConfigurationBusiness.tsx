import BusinessResult from "../../dto/business/BusinessResult";
import { VersionResult } from "../../dto/services/VersionResult";
import { IConfigurationService } from "../../services/interfaces/IConfigurationService";

export interface IConfigurationBusiness {
  init: (configurationService: IConfigurationService) => void;
  getAppVersion: () => Promise<BusinessResult<VersionResult>>;
}