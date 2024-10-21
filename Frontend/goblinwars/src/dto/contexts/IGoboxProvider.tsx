import { GoboxInfo } from "../domain/GoboxInfo";
import { ItemInfo } from "../domain/ItemInfo";
import ProviderResult from "./ProviderResult";
import ProviderResultDetail from "./ProviderResultDetail";

interface IGoboxProvider {
    list: () => Promise<ProviderResult>;
    listMyBox: () => Promise<ProviderResult>;
    buyToken: (box: number, amount: number) => Promise<ProviderResult>;
    openBox: (box: number) => Promise<ProviderResultDetail<number>>;
    openItemBox: (box: number) => Promise<ProviderResultDetail<ItemInfo[]>>;
    setCommonAmount: (value: number) => void;
    setUncommonAmount: (value: number) => void;
    setRareAmount: (value: number) => void;
    COMMON_ID: number;
    UNCOMMON_ID: number;
    RARE_ID: number;
    ITEM_COMMON_ID: number;
    ITEM_UNCOMMON_ID: number;
    ITEM_RARE_ID: number;
    ITEM_EPIC_ID: number;
    ITEM_LEGENDARY_ID: number;
    loading: boolean;
    goboxes: GoboxInfo[];
    goboxCommon: GoboxInfo;
    goboxUncommon: GoboxInfo;
    goboxRare: GoboxInfo;
    itemBoxCommon: GoboxInfo;
    itemBoxUncommon: GoboxInfo;
    itemBoxRare: GoboxInfo;
    itemBoxEpic: GoboxInfo;
    itemBoxLegendary: GoboxInfo;
    commonAmount: number;
    uncommonAmount: number;
    rareAmount: number;
}

export default IGoboxProvider;