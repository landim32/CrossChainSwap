import ServiceFactory from '../../services/ServiceFactory';
import ReferralBusiness from '../impl/ReferralBusiness';
import IReferralBusiness from '../interfaces/IReferralBusiness';
import AuthFactory from './AuthFactory';

const referralService = ServiceFactory.ReferralService;

const referralBusinessImpl: IReferralBusiness = ReferralBusiness;
referralBusinessImpl.init(referralService, AuthFactory.AuthBusiness);

const ReferralFactory = {
  ReferralBusiness: referralBusinessImpl
};

export default ReferralFactory;
