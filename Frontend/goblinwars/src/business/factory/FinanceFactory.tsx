import ServiceFactory from '../../services/ServiceFactory';
import FinanceBusiness from '../impl/FinanceBusiness';
import IFinanceBusiness from '../interfaces/IFinanceBusiness';
import AuthFactory from './AuthFactory';
import GobiFactory from './GobiFactory';

const financeService = ServiceFactory.FinanceService;

const financeBusinessImpl: IFinanceBusiness = FinanceBusiness;
financeBusinessImpl.init(financeService, AuthFactory.AuthBusiness, GobiFactory.GobiBusiness);

const FinanceFactory = {
  FinanceBusiness: financeBusinessImpl
};

export default FinanceFactory;
