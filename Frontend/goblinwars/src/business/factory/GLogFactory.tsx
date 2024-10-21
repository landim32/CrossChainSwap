import ServiceFactory from '../../services/ServiceFactory';
import AuctionBusiness from '../impl/AuctionBusiness';
import GLogBusiness from '../impl/GLogBusiness';
import IGLogBusiness from '../interfaces/IGLogBusiness';
import AuthFactory from './AuthFactory';

const glogService = ServiceFactory.GLogService;

const glogBusinessImpl: IGLogBusiness = GLogBusiness;
glogBusinessImpl.init(glogService, AuthFactory.AuthBusiness);

const GLogFactory = {
  GLogBusiness: glogBusinessImpl
};

export default GLogFactory;
