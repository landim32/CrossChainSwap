import ReferralUserInfo from "./ReferralUserInfo";

export default interface ReferralInfo {
    logged: boolean;
    inWhiteList: boolean;
    iduser: number;
    score: number;
    publicaddress: string;
    emailCollapse: boolean;
    emailComplete: boolean;
    email: string;
    name: string;
    twitterCollapse: boolean;
    twitterclick: boolean;
    twitterfollow: boolean;
    retweetCollapse: boolean;
    retweetclick: boolean;
    retweet: boolean;
    tweeturl: string;
    twitterid: string;
    facebookCollapse: boolean;
    facebookclick: boolean;
    facebooklike: boolean;
    facebookid: string;
    discordCollapse: boolean;
    discordclick: boolean;
    discordjoin: boolean;
    discordid: string;
    telegramCollapse: boolean;
    telegramclick: boolean;
    telegramjoin: boolean;
    telegramid: string;
    retweets: string[];
    shareCollapse: boolean;
    referralusers: ReferralUserInfo[];
    referralurl: string;
}