import ServiceFactory from '../../services/ServiceFactory';
import GoboxBusiness from '../impl/GoboxBusiness';
import IGoboxBusiness from '../interfaces/IGoboxBusiness';
import AuthFactory from './AuthFactory';

const goboxService = ServiceFactory.GoboxService;

const goboxBusinessImpl: IGoboxBusiness = GoboxBusiness;
goboxBusinessImpl.init(goboxService, AuthFactory.AuthBusiness);

const GoboxFactory = {
    GoboxBusiness: goboxBusinessImpl
};

export default GoboxFactory;
