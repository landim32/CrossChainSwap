import ServiceFactory from '../../services/ServiceFactory';
import { MiningBusiness } from '../impl/MiningBusiness';
import { IMiningBusiness } from '../interfaces/IMiningBusiness';
import AuthFactory from './AuthFactory';

const miningService = ServiceFactory.MiningService;

const miningBusinessImpl: IMiningBusiness = MiningBusiness;
miningBusinessImpl.init(miningService, AuthFactory.AuthBusiness);

const MiningFactory = {
  MiningBusiness: miningBusinessImpl
};

export default MiningFactory;
