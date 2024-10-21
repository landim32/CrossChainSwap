import { Stack, Typography, SxProps, Theme, Paper, Divider } from "@mui/material";
import { QuestInfo } from "../dto/domain/QuestInfo";
import { GoblinWarsBackground, GoblinWarsColors } from "../dto/styles/GoblinWarsColors";
import { FontButton } from "../utils/fontStyle";
import AttackIcon from "../assets/images/goblin/attack_power.png";
import BlacksmithIcon from "../assets/images/goblin/blacksmith_power.png";
import HuntingIcon from "../assets/images/goblin/hunting_power.png";
import MagicIcon from "../assets/images/goblin/magic_power.png";
import MiningIcon from "../assets/images/goblin/mining_power.png";
import ResistenceIcon from "../assets/images/goblin/resistence_power.png";
import SocialIcon from "../assets/images/goblin/social_power.png";
import StealthIcon from "../assets/images/goblin/stealth_power.png";
import TailoringIcon from "../assets/images/goblin/tailoring_power.png";
import { GoblinStyles, MainStyles } from "../utils/style";

interface QuestRequerimentParam {
  quest: QuestInfo;
  currentAffinity: number;
}

const geneIconSize = 44;

const statsText : SxProps<Theme> = {
  ...FontButton,
  fontSize: 23
}

const statsIconBoxStyle : SxProps<Theme> = {
  ...MainStyles.container, 
  background: GoblinWarsBackground.containerBackground, 
  height: geneIconSize, 
  width: geneIconSize, 
  borderRadius: geneIconSize/2,
  borderWidth: 1,
  borderColor: GoblinWarsColors.darkBox
}

const statsBlock = (statsIcon: string, statsCompleteText: string) => {
  return (
    <Stack spacing={0.5} sx={{ ...MainStyles.container, width: 110 }} >
      <img draggable="false"  style={{ height: 32 }} src={statsIcon} />
      <Typography sx={{ ...statsText }} flexWrap={"wrap"} >{statsCompleteText}</Typography>
    </Stack>
  )
}

export function QuestRequeriment(param: QuestRequerimentParam) {

  return (
    <Stack sx={{ ...MainStyles.container, width: 1 }} spacing={2}>
      <Typography sx={{ ...GoblinStyles.textMain }} >Skill</Typography>
      <Stack sx={{ ...MainStyles.container, justifyContent: "space-around", flexWrap: "wrap", width: 1 }} direction={"row"}>
        {
          param.quest.requeriments.useattack &&
          statsBlock(AttackIcon, "Attack")
        }
        {
          param.quest.requeriments.useblacksmith &&
          statsBlock(BlacksmithIcon, "Blacksmith")
        }
        {
          param.quest.requeriments.usehunting &&
          statsBlock(HuntingIcon, "Hunting")
        }
        {
          param.quest.requeriments.usemagic &&
          statsBlock(MagicIcon, "Magic")
        }
        {
          param.quest.requeriments.usemining &&
          statsBlock(MiningIcon, "Mining")
        }
        {
          param.quest.requeriments.useresistence &&
          statsBlock(ResistenceIcon, "Resistence")
        }
        {
          param.quest.requeriments.usesocial &&
          statsBlock(SocialIcon, "Social")
        }
        {
          param.quest.requeriments.usestealth &&
          statsBlock(StealthIcon, "Stealth")
        }
        {
          param.quest.requeriments.usetailoring &&
          statsBlock(TailoringIcon, "Tailoring")
        }
      </Stack>
    </Stack>
  )
}