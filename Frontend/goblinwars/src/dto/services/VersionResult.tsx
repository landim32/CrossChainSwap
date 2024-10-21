import StatusRequest from "./StatusRequest";

export interface VersionResult extends StatusRequest {
  version: string;
}