import ServiceFactory from '../../services/ServiceFactory';
import GoblinContractBusiness from '../impl/GoblinContractBusiness';
import GoblinNftBusiness from '../impl/GoblinNftBusiness';
import IGoblinContractBusiness from '../interfaces/IGoblinContractBusiness';
import IGoblinNftBusiness from '../interfaces/IGoblinNftBusiness';
import AuthFactory from './AuthFactory';

const goblinNftService = ServiceFactory.GoblinNftService;

const goblinNftBusinessImpl: IGoblinNftBusiness = GoblinNftBusiness;
const goblinContractBusinessImpl: IGoblinContractBusiness = GoblinContractBusiness;
goblinNftBusinessImpl.init(goblinNftService, goblinContractBusinessImpl, AuthFactory.AuthBusiness);

const GoblinNftFactory = {
  GoblinNftBusiness: goblinNftBusinessImpl
};

export default GoblinNftFactory;
