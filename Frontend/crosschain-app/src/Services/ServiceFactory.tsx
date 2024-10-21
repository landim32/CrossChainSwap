import { HttpClient } from '../Infra/Impl/HttpClient';
import IHttpClient from '../Infra/Interface/IHttpClient';
import { IAuthService } from './Interfaces/IAuthService';
import { AuthService } from './Impl/AuthService';

const httpClientAuth : IHttpClient = HttpClient();
httpClientAuth.init(process.env.API_BASE_URL);

const authServiceImpl : IAuthService = AuthService;
authServiceImpl.init(httpClientAuth);

const ServiceFactory = {
  AuthService: authServiceImpl,
  setLogoffCallback: (cb : () => void) => {
    httpClientAuth.setLogoff(cb);
  }
};

export default ServiceFactory;