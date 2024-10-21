import ServiceFactory from '../../services/ServiceFactory';
import { GoblinBusiness } from '../impl/GoblinBusiness';
import { IGoblinBusiness } from '../interfaces/IGoblinBusiness';
import AuthFactory from './AuthFactory';

const goblinService = ServiceFactory.GoblinService;
const equipmentService = ServiceFactory.EquipmentService;

const goblinBusinessImpl: IGoblinBusiness = GoblinBusiness;
goblinBusinessImpl.init(goblinService, equipmentService, AuthFactory.AuthBusiness);

const GoblinFactory = {
  GoblinBusiness: goblinBusinessImpl
};

export default GoblinFactory;
