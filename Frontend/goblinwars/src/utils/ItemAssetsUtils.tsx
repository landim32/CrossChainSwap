import ChestMiningIcon from "../assets/images/itens/armor_mining_chest.png";
import HelmetMiningIcon from "../assets/images/itens/armor_mining_helm.png";
import HandsMiningIcon from "../assets/images/itens/armor_mining_hand.png";
import BootsMiningIcon from "../assets/images/itens/armor_mining_boot.png";
import PickaxeMiningIcon from "../assets/images/itens/pickaxe.png";

const GetItemAssets = (cloudPath: string) => {
  switch(cloudPath) {
    case "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor_mining_chest.png":
      return ChestMiningIcon;
    case "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor_mining_boot.png":
      return BootsMiningIcon;
    case "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor_mining_hand.png":
      return HandsMiningIcon;
    case "https://goblinwars.blob.core.windows.net/basegoblins/Itens/armor_mining_helm.png":
      return HelmetMiningIcon;
    case "https://goblinwars.blob.core.windows.net/basegoblins/Itens/pickaxe.png":
      return PickaxeMiningIcon;
    default:
      return cloudPath;
  }
}

export { GetItemAssets }