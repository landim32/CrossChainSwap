import { GoblinInfo } from "../domain/GoblinInfo";
import ProviderResult from "./ProviderResult";
import ProviderResultDetail from "./ProviderResultDetail";

export default interface IFuseProvider {
    getGoblins: (targetTokenId: number, sacrificeTokenId: number) => Promise<ProviderResult>;
    getFuseCost: (tokenId: number) => Promise<ProviderResultDetail<number>>;
    fuse: () => Promise<ProviderResultDetail<number>>;
    //aproveTarget: () => Promise<ProviderResult>;
    //aproveSacrifice: () => Promise<ProviderResult>;
    //isGobiApproved: (_fuseCost: number) => Promise<ProviderResult>;
    //approveGobi: () => Promise<ProviderResult>;
    goblinTarget: GoblinInfo;
    goblinSacrifice: GoblinInfo;
    fuseCost: number;
    loadingCost: boolean;
    loadingFuse: boolean;
    //loadingTargetAproved: boolean;
    //loadingGobiApproved: boolean;
    //goblinTargetAproved: boolean;
    //loadingSacrificeAproved: boolean;
    //goblinSacrificeAproved: boolean;
    //gobiApproved: boolean;
}