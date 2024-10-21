import { GoblinInfo } from "../domain/GoblinInfo";
import ProviderResult from "./ProviderResult";

interface IGoblinNftProvider {
    list: () => Promise<ProviderResult>;
    mint: (tokenId: number) => Promise<ProviderResult>;
    claim: (tokenId: number) => Promise<ProviderResult>;
    deposit: (tokenId: number) => Promise<ProviderResult>;
    goblins: GoblinInfo[];
    loadingList: boolean;
    loadingAction: boolean;
}

export default IGoblinNftProvider;