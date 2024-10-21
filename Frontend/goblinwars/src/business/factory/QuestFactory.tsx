import ServiceFactory from '../../services/ServiceFactory';
import { QuestBusiness } from '../impl/QuestBusiness';
import { IQuestBusiness } from '../interfaces/IQuestBusiness';
import AuthFactory from './AuthFactory';

const questService = ServiceFactory.QuestService;

const questBusinessImpl: IQuestBusiness = QuestBusiness;
questBusinessImpl.init(questService, AuthFactory.AuthBusiness);

const QuestFactory = {
  QuestBusiness: questBusinessImpl
};

export default QuestFactory;
