import ServiceFactory from '../../services/ServiceFactory';
import { GoldFinanceBusiness } from '../impl/GoldFinanceBusiness';
import { IGoldFinanceBusiness } from '../interfaces/IGoldFinanceBusiness';
import AuthFactory from './AuthFactory';

const goldFinanceService = ServiceFactory.GoldFinanceService;

const goldFinanceBusinessImpl: IGoldFinanceBusiness = GoldFinanceBusiness;
goldFinanceBusinessImpl.init(goldFinanceService, AuthFactory.AuthBusiness);

const GoldFinanceFactory = {
  GoldFinanceBusiness: goldFinanceBusinessImpl
};

export default GoldFinanceFactory;
