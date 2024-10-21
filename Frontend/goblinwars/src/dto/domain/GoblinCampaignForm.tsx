export interface GoblinCampaignForm {
  totalSupply: number;
  reward: number;
  beginDate: number;
  endDate: number;
  textDate: string;
  canPerform: boolean;
  ended: boolean;
  logged: boolean;
  email: string;
  name: string;
  twitterId: string;
  retweetId: string;
  facebookId: string;
  discordId: string;
  telegramId: string;
  shareLink: string;
  submited: boolean;
  erroMetamask: boolean;
  erroMetamaskMessage: string;
}