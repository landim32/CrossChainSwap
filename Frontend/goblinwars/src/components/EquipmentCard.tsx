import { Box, Button, Divider, Paper, Stack, SxProps, Theme, Typography } from "@mui/material";
import { GoblinStyles, MainStyles } from "../utils/style";
import AuctionInfo from "../dto/domain/AuctionInfo";
import { GenericSlot } from "./GenericSlot";
import { UserItemInfo } from "../dto/domain/UserItemInfo";
import { GoblinWarsColors } from "../dto/styles/GoblinWarsColors";
import { GetItemAssets } from "../utils/ItemAssetsUtils";
import gobiCoin from '../assets/images/coins/gobiCoin.png';
import goldPile from '../assets/images/quest/goldPile.png';
import MiningIcon from '../assets/images/icons/attributes/mining.png';
import SocialIcon from '../assets/images/icons/attributes/social.png';
import AttackIcon from '../assets/images/icons/attributes/attack.png';
import ResistenceIcon from '../assets/images/icons/attributes/resistence.png';
import HuntingIcon from '../assets/images/icons/attributes/hunting.png';
import TailoringIcon from '../assets/images/icons/attributes/tailoring.png';
import BlacksmithIcon from '../assets/images/icons/attributes/blacksmith.png';
import StealthIcon from '../assets/images/icons/attributes/stealth.png';
import MagicIcon from '../assets/images/icons/attributes/magic.png';
import { RarityStyles } from "../utils/RarityStyles";
import { ItemInfo } from "../dto/domain/ItemInfo";
import LinesEllipsis from 'react-lines-ellipsis';

interface EquipmentParam {
  item: ItemInfo;
  loading: boolean;
  auction?: AuctionInfo;
  qtdy?: number;
  buy?: (auction: AuctionInfo) => void;
  cancel?: (auction: AuctionInfo) => void;
  moreDetail?: (item: ItemInfo) => void;
  children?: any;
}

const styleQtde: SxProps<Theme> = {
  ...GoblinStyles.textMain,
  fontSize: 15,
  bottom: 2,
  right: 2,
  position: "absolute"
}
const stylePercent: SxProps<Theme> = {
  ...GoblinStyles.textMain,
  fontSize: 15,
  top: 2,
  right: 2,
  position: "absolute"
}

const iconSize = 24;

const getSkillBonusBlock = (icon: string, text: string, value: number) => {
  let isNegative = value < 0;
  return (
    <Stack sx={{ ...MainStyles.container }} direction={"row"} spacing={1}>
      <Box sx={{ alignContent: "flex-start", alignItems: "flex-start", width: 105 }}>
        <Typography sx={{ ...GoblinStyles.sessionTitleText }} textAlign={"right"}>{text}:</Typography>
      </Box>
      <Typography sx={{ ...GoblinStyles.sessionTitleText, color: isNegative ? "red" : "green" }}>{isNegative ? "-" : "+"}{value.toString().replace("-", "")}</Typography>
      <img src={icon} style={{ height: 28 }} alt={"Blacksmith Power"} />
    </Stack>
  )
}

export default function EquipmentCard(param: EquipmentParam) {

  return (
    <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox, p: 1, borderRadius: 3, width: 260 }} elevation={6}>
      <Stack sx={{ ...MainStyles.container }} spacing={2}>
          <Box sx={{  width: 240, height: 24 }}>
              <Typography sx={{ ...GoblinStyles.textMain, textAlign: "center" }}>
                <LinesEllipsis
                  text={param.item?.name}
                  maxLine='1'
                  ellipsis='...'
                  basedOn='letters'
                />
              </Typography>
          </Box>
          <GenericSlot boxSize={150} rarity={param.item?.rarity} >
              <img draggable="false" src={GetItemAssets(param.item?.iconAsset)} style={{ width: 120 }} />
          </GenericSlot>
          {
              param.item?.isBag &&
              <Stack sx={{ ...MainStyles.container }} spacing={1}>
                  <Typography sx={{ ...GoblinStyles.textMain }}>Content</Typography>
                  <Paper sx={{ ...MainStyles.container, width: 1, mx: 1.5, p: 1, bgcolor: GoblinWarsColors.lightBox }}>
                      <Stack sx={{ ...MainStyles.container, width: 1 }}>
                      <Typography sx={{ ...GoblinStyles.sessionTitleText }}>Granted Reward</Typography>
                      <Stack sx={{ ...MainStyles.container, flexWrap: "wrap", width: 1 }} direction={"row"} >
                          {
                          param.item?.destroyInfo.goldmax > 0 &&
                          <GenericSlot boxSize={80} >
                              <Box sx={{ ...MainStyles.container, width: 80, height: 80, position: "relative" }}>
                              <img draggable="false" src={goldPile} style={{ width: 65 }} />
                              <Typography sx={{ ...styleQtde }}>{param.item?.destroyInfo.goldmin}  ~  {param.item?.destroyInfo.goldmax}</Typography>
                              </Box>
                          </GenericSlot>
                          }
                          {
                            param.item?.destroyInfo.grantedreward.map(reward => (
                              <GenericSlot boxSize={80} rarity={reward.item.rarity} >
                                  <Box sx={{ ...MainStyles.container, width: 80, height: 80, position: "relative" }}>
                                      <img draggable="false" src={GetItemAssets(reward.item.iconAsset)} style={{ width: 65 }} />
                                      <Typography sx={{ ...styleQtde }}>{reward.qtdemin}  ~  {reward.qtdemax}</Typography>
                                  </Box>
                              </GenericSlot>
                            ))
                          }
                      </Stack>
                      </Stack>
                  </Paper>
                  {
                      param.item?.destroyInfo.randomqtdy > 0 &&
                      <Paper sx={{ ...MainStyles.container, width: 1, mx: 1.5, p: 1, bgcolor: GoblinWarsColors.lightBox }}>
                      <Stack sx={{ ...MainStyles.container, width: 1 }}>
                          <Typography sx={{ ...GoblinStyles.sessionTitleText }}>{param.item?.destroyInfo.randomqtdy} Random Reward</Typography>
                          <Stack sx={{ ...MainStyles.container, flexWrap: "wrap", width: 1 }} direction={"row"} >
                          {
                              param.item?.destroyInfo.randomreward.map(reward => (
                              <GenericSlot boxSize={80} rarity={reward.item.rarity} >
                                  <Box sx={{ ...MainStyles.container, width: 80, height: 80, position: "relative" }}>
                                      <img draggable="false" src={GetItemAssets(reward.item.iconAsset)} style={{ width: 65 }} />
                                      <Typography sx={{ ...stylePercent }}>{reward.percent} %</Typography>
                                      <Typography sx={{ ...styleQtde }}>{reward.qtdemin}  ~  {reward.qtdemax}</Typography>
                                  </Box>
                              </GenericSlot>
                              ))
                          }
                          </Stack>
                      </Stack>
                      </Paper> 
                  }
                  <Divider sx={{ color: GoblinWarsColors.darkBox, width: 1, height: 2 }} />
              </Stack>
          }
          {
            param.item?.isEquipment &&
            <Stack sx={{ ...MainStyles.container, width: 1, height: 120, justifyContent: "flex-start", justifyItems: "flex-start" }}>
              <Typography sx={{ ...GoblinStyles.textMain, textAlign: "center" }}>Skill Bonus</Typography>
              {
                param.item?.equipmentInfo?.mining != 0 && 
                getSkillBonusBlock(MiningIcon, "Mining", param.item?.equipmentInfo.mining)
              }
              {
                param.item?.equipmentInfo?.attack != 0 && 
                getSkillBonusBlock(AttackIcon, "Attack", param.item?.equipmentInfo.attack)
              }
              {
                param.item?.equipmentInfo?.resistence != 0 && 
                getSkillBonusBlock(ResistenceIcon, "Resistence", param.item?.equipmentInfo.resistence)
              }
              {
                param.item?.equipmentInfo?.hunting != 0 && 
                getSkillBonusBlock(HuntingIcon, "Hunting", param.item?.equipmentInfo.hunting)
              }
              {
                param.item?.equipmentInfo?.social != 0 && 
                getSkillBonusBlock(SocialIcon, "Social", param.item?.equipmentInfo.social)
              }
              {
                param.item?.equipmentInfo?.tailoring != 0 && 
                getSkillBonusBlock(TailoringIcon, "Tailoring", param.item?.equipmentInfo.tailoring)
              }
              {
                param.item?.equipmentInfo?.blacksmith != 0 && 
                getSkillBonusBlock(BlacksmithIcon, "Blacksmith", param.item?.equipmentInfo.blacksmith)
              }
              {
                param.item?.equipmentInfo?.stealth != 0 && 
                getSkillBonusBlock(StealthIcon, "Stealth", param.item?.equipmentInfo.stealth)
              }
              {
                param.item?.equipmentInfo?.magic != 0 && 
                getSkillBonusBlock(MagicIcon, "Magic", param.item?.equipmentInfo.magic)
              }
            </Stack>
          }
          <Divider sx={{ color: GoblinWarsColors.darkBox, width: 1, height: 2 }} />
          <Stack sx={{ alignContent: "flex-start", alignItems: "flex-start", width: "100%" }}>
            <Stack sx={{ ...MainStyles.container }} direction={"row"} spacing={1}>
                <Typography sx={{ ...GoblinStyles.sessionTitleText, width: 100 }} textAlign={"right"}>Rarity:</Typography>
                <Typography sx={{ ...GoblinStyles.sessionTitleText, color: RarityStyles.getRarityColor(param.item?.rarity) }}>{RarityStyles.getRarityName(param.item?.rarity)}</Typography>
            </Stack>
            <Stack sx={{ ...MainStyles.container }} direction={"row"} spacing={1}>
                <Typography sx={{ ...GoblinStyles.sessionTitleText, width: 100 }} textAlign={"right"}>Category:</Typography>
                <Typography sx={{ ...GoblinStyles.sessionTitleText }}>{param.item?.category}</Typography>
            </Stack>
            {param.auction ?
            <Stack sx={{ ...MainStyles.container, flexWrap: "wrap" }} direction={"row"} spacing={1} width={"100%"}>
              <img draggable="false"  src={gobiCoin} alt={"Gobi token"} style={{width: "20px", height: "20px"}} />
              <Typography sx={{ ...GoblinStyles.sessionTitleText }}>{param.auction.price}</Typography>
              {/*<Typography sx={{ ...GoblinStyles.sessionTitleText }}> / Qtdy: {param.auction.qtdy}</Typography>*/}
            </Stack>
            :
            <></>
            }
            {param.qtdy != null ?
            <Stack sx={{ ...MainStyles.container }} direction={"row"} spacing={1}>
              <Typography sx={{ ...GoblinStyles.sessionTitleText, width: 100 }} textAlign={"right"}>Qtdy:</Typography>
              <Typography sx={{ ...GoblinStyles.sessionTitleText }}>{param.qtdy}</Typography>
            </Stack>
            :
            <></>
            }
            {param.moreDetail ?
              <Button sx={{ ...MainStyles.mainButton }} onClick={() => { 
                param.moreDetail(param.item) 
              }} >More Details...</Button>
              :
              <></>
            }
            {param.buy ?
              <Button sx={{ ...MainStyles.mainButton }} onClick={() => {
                param.buy(param.auction); 
              }}>{param.loading ? "BUYING..." : "BUY"}</Button>
              :
              <></>
            }
            {param.cancel ?
              <Button sx={{ ...MainStyles.mainButton }} onClick={() => {
                param.cancel(param.auction); 
              }}>{param.loading ? "CANCELLING..." : "CANCEL"}</Button>
              :
              <></>
            }
          </Stack>
          {
            param.children
          }
      </Stack>
    </Paper>
  )
}