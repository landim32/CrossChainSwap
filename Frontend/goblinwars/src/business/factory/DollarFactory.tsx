import DollarBusiness from '../impl/DollarBusiness';
import { IDollarBusiness } from '../interfaces/IDollarBusiness';

//const goblinService = ServiceFactory.GoblinService;

const dollarBusinessImpl: IDollarBusiness = DollarBusiness;
//dollarBusinessImpl.init(goblinService, AuthFactory.AuthBusiness);

const DollarFactory = {
    DollarBusiness: dollarBusinessImpl
};

export default DollarFactory;
