export interface IAnalytics {
  sendEvent: (category: string, action: string, value?: number) => void;
}