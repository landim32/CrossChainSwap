import ReferralInfo from "../domain/ReferralInfo";
import ReferralParamInfo from "../domain/ReferralParamInfo";
import TweetUrlInfo from "../domain/TweetUrlInfo";
import ProviderResult from "./ProviderResult";


interface IReferralProvider {
    getreferral: () => Promise<ProviderResult>;
    updatereferral: (param: ReferralParamInfo) => Promise<ProviderResult>;
    addtweet: (tweet: string) => Promise<ProviderResult>;
    loading: boolean;
    myReferral: ReferralInfo,
    setReferral: (referral: ReferralInfo) => void;
}

export default IReferralProvider;