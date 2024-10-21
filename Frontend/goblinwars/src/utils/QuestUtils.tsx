import { QuestInfo } from "../dto/domain/QuestInfo";
import { QuestStatus } from "../dto/enum/QuestStatus";
import { QuestType } from "../dto/enum/QuestType";
import ForgeBackground from "../assets/images/quest/forge.png";
import CaveBackground from "../assets/images/quest/cave.png";
import DesertBackground from "../assets/images/quest/desert.png";
import ForestBackground from "../assets/images/quest/forest.png";
import { QuestDifficultyEnum } from "../dto/enum/QuestDifficultyEnum";
import { GoblinWarsColors } from "../dto/styles/GoblinWarsColors";
import { Stack, Typography, Box, SxProps, Theme } from "@mui/material";
import { GenericSlot } from "../components/GenericSlot";
import { MainStyles, GoblinStyles } from "./style";
import goldPile from '../assets/images/quest/goldPile.png';
import { QuestCategoryEnum } from "../dto/enum/QuestCategoryEnum";
import { ItemInfo } from "../dto/domain/ItemInfo";

const styleQtde: SxProps<Theme> = {
  ...GoblinStyles.textMain,
  fontSize: 16,
  bottom: 0,
  right: 2,
  position: "absolute"
}

const GetStatusColor = (status: QuestStatus) => {
  switch(status) {
    case QuestStatus.Success:
      return "#4BB543";
    case QuestStatus.Failed:
      return "#FA113D";
    case QuestStatus.Started:
      return "#2c8558";
  }
}

const GetStatusName = (status: QuestStatus) => {
  switch(status) {
    case QuestStatus.Success:
      return "Success";
    case QuestStatus.Failed:
      return "Failed";
    case QuestStatus.Started:
      return "Started";
  }
}

const GetDifficultyName = (difficulty: QuestDifficultyEnum) => {
  switch(difficulty) {
    case QuestDifficultyEnum.VeryEasy:
      return "Very Easy";
    case QuestDifficultyEnum.Easy:
      return "Easy";
    case QuestDifficultyEnum.Medium:
      return "Medium";
    case QuestDifficultyEnum.Hard:
      return "Hard";
    case QuestDifficultyEnum.VeryHard:
      return "Very Hard";
    default:
      return "";
  }
}

const GetDifficultyColor= (difficulty: QuestDifficultyEnum) => {
  switch(difficulty) {
    case QuestDifficultyEnum.VeryEasy:
      return "#a9a9a9";
    case QuestDifficultyEnum.Easy:
      return "#1EFF0C";
    case QuestDifficultyEnum.Medium:
      return "#0070FF";
    case QuestDifficultyEnum.Hard:
      return "#A335EE";
    case QuestDifficultyEnum.VeryHard:
      return "#FF8000";
    default:
      return GoblinWarsColors.darkBox;
  }
}

const GetCardBackground = (quest: QuestInfo) => {
  if(quest.questtype == QuestType.Job)
    return ForgeBackground;
  else {
    switch(quest.imageasset) {
      case "forest.png":
        return ForestBackground;
      case "desert.png":
        return DesertBackground; 
      case "cave.png":
        return CaveBackground;
    }
  }
}

const GetRewardBlock = (quest: QuestInfo, openPoup: (ev: any, item: ItemInfo) => void) => {

  return (
    <Stack sx={{ ...MainStyles.container }} >
      <Typography sx={{ ...GoblinStyles.textMain }}>Reward</Typography>
      <Stack sx={{ ...MainStyles.container, flexWrap: "wrap" }} direction={"row"}>
        {
          quest.reward.gold > 0 &&
          <GenericSlot boxSize={76} key={"coin"} >
            {
              <Box sx={{ height: 56, width: 56, position: "relative" }} > 
                <img draggable="false"  src={goldPile} style={{ width: "100%" }} alt={"coin"} />
                <Typography sx={{...styleQtde}}>{quest.reward.gold}</Typography>
              </Box>
            }
          </GenericSlot>
        }
        {
          quest.reward.items.map((item) => {
            return (
              <Box  onClick={(ev: any) => {
                openPoup(ev, item.item);
              }}>
                <GenericSlot boxSize={76} key={item.itemkey} rarity={item.item.rarity} >
                  {
                    <Box sx={{ height: 56, width: 56, position: "relative" }} > 
                      <img draggable="false"  src={item.item.iconAsset} style={{ width: "100%" }} alt={item.item.name} />
                      <Typography sx={{...styleQtde}}>{item.qtde}</Typography>
                    </Box>
                  }
                </GenericSlot>
              </Box>
              
            )
          })
        }
      </Stack>
    </Stack>
  )
}

const GetQuestCategoryByStr =  (category: string) => {
  switch(category) {
    case "Box Craft":
      return QuestCategoryEnum.BoxCraft;
    case "Prospect":
      return QuestCategoryEnum.Prospect;
    case "Smelting":
      return QuestCategoryEnum.Smelting;
    case "Criminal":
      return QuestCategoryEnum.Criminal;
    case "Dungeons":
      return QuestCategoryEnum.Dungeons;
    case "Hunter":
      return QuestCategoryEnum.Hunter;
    case "Farm":
      return QuestCategoryEnum.Farm;
    case "Woodwork":
      return QuestCategoryEnum.Wood;
    case "Leatherworking":
      return QuestCategoryEnum.Leatherwork;
    case "Tailoring / Cloth":
      return QuestCategoryEnum.TailoringCloth;
    case "Tailoring / Magic":
      return QuestCategoryEnum.TailoringMagic;
    case "Armorsmith / Bronze":
      return QuestCategoryEnum.ArmorsmithBronze;
    case "Armorsmith / Iron":
      return QuestCategoryEnum.ArmorsmithIron; 
    case "Armorsmith / Steel":
      return QuestCategoryEnum.ArmorsmithSteel;
    case "Weaponsmith / Axe":
      return QuestCategoryEnum.WeaponsmithAxe;
    case "Weaponsmith / Long Ranged":
      return QuestCategoryEnum.WeaponsmithLongRanged;
    case "Weaponsmith / Sword":
      return QuestCategoryEnum.WeaponsmithSword;
    case "Weaponsmith / Mace":
      return QuestCategoryEnum.WeaponsmithMace;
    case "Weaponsmith / Knife":
      return QuestCategoryEnum.WeaponsmithKnife;
    case "Weaponsmith / Work":
      return QuestCategoryEnum.WeaponsmithWork;
    case "Weaponsmith / Shield":
      return QuestCategoryEnum.WeaponsmithShield;
    case "Weaponsmith / Spear":
      return QuestCategoryEnum.WeaponsmithSpear;
    case "Weaponsmith / Magic":
      return QuestCategoryEnum.WeaponsmithMagic;
    default:
      return QuestCategoryEnum.Unknown;
  }
};

const GetQuestCategory =  (quest: QuestInfo) => {
  return GetQuestCategoryByStr(quest.category);
};

export { GetStatusColor, GetStatusName, GetCardBackground, GetDifficultyName, GetDifficultyColor, GetRewardBlock, GetQuestCategory, GetQuestCategoryByStr }