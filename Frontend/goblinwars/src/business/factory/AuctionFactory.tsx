import ServiceFactory from '../../services/ServiceFactory';
import AuctionBusiness from '../impl/AuctionBusiness';
import IAuctionBusiness from '../interfaces/IAuctionBusiness';
import AuthFactory from './AuthFactory';

const auctionService = ServiceFactory.AuctionService;

const auctionBusinessImpl: IAuctionBusiness = AuctionBusiness;
auctionBusinessImpl.init(auctionService, AuthFactory.AuthBusiness);

const AuctionFactory = {
  AuctionBusiness: auctionBusinessImpl
};

export default AuctionFactory;
