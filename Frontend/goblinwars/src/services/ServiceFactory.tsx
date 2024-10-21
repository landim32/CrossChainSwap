import { HttpClient } from '../infra/impl/HttpClient';
import IHttpClient from '../infra/interface/IHttpClient';
import { AuctionService } from './impl/AuctionService';
import { AuthService } from './impl/AuthService';
import ConfigurationService from './impl/ConfigurationService';
import EquipmentService from './impl/EquipmentService';
import FinanceService from './impl/FinanceService';
import GLogService from './impl/GLogService';
import GoblinNftService from './impl/GoblinNftService';
import { GoblinService } from './impl/GoblinService';
import { GoblinUserService } from './impl/GoblinUserService';
import GoboxService from './impl/GoboxService';
import { GoldFinanceService } from './impl/GoldFinanceService';
import { ItemService } from './impl/ItemService';
import { MaterialMarketService } from './impl/MaterialMarketService';
import { MiningService } from './impl/MiningService';
import { QuestService } from './impl/QuestService';
import ReferralService from './impl/ReferralService';
import IAuctionService from './interfaces/IAuctionService';
import { IAuthService } from './interfaces/IAuthService';
import { IConfigurationService } from './interfaces/IConfigurationService';
import { IEquipmentService } from './interfaces/IEquipmentService';
import IFinanceService from './interfaces/IFinanceService';
import IGLogService from './interfaces/IGLogService';
import IGoblinNftService from './interfaces/IGoblinNftService';
import { IGoblinService } from './interfaces/IGoblinService';
import { IGoblinUserService } from './interfaces/IGoblinUserService';
import { IGoboxService } from './interfaces/IGoboxService';
import { IGoldFinanceService } from './interfaces/IGoldFinanceService';
import { IItemService } from './interfaces/IItemService';
import { IMaterialMarketService } from './interfaces/IMaterialMarketService';
import { IMiningService } from './interfaces/IMiningService';
import { IQuestService } from './interfaces/IQuestService';
import IReferralService from './interfaces/IReferralService';



const httpClientAuth : IHttpClient = HttpClient();
httpClientAuth.init(process.env.REACT_APP_BASE_URL + process.env.REACT_APP_PORT_AUTH);

const authServiceImpl : IAuthService = AuthService;
authServiceImpl.init(httpClientAuth);

const httpClientGoblin : IHttpClient = HttpClient();
httpClientGoblin.init(process.env.REACT_APP_BASE_URL + process.env.REACT_APP_PORT_GOBLIN);
//httpClientGoblin.init("https://localhost:5004/");

const httpClientEquipment : IHttpClient = HttpClient();
httpClientEquipment.init(process.env.REACT_APP_BASE_URL + process.env.REACT_APP_PORT_EQUIPMENT);
//httpClientEquipment.init("http://localhost:46275/");

const goblinServiceImpl : IGoblinService = GoblinService;
goblinServiceImpl.init(httpClientGoblin);

const goblinUserServiceImpl : IGoblinUserService = GoblinUserService;
goblinUserServiceImpl.init(httpClientGoblin);

const itemServiceImpl : IItemService = ItemService;
itemServiceImpl.init(httpClientGoblin);

const questServiceImpl : IQuestService = QuestService;
questServiceImpl.init(httpClientGoblin);

const miningServiceImpl : IMiningService = MiningService;
miningServiceImpl.init(httpClientGoblin);

const auctionServiceImpl : IAuctionService = AuctionService;
auctionServiceImpl.init(httpClientGoblin);

const referralServiceImpl : IReferralService = ReferralService;
referralServiceImpl.init(httpClientGoblin);

const glogServiceImpl : IGLogService = GLogService;
glogServiceImpl.init(httpClientGoblin);

const financeServiceImpl : IFinanceService = FinanceService;
financeServiceImpl.init(httpClientGoblin);

const goboxServiceImpl : IGoboxService = GoboxService;
goboxServiceImpl.init(httpClientGoblin);

const configurationServiceImpl : IConfigurationService = ConfigurationService;
configurationServiceImpl.init(httpClientGoblin);

const equipmentServiceImpl : IEquipmentService = EquipmentService;
equipmentServiceImpl.init(httpClientEquipment);

const goblinNftServiceImpl : IGoblinNftService = GoblinNftService;
goblinNftServiceImpl.init(httpClientGoblin);

const goldFinanceServiceImpl : IGoldFinanceService = GoldFinanceService;
goldFinanceServiceImpl.init(httpClientGoblin);

const materialMarketServiceImpl : IMaterialMarketService = MaterialMarketService;
materialMarketServiceImpl.init(httpClientGoblin);

const ServiceFactory = {
  AuthService: authServiceImpl,
  GoblinService: goblinServiceImpl,
  GoblinUserService: goblinUserServiceImpl,
  GoblinNftService: goblinNftServiceImpl,
  ItemService: itemServiceImpl,
  QuestService: questServiceImpl,
  MiningService: miningServiceImpl,
  AuctionService: auctionServiceImpl,
  ReferralService: referralServiceImpl,
  GLogService: glogServiceImpl,
  FinanceService: financeServiceImpl,
  GoboxService: goboxServiceImpl,
  ConfigurationService: configurationServiceImpl,
  EquipmentService: equipmentServiceImpl,
  GoldFinanceService: goldFinanceServiceImpl,
  MaterialMarketService: materialMarketServiceImpl,
  setLogoffCallback: (cb : () => void) => {
    httpClientAuth.setLogoff(cb);
    httpClientGoblin.setLogoff(cb);
    httpClientEquipment.setLogoff(cb);
  }
};

export default ServiceFactory;