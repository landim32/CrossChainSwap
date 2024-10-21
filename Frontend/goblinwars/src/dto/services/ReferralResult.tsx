import ReferralInfo from "../domain/ReferralInfo";
import StatusRequest from "./StatusRequest";

export default interface ReferralResult extends StatusRequest {
  referral: ReferralInfo;
}