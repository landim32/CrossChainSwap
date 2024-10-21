import ServiceFactory from '../../services/ServiceFactory';
import ConfigurationBusiness from '../impl/ConfigurationBusiness';
import DollarBusiness from '../impl/DollarBusiness';
import { IConfigurationBusiness } from '../interfaces/IConfigurationBusiness';
import { IDollarBusiness } from '../interfaces/IDollarBusiness';

const configurationService = ServiceFactory.ConfigurationService;

const configurationBusinessImpl: IConfigurationBusiness = ConfigurationBusiness;
configurationBusinessImpl.init(configurationService);

const ConfigurationFactory = {
  ConfigurationBusiness: configurationBusinessImpl
};

export { ConfigurationFactory };
