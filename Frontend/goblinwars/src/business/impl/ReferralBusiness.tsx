import BusinessResult from "../../dto/business/BusinessResult";
import ReferralInfo from "../../dto/domain/ReferralInfo";
import ReferralParamInfo from "../../dto/domain/ReferralParamInfo";
import TweetUrlInfo from "../../dto/domain/TweetUrlInfo";
import IReferralService from "../../services/interfaces/IReferralService";
import { ValidateEmail } from "../../utils/utils";
import { IAuthBusiness } from "../interfaces/IAuthBusiness";
import IReferralBusiness from "../interfaces/IReferralBusiness";

let _authBusiness : IAuthBusiness;
let _referralService : IReferralService;

const ReferralBusiness : IReferralBusiness = {
  init: function (referralService: IReferralService, authBusiness: IAuthBusiness): void {
    _authBusiness = authBusiness;
    _referralService = referralService;
  },
  getreferral: async () => {
    try {
      let ret: BusinessResult<ReferralInfo> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "") {
        let retRefAux : ReferralInfo = null;
        return {
          ...ret,
          sucesso: true,
          dataResult: {
            ...retRefAux,
            logged: false,
          }
        };
      }
      let retReferral = await _referralService.getreferral(userSession);
      if (retReferral.sucesso) {
        retReferral.referral.logged = true;
        if(retReferral.referral.score >= 70)
          retReferral.referral.inWhiteList = true;
        
        let validEmail = ValidateEmail(retReferral.referral.email);
        retReferral.referral.emailCollapse = !validEmail;
        retReferral.referral.emailComplete = validEmail;
        return {
          ...ret,
          dataResult: retReferral.referral,
          sucesso: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          mensagem: retReferral.mensagem
        };
      }
    } catch {
      throw new Error("Failed to search auction");
    }
  },
  updatereferral: async (param: ReferralParamInfo) => {
    try {
      let ret: BusinessResult<boolean> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      let retReferral = await _referralService.updatereferral(param, userSession);
      if (retReferral.sucesso) {
        return {
          ...ret,
          dataResult: true,
          sucesso: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          mensagem: retReferral.mensagem
        };
      }
    } catch {
      throw new Error("Failed to search auction");
    }
  },
  addtweet: async (tweet: string) => {
    try {
      let ret: BusinessResult<boolean> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      let auxTweet: TweetUrlInfo = {tweeturl: tweet};
      let retReferral = await _referralService.addtweet(auxTweet, userSession);
      if (retReferral.sucesso) {
        return {
          ...ret,
          dataResult: true,
          sucesso: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          mensagem: retReferral.mensagem
        };
      }
    } catch {
      throw new Error("Failed to search auction");
    }
  }
}

export default ReferralBusiness;