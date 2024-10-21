import BusinessResult from "../../dto/business/BusinessResult";
import AuctionFilterInfo from "../../dto/domain/AuctionFilterInfo";
import AuctionInfo from "../../dto/domain/AuctionInfo";
import AuctionInsertInfo from "../../dto/domain/AuctionInsertInfo";
import ReferralInfo from "../../dto/domain/ReferralInfo";
import ReferralParamInfo from "../../dto/domain/ReferralParamInfo";
import TweetUrlInfo from "../../dto/domain/TweetUrlInfo";
import IReferralService from "../../services/interfaces/IReferralService";
import { IAuthBusiness } from "./IAuthBusiness";

export default interface IReferralBusiness {
  init: (referralService: IReferralService, authBusiness: IAuthBusiness) => void;
  getreferral: () => Promise<BusinessResult<ReferralInfo>>;
  updatereferral: (param: ReferralParamInfo) => Promise<BusinessResult<boolean>>;
  addtweet: (tweet: string) => Promise<BusinessResult<boolean>>;
}