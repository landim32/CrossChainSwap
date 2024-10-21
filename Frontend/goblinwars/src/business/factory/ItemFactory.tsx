import ServiceFactory from '../../services/ServiceFactory';
import { ItemBusiness } from '../impl/ItemBusiness';
import { IItemBusiness } from '../interfaces/IItemBusiness';
import AuthFactory from './AuthFactory';

const itemService = ServiceFactory.ItemService;

const itemBusinessImpl: IItemBusiness = ItemBusiness;
itemBusinessImpl.init(itemService, AuthFactory.AuthBusiness);

const ItemFactory = {
  ItemBusiness: itemBusinessImpl
};

export default ItemFactory;
