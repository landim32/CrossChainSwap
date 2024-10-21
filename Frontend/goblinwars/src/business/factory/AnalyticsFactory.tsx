import { Analytics } from '../../infra/impl/Analytics';
import { IAnalytics } from '../../infra/interface/IAnalytics';

const analyticsImpl: IAnalytics = Analytics;

const AnalyticsFactory = {
  Analytics: analyticsImpl
};

export default AnalyticsFactory;
