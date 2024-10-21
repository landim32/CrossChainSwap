import { VersionResult } from "../../dto/services/VersionResult";
import IHttpClient from "../../infra/interface/IHttpClient";

export interface IConfigurationService {
  init: (htppClient : IHttpClient) => void;
  getAppVersion: () => Promise<VersionResult>;
}