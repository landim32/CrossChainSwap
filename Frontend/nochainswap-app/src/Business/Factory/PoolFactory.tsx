import ServiceFactory from '../../Services/ServiceFactory';
import { PoolBusiness } from '../Impl/PoolBusiness';
import { IPoolBusiness } from '../Interfaces/IPoolBusiness';

const poolService = ServiceFactory.PoolService;

const poolBusinessImpl: IPoolBusiness = PoolBusiness;
poolBusinessImpl.init(poolService);

const PoolFactory = {
  PoolBusiness: poolBusinessImpl
};

export default PoolFactory;
