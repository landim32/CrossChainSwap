import { GoblinListProvider } from "../business/GoblinListProvider";
import { LoadingGoblin } from "../business/LoadingGoblin";
import { GoblinInfo } from "../domain/GoblinInfo";
import { ItemInfo } from "../domain/ItemInfo";
import { BodyPartEnum } from "../enum/BodyPartEnum";
import ProviderResult from "./ProviderResult";
import ProviderResultDetail from "./ProviderResultDetail";


interface IGoblinProvider {
    listByUser: (page: number, itemsPerPage: number) => Promise<ProviderResult>;
    listGoblins: (reset: boolean) => Promise<ProviderResult>;
    listSpouseCandidates: (tokenId: number, reset: boolean) => Promise<ProviderResult>;
    myGoblin: (tokenId: number) => Promise<ProviderResult>;
    lastGoblin: () => Promise<ProviderResultDetail<GoblinInfo>>;
    listBrothers: (tokenId: number, page: number) => void;
    listGoblinsCanFuse: () => void;
    listSons: (tokenId: number, page: number) => void;
    updateGoblinName: (tokenId: number, name: string) => Promise<ProviderResult>;
    transferGoblin: (goblin: GoblinInfo, toAddress: string) => Promise<ProviderResult>;
    equipGoblin: (goblin: GoblinInfo, item: ItemInfo, part: BodyPartEnum) => Promise<ProviderResult>;
    rechargeGoblin: () => Promise<ProviderResult>;
    currentPage: number;
    totalPages: number;
    goblin: GoblinInfo;
    //breedCount?: number;
    goblinFather: GoblinInfo;
    goblinMother: GoblinInfo;
    goblinSpouse: GoblinInfo;
    brothers: GoblinListProvider;
    sons: GoblinListProvider;
    spouseCandidates: GoblinInfo[];
    goblins: GoblinInfo[];
    goblinsCanFuse: GoblinInfo[];
    loading: LoadingGoblin;
    genesis: boolean;
    cursorGobBreed: number;
}

export default IGoblinProvider;