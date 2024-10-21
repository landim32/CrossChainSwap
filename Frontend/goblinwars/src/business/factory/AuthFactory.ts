import ServiceFactory from '../../services/ServiceFactory';
import { AuthBusiness } from '../impl/AuthBusiness';
import { IAuthBusiness } from '../interfaces/IAuthBusiness';

const authService = ServiceFactory.AuthService;

const authBusinessImpl: IAuthBusiness = AuthBusiness;
authBusinessImpl.init(authService);

const AuthFactory = {
  AuthBusiness: authBusinessImpl
};

export default AuthFactory;
