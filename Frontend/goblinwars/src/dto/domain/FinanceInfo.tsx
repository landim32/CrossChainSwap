export default interface FinanceInfo {
    publicaddress: string;
    hotwalletgobi: number;
    hotwalletbnb: number;
    lastwithdrawl?: string;
    nextwithdrawlwithoutfee?: string;
    daysfornofee: number;
    minimalgobifee: number;
    minimalgobi: number;
    gobioncloudwallet: number;
    gobionmetamask: number;
    withdrawalmin: number;
    maxfeepercent: number;
    withdrawallimit: number;
    canwithdrawal: boolean;
  }