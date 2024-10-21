import React, {useState} from 'react';
import ReferralFactory from '../../business/factory/ReferralFactory';
import IReferralProvider from '../../dto/contexts/IReferralProvider';
import ProviderResult from '../../dto/contexts/ProviderResult';
import ReferralInfo from '../../dto/domain/ReferralInfo';
import ReferralParamInfo from '../../dto/domain/ReferralParamInfo';
import TweetUrlInfo from '../../dto/domain/TweetUrlInfo';
import ReferralContext from './ReferralContext';

export default function ReferralProvider(props : any) {

  const [referral, setReferral] = useState<ReferralInfo>(null);
  const [loading, setLoading] = useState<boolean>(false);

  const referralProviderValue: IReferralProvider = {

    getreferral: async () => {
      let ret: Promise<ProviderResult>;
      setLoading(true);
      try {
        let buResult = await ReferralFactory.ReferralBusiness.getreferral();
        setLoading(false);
        if (!buResult.sucesso) {
          return {
            ...ret,
            sucesso: false
          };
        }
        setReferral(buResult.dataResult);

        return {
          ...ret,
          sucesso: true
        };
      } catch (err) {
        setLoading(false);
        return {
          ...ret,
          sucesso: false
        };
      }
    },
    updatereferral: async (param: ReferralParamInfo) => {
      let ret: Promise<ProviderResult>;
      setLoading(true);
      try {
        let buResult = await ReferralFactory.ReferralBusiness.updatereferral(param);
        await referralProviderValue.getreferral();
        setLoading(false);
        if (!buResult.sucesso) {
          return {
            ...ret,
            sucesso: false
          };
        }

        return {
          ...ret,
          sucesso: true
        };
      } catch (err) {
        setLoading(false);
        return {
          ...ret,
          sucesso: false
        };
      }
    },
    addtweet: async (tweet: string) => {
      let ret: Promise<ProviderResult>;
      setLoading(true);
      try {
        let buResult = await ReferralFactory.ReferralBusiness.addtweet(tweet);
        setLoading(false);
        if (!buResult.sucesso) {
          return {
            ...ret,
            sucesso: false
          };
        }

        return {
          ...ret,
          sucesso: true
        };
      } catch (err) {
        setLoading(false);
        return {
          ...ret,
          sucesso: false
        };
      }
    },
    loading: loading,
    myReferral: referral,
    setReferral: function (referral: ReferralInfo): void {
      setReferral(referral);
    }
  };

  return (
    <ReferralContext.Provider value={referralProviderValue}>
      {props.children}
    </ReferralContext.Provider>
  );
}
