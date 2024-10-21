import ServiceFactory from '../../services/ServiceFactory';
import { MaterialMarketBusiness } from '../impl/MaterialMarketBusiness';
import { IMaterialMarketBusiness } from '../interfaces/IMaterialMarketBusiness';
import AuthFactory from './AuthFactory';

const materialMarketService = ServiceFactory.MaterialMarketService;

const materialMarketBusinessImpl: IMaterialMarketBusiness = MaterialMarketBusiness;
materialMarketBusinessImpl.init(materialMarketService, AuthFactory.AuthBusiness);

const MaterialMarketFactory = {
  MaterialMarketBusiness: materialMarketBusinessImpl
};

export default MaterialMarketFactory;
