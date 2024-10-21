import AuctionFilterInfo from "../../dto/domain/AuctionFilterInfo";
import AuctionInsertInfo from "../../dto/domain/AuctionInsertInfo";
import ReferralParamInfo from "../../dto/domain/ReferralParamInfo";
import TweetUrlInfo from "../../dto/domain/TweetUrlInfo";
import ReferralResult from "../../dto/services/ReferralResult";
import StatusRequest from "../../dto/services/StatusRequest";
import TweetUrlResult from "../../dto/services/TweetUrlResult";
import IHttpClient from "../../infra/interface/IHttpClient";


export default interface IReferralService {
    init: (htppClient : IHttpClient) => void;
    getreferral: (tokenAuth: string) => Promise<ReferralResult>;
    updatereferral: (param: ReferralParamInfo, tokenAuth: string) => Promise<StatusRequest>;
    addtweet: (tweet: TweetUrlInfo, tokenAuth: string) => Promise<TweetUrlResult>;
}