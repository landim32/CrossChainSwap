import { IAnalytics } from "../interface/IAnalytics";
import ReactGA from "react-ga";

const Analytics : IAnalytics = {
  sendEvent: (category: string, action: string, value?: number) => {
    if(value || value == 0) {
      ReactGA.event({
        category: category,
        action: action,
        value: value
      });
    } else {
      ReactGA.event({
        category: category,
        action: action,
      });
    }
  }
}

export { Analytics }