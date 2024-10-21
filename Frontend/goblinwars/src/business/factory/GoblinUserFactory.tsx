import ServiceFactory from '../../services/ServiceFactory';
import { GoblinUserBusiness } from '../impl/GoblinUserBusiness';
import { IGoblinUserBusiness } from '../interfaces/IGoblinUserBusiness';
import AuthFactory from './AuthFactory';

const goblinUserService = ServiceFactory.GoblinUserService;

const goblinUserBusinessImpl: IGoblinUserBusiness = GoblinUserBusiness;
goblinUserBusinessImpl.init(goblinUserService, AuthFactory.AuthBusiness);

const GoblinUserFactory = {
  GoblinUserBusiness: goblinUserBusinessImpl
};

export default GoblinUserFactory;
