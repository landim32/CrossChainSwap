import { Backdrop, CircularProgress, Grid, Paper, Stack, Theme, Typography, styled, Tabs, Tab, Box, Fade, List, ListSubheader, ListItemButton, ListItemIcon, ListItemText, Collapse, IconButton, Divider } from "@mui/material";
import { motion } from "framer-motion";
import { useContext, useEffect, useState } from "react";
import { useHistory } from "react-router-dom";
import { QuestCard } from "../../components/QuestCard";
import { FontButton } from "../../utils/fontStyle";
import { GoblinStyles, MainStyles } from "../../utils/style";
import { SxProps } from '@mui/system';
import { GwViewPort } from "../../components/GwViewPort";
import { GoblinWarsColors } from "../../dto/styles/GoblinWarsColors";
import JobContext from "../../contexts/jobs/JobContext";
import ExpandLess from '@mui/icons-material/ExpandLess';
import ExpandMore from '@mui/icons-material/ExpandMore';
import WorkIcon from "../../assets/images/quest/work.png";
import JobIcon from "../../assets/images/menu/jobs.png";
import BlacksmithIcon from "../../assets/images/quest/blacksmith.png";
import FarmIcon from "../../assets/images/quest/farm.png";
import ProspectIcon from "../../assets/images/quest/prospect.png";
import SmeltingIcon from "../../assets/images/quest/smelting.png";
import WoodworkIcon from "../../assets/images/quest/woodwork.png";
import BoxCraftIcon from "../../assets/images/quest/boxcraft.png";
import TailoringClothIcon from "../../assets/images/quest/tailoring_cloth.png";
import TailoringMagicIcon from "../../assets/images/quest/tailoring_magic.png";
import ArmorsmithBronzeIcon from "../../assets/images/quest/armorsmith_bronze.png";
import ArmorsmithIronIcon from "../../assets/images/quest/armorsmith_iron.png";
import ArmorsmithSteelIcon from "../../assets/images/quest/armorsmith_steel.png";
import AxeIcon from "../../assets/images/quest/axe.png";
import LongRangedIcon from "../../assets/images/quest/ranged.png";
import SwordIcon from "../../assets/images/quest/sword.png";
import MaceIcon from "../../assets/images/quest/mace.png";
import KnifeIcon from "../../assets/images/quest/knife.png";
import ShieldIcon from "../../assets/images/quest/woodshield.png";
import SpearIcon from "../../assets/images/quest/spear.png";
import MagicIcon from "../../assets/images/quest/weaponsmith_magic.png";
import WeaponsmithWorkIcon from "../../assets/images/quest/weaponsmith_work.png";
import LeatherworkIcon from "../../assets/images/quest/letherwork.png";
import { isMobile } from "react-device-detect";
import { QuestInfo } from "../../dto/domain/QuestInfo";
import { GetDuration } from "../../utils/utils";
import { GenericSlot } from "../../components/GenericSlot";
import { QuestCategoryEnum } from "../../dto/enum/QuestCategoryEnum";
import { GetQuestCategory, GetQuestCategoryByStr } from "../../utils/QuestUtils";

const list = {
    visible: {
        opacity: 1,
        transition: {
            when: "beforeChildren",
            staggerChildren: 0.15,
            delayChildren: 0.25,
        },
    },
    hidden: {
        opacity: 0,
        transition: {
            when: "afterChildren",
        },
    },
}

const items = {
    visible: { opacity: 1, x: 0 },
    hidden: { opacity: 0, x: -150 },
}

const styleQtde: SxProps<Theme> = {
    ...GoblinStyles.textMain,
    fontSize: 16,
    bottom: 1,
    right: 4,
    position: "absolute"
  }

const msgEmptyTitle : SxProps<Theme> = {
    ...FontButton,
    fontSize: 22
}

const StyledTabs = styled((props: any) => (
    <Tabs
        {...props}
        TabIndicatorProps={{ children: <span className="MuiTabs-indicatorSpan" /> }}
    />
    ))({
    '& .MuiTabs-indicator': {
        display: 'flex',
        justifyContent: 'center',
        backgroundColor: 'transparent',
    },
    '& .MuiTabs-indicatorSpan': {
        maxWidth: 40,
        width: '100%',
        backgroundColor: GoblinWarsColors.darkBox,
    },
});
  
const StyledTab = styled((props: any) => <Tab disableRipple {...props} />)(
    ({ theme }) => ({
        textTransform: 'none',
        fontSize: 18,
        fontFamily: "Yeon Sung",
        color: GoblinWarsColors.titleColor,
        fontWeight: "bold",
        textShadow: "0px 2px 1px #000000,1px 1px 0px #000000;",
        '&.Mui-selected': {
            fontSize: 22,
            fontFamily: "Yeon Sung",
            color: GoblinWarsColors.buttonFontColor,
            fontWeight: "bold",
            textShadow: "0px 5px 4px #191719,1px 1px 0px #181813, rgb(61, 59, 46) 3px 0px 0px, rgb(61, 59, 46) 2.83487px 0.981584px 0px, rgb(61, 59, 46) 2.35766px 1.85511px 0px, rgb(61, 59, 46) 1.62091px 2.52441px 0px, rgb(61, 59, 46) 0.705713px 2.91581px 0px, rgb(61, 59, 46) -0.287171px 2.98622px 0px, rgb(61, 59, 46) -1.24844px 2.72789px 0px, rgb(61, 59, 46) -2.07227px 2.16926px 0px, rgb(61, 59, 46) -2.66798px 1.37182px 0px, rgb(61, 59, 46) -2.96998px 0.42336px 0px, rgb(61, 59, 46) -2.94502px -0.571704px 0px, rgb(61, 59, 46) -2.59586px -1.50383px 0px, rgb(61, 59, 46) -1.96093px -2.27041px 0px, rgb(61, 59, 46) -1.11013px -2.78704px 0px, rgb(61, 59, 46) -0.137119px -2.99686px 0px, rgb(61, 59, 46) 0.850987px -2.87677px 0px, rgb(61, 59, 46) 1.74541px -2.43999px 0px, rgb(61, 59, 46) 2.44769px -1.73459px 0px, rgb(61, 59, 46) 2.88051px -0.838247px 0px;"
        }
    }),
);

const msgEmpty = () => {
    return (
        <Grid xs={12} item key={"msgEmpty"}>
            <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox, p: 1 }}>
                <Typography sx={{ ...msgEmptyTitle }} >
                    <div>
                        <p>
                        You don't any jobs in progress.
                        </p>
                    </div>
                </Typography>
            </Paper>
        </Grid>
    );
}

const getCategoryIcon = (category: string) => {
    switch(GetQuestCategoryByStr(category)) {
        case QuestCategoryEnum.BoxCraft:
            return BoxCraftIcon;
        case QuestCategoryEnum.Prospect:
            return ProspectIcon;
        case QuestCategoryEnum.Farm:
            return FarmIcon;
        case QuestCategoryEnum.Smelting:
            return SmeltingIcon;
        case QuestCategoryEnum.Wood:
            return WoodworkIcon;
        case QuestCategoryEnum.Leatherwork:
            return LeatherworkIcon;
        case QuestCategoryEnum.TailoringCloth:
            return TailoringClothIcon;
        case QuestCategoryEnum.TailoringMagic:
            return TailoringMagicIcon;
        case QuestCategoryEnum.ArmorsmithBronze:
            return ArmorsmithBronzeIcon;
        case QuestCategoryEnum.ArmorsmithIron:
            return ArmorsmithIronIcon;
        case QuestCategoryEnum.ArmorsmithSteel:
            return ArmorsmithSteelIcon;
        case QuestCategoryEnum.WeaponsmithAxe:
            return AxeIcon;
        case QuestCategoryEnum.WeaponsmithLongRanged:
            return LongRangedIcon;
        case QuestCategoryEnum.WeaponsmithSword:
            return SwordIcon;
        case QuestCategoryEnum.WeaponsmithMace:
            return MaceIcon;
        case QuestCategoryEnum.WeaponsmithKnife:
            return KnifeIcon;
        case QuestCategoryEnum.WeaponsmithShield:
            return ShieldIcon;
        case QuestCategoryEnum.WeaponsmithSpear:
            return SpearIcon;
        case QuestCategoryEnum.WeaponsmithMagic:
            return MagicIcon;
        case QuestCategoryEnum.WeaponsmithWork:
            return WeaponsmithWorkIcon;
        default:
            return BlacksmithIcon;
    }
}

const getJobRewardImg = (quest: QuestInfo) => {
    return (
      <>
        {
          GetQuestCategory(quest) == QuestCategoryEnum.BoxCraft ?
          <img draggable="false"  src={quest.reward.items[0].item.iconAsset} style={{ width: 60 }} alt={quest.reward.items[0].item.name} />
          : 
          <GenericSlot boxSize={60} key={quest.reward.items[0].item.key} rarity={quest.reward.items[0].item.rarity} >
            {
              <Box sx={{ ...MainStyles.container, height: 50, width: 50, position: "relative" }} > 
                <img draggable="false"  src={quest.reward.items[0].item.iconAsset} style={{ width: "100%" }} alt={quest.reward.items[0].item.name} />
                <Typography sx={{...styleQtde}}>{quest.reward.items[0].qtde}</Typography>
              </Box>
            }
          </GenericSlot>
        }
      </>
    )
  }

const questRow = (quest: QuestInfo) => {
    if(isMobile)
        return questRowMobile(quest);
    return (
        <Stack sx={{ ...MainStyles.container, justifyContent: "space-between", width: 1 }} direction={"row"}>
            <Stack sx={{ alignItems: "flex-start", alignContent: "flex-start", width: 240 }} spacing={-1}>
                <Typography sx={{ ...GoblinStyles.textMain }} >{quest.name}</Typography>
            </Stack>
            <Stack sx={{ ...MainStyles.container, width: 120 }}>
              <Typography sx={{ ...GoblinStyles.sessionSubTitleText }}>Time cost</Typography>
              <Typography sx={{ ...GoblinStyles.sessionTitleText }}>{GetDuration(quest.timemin*1000, true)} ~ {GetDuration(quest.timemax*1000, true)}</Typography>
            </Stack>
            <Stack sx={{ ...MainStyles.container, width: 120 }}>
              <Typography sx={{ ...GoblinStyles.sessionSubTitleText }}>Min Power</Typography>
              <Typography sx={{ ...GoblinStyles.sessionTitleText }}>{quest.minpowerhash}</Typography>
            </Stack>
            <Box sx={{ ...MainStyles.container, width: 100 }}>
                {
                    getJobRewardImg(quest)
                }
            </Box>
            <IconButton sx={{ ml: 2 }}>
                <img draggable="false"  src={WorkIcon} style={{ height: 28 }} alt={"go"} />
            </IconButton>
        </Stack>
    )
}

const questRowMobile = (quest: QuestInfo) => {
    return (
        <Stack sx={{ ...MainStyles.container, width: 1 }} spacing={1} >
            {/*<Paper sx={{ ...iconBox }} elevation={8}>
                <img draggable="false"  src={icon} alt={title} style={{ ...iconMenu }} /> 
            </Paper>*/}
            <Box sx={{ width: 1 }} >
                <Typography sx={{ ...GoblinStyles.textMain, width: 1, textAlign: "center" }} >{quest.name}</Typography>
            </Box>
            <Stack sx={{ ...MainStyles.container, justifyContent: "space-between", width: 1 }} direction={"row"}>
                <Stack sx={{ ...MainStyles.container, width: 120 }}>
                    <Typography sx={{ ...GoblinStyles.sessionSubTitleText }}>Time cost</Typography>
                    <Typography sx={{ ...GoblinStyles.sessionTitleText }}>{GetDuration(quest.timemin*1000, true)} ~ {GetDuration(quest.timemax*1000, true)}</Typography>
                </Stack>
                <Stack sx={{ ...MainStyles.container, width: 120 }}>
                    <Typography sx={{ ...GoblinStyles.sessionSubTitleText }}>Min Power</Typography>
                    <Typography sx={{ ...GoblinStyles.sessionTitleText }}>{quest.minpowerhash}</Typography>
                </Stack>
            </Stack>
            <Stack sx={{ ...MainStyles.container, width: 1 }} spacing={0.5}>
                <Stack sx={{ ...MainStyles.container }} spacing={0.5} direction={"row"} >
                    <IconButton>
                        <img draggable="false"  src={WorkIcon} style={{ height: 28 }} alt={"go"} />
                    </IconButton>
                    <Typography sx={{ ...GoblinStyles.sessionSubTitleText }}>Reward</Typography>
                </Stack>
                <Box sx={{ ...MainStyles.container, width: 100 }}>
                    {
                        getJobRewardImg(quest)
                    }
                </Box>
            </Stack>
        </Stack>
    )
}

export function Jobs() {
    const jobContext = useContext(JobContext);
    const history = useHistory();

    const [value, setValue] = useState(0);
    const handleChange = (event : any, newValue : number) => {
        setValue(newValue);
    };

    useEffect(() => {
        jobContext.list();
        jobContext.listactive();
    }, []);

    return (
        <GwViewPort>
            {jobContext.jobs.length > 0 ?
            <Box sx={{ ...MainStyles.container, mb: 4, width: 1 }}>
                <Stack>
                    <StyledTabs value={value} onChange={handleChange} centered  >
                        <StyledTab label="Jobs" />
                        <StyledTab label="Jobs In Progress" />
                    </StyledTabs>
                    <Box sx={{ ...MainStyles.container, width: 1, position: "relative" }}>
                        <Fade in={value == 0}>
                        {
                            value == 0 ?
                            <motion.ul
                                style={{
                                    display: 'flex',
                                    flexWrap: 'wrap',
                                    listStyleType: 'none',
                                    paddingInlineStart: '0px',
                                    marginBlockStart: '0px',
                                    marginBlockEnd: '0px',
                                    alignItems: 'center',
                                    justifyContent: 'center',
                                }}
                                initial="hidden"
                                animate="visible"
                                variants={list}>
                                    <List
                                        sx={{ width: "100%", minWidth: isMobile ? 350 : 800, bgcolor: GoblinWarsColors.lightBox }}
                                        subheader={
                                            <ListSubheader sx={{ bgcolor: GoblinWarsColors.lightBox }}>
                                                <Stack sx={{ ...MainStyles.container, width: 1, py: 2 }}>
                                                    <Typography sx={{ ...GoblinStyles.textMain, textAlign: "center" }} >Avaliable Jobs</Typography>
                                                </Stack>
                                                <Divider />
                                            </ListSubheader>
                                        }
                                    >
                                        {!jobContext.loading.list ?
                                            jobContext.jobs.length > 0 ?
                                            jobContext.jobs.map((value) => (
                                                    <motion.li variants={items} key={value.category}>
                                                        <ListItemButton key={value.category} onClick={() => {
                                                            jobContext.setOpenCategory(value.category)
                                                        } }>
                                                            
                                                            <ListItemText>
                                                                <Stack sx={{ ...MainStyles.container, width: 1, justifyContent: "flex-start", justifyItems: "flex-start" }} spacing={1.5} direction={"row"}>
                                                                    <img draggable="false"  src={getCategoryIcon(value.category)} style={{ width: 30 }} />
                                                                    <Typography sx={{ ...GoblinStyles.textMain, textAlign: "left" }} >{value.category}</Typography>
                                                                </Stack>
                                                            </ListItemText>
                                                            {value.open ? <ExpandLess sx={{ color: "#FFFFFF" }} /> : <ExpandMore sx={{ color: "#FFFFFF" }} />}
                                                        </ListItemButton>
                                                        <Collapse in={value.open} timeout="auto" unmountOnExit>
                                                            <List component="div" disablePadding sx={{ bgcolor: GoblinWarsColors.darkBox }}>
                                                                {
                                                                    value.jobs && value.jobs.length > 0 &&
                                                                    value.jobs.map(listItem => (
                                                                        <>
                                                                        <ListItemButton sx={{ pl: 4 }} onClick={() => {
                                                                            history.push("/jobdetails?questId=" + listItem.id + "&questKey=" + listItem.questkey);
                                                                        }}>
                                                                            {
                                                                                questRow(listItem.quest)
                                                                            }
                                                                        </ListItemButton>
                                                                        <Divider />
                                                                        </>
                                                                    ))
                                                                }
                                                                
                                                            </List>
                                                        </Collapse>
                                                        <Divider />
                                                    </motion.li>
                                                ))
                                            :   <></>
                                        :<Backdrop
                                                sx={{ color: '#fff', zIndex: (theme) => 99 }}
                                                open={true}
                                            >
                                                <CircularProgress color="inherit" />
                                            </Backdrop>}
                                    </List>
                                </motion.ul>
                            : <Box></Box>
                        }
                        </Fade>
                        <Fade in={value == 1}>
                        {
                            value == 1 ?
                            <motion.ul
                                style={{
                                    display: 'flex',
                                    flexWrap: 'wrap',
                                    listStyleType: 'none',
                                    paddingInlineStart: '0px',
                                    marginBlockStart: '0px',
                                    marginBlockEnd: '0px',
                                    alignItems: 'center',
                                    justifyContent: 'center',
                                }}
                                initial="hidden"
                                animate="visible"
                                variants={list}>
                                    <Grid item xs={12} sx={{ margin: "10vh 0 5vh 0;" }}>
                                        <Grid container justifyContent="center" spacing={3}>
                                        {!jobContext.loading.listactive ?
                                            jobContext.activejobs.length > 0 ?
                                                jobContext.activejobs.map((value) => (
                                                    <Grid key={value.id} item>
                                                        <motion.li variants={items}>
                                                            <QuestCard
                                                                userQuestInfo={value}
                                                                detail={(userQuestInfo) => {
                                                                    history.push("/jobdetails?questId=" + userQuestInfo.id + "&questKey=" + userQuestInfo.questkey);
                                                                }}
                                                            />
                                                        </motion.li>
                                                    </Grid>
                                                ))
                                            :   msgEmpty()
                                        :<Backdrop
                                                sx={{ color: '#fff', zIndex: (theme) => 99 }}
                                                open={true}
                                            >
                                                <CircularProgress color="inherit" />
                                            </Backdrop>}
                                        </Grid>
                                    </Grid>
                                </motion.ul>
                            : <Box></Box>
                        }
                        </Fade>
                    </Box>
                </Stack>
            </Box>
            : <Backdrop
                sx={{ color: '#fff', zIndex: (theme) => 99 }}
                open={true}
            >
                <CircularProgress color="inherit" />
            </Backdrop>
        }
        </GwViewPort>
    )
}