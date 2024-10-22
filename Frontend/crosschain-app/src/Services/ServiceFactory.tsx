import { HttpClient } from '../Infra/Impl/HttpClient';
import IHttpClient from '../Infra/Interface/IHttpClient';
import { IAuthService } from './Interfaces/IAuthService';
import { AuthService } from './Impl/AuthService';
import { IPoolService } from './Interfaces/IPoolService';
import { PoolService } from './Impl/PoolService';
import { IPriceService } from './Interfaces/IPriceService';
import { PriceService } from './Impl/PriceService';
import env from 'react-dotenv';

const httpClientAuth : IHttpClient = HttpClient();
httpClientAuth.init(env.API_BASE_URL);

const authServiceImpl : IAuthService = AuthService;
authServiceImpl.init(httpClientAuth);

const poolServiceImpl : IPoolService = PoolService;
poolServiceImpl.init(httpClientAuth);

const priceServiceImpl : IPriceService = PriceService;
priceServiceImpl.init(httpClientAuth);

const ServiceFactory = {
  AuthService: authServiceImpl,
  PoolService: poolServiceImpl,
  PriceService: priceServiceImpl,
  setLogoffCallback: (cb : () => void) => {
    httpClientAuth.setLogoff(cb);
  }
};

export default ServiceFactory;