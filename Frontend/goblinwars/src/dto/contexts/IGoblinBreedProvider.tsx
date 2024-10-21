import { LoadingBreed } from "../business/LoadingBreed";
import { LoadingGoblin } from "../business/LoadingGoblin";
import { GoblinInfo } from "../domain/GoblinInfo";
import { RarityInfo } from "../domain/RarityInfo";
import ProviderResult from "./ProviderResult";
import ProviderResultDetail from "./ProviderResultDetail";


interface IGoblinBreedProvider {
    getGoblin1: (tokenId: number) => Promise<ProviderResult>;
    getGoblin2: (tokenId: number) => Promise<ProviderResult>;
    breed: (goblin1: GoblinInfo, goblin2: GoblinInfo) => Promise<ProviderResultDetail<number>>;
    getBreedCost: (tokenId1: number, tokenId2: number) => Promise<ProviderResult>;
    //getBreedRarity: (tokenId1: number, tokenId2: number) => Promise<ProviderResult>;
    rarity: RarityInfo;
    goblin1: GoblinInfo;
    goblin2: GoblinInfo;
    breedCost: number;
    loading: LoadingBreed;
}

export default IGoblinBreedProvider;