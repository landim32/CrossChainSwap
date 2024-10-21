import { Alert, AlertColor, Box, Button, CircularProgress, Divider, Fade, Paper, Snackbar, Stack, Tab, Tabs, Theme, Typography, SxProps, styled } from "@mui/material";
import { GwViewPort } from "../../components/GwViewPort";
import MiningContext from "../../contexts/mining/MiningContext";
import { GoblinStyles, MainStyles } from "../../utils/style";
import { useContext, useEffect, useState } from "react";
import HashPowerIcon from '../../assets/images/mining/hashPower.png';
import { isMobile } from 'react-device-detect';
import { GoblinWarsColors } from "../../dto/styles/GoblinWarsColors";
import { motion } from "framer-motion";
import { FontButton } from "../../utils/fontStyle";
import HordeIcon from '../../assets/images/menu/horde.png';
import Gobox1 from '../../assets/images/box/gobox1.png';
import Gobox2 from '../../assets/images/box/gobox2.png';
import Gobox3 from '../../assets/images/box/gobox3.png';
import ItemLegendary from '../../assets/images/box/item-legendary.png';
import ItemEpic from '../../assets/images/box/item-epic.png';
import ItemRare from '../../assets/images/box/item-rare.png';
import ItemUncommon from '../../assets/images/box/item-uncommon.png';
import ItemCommon from '../../assets/images/box/item-common.png';
import { useTimer } from "react-timer-hook";
import moment from "moment";
import GoblinUserContext from "../../contexts/goblinUser/GoblinUserContext";

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

const subInfoStyle : SxProps<Theme> = {
    ...GoblinStyles.sessionSubTitleText,
    fontSize: 14
}

const statsText : SxProps<Theme> = {
    ...FontButton,
    fontSize: 23
}

const items = {
    visible: { opacity: 1, x: 0 },
    hidden: { opacity: 0, x: -150 },
}

export function MiningRank() {
    const miningContext = useContext(MiningContext);
    const goblinUserContext = useContext(GoblinUserContext);
    const maxWidth = isMobile ? 350 : 700;

    const [openDialog, setOpenDialog] = useState(false);
    const [message, setMessage] = useState("");
    const [severity, setSeverity] = useState<AlertColor>("success");

    const [value, setValue] = useState(0);

    const handleClose = (ev: any) => {
        if (ev?.reason === 'clickaway') {
            return;
        }
        setOpenDialog(false);
    };

    const showDialog = (message: string, severity: AlertColor) => {
        setSeverity(severity);
        setMessage(message);
        setOpenDialog(true);
    }

    const handleChange = (event : any, newValue : number) => {
        setValue(newValue);
    };

    interface TimerParam {
        expiryTimestamp: Date;
        title: string;
    }

    function MyTimer(param: TimerParam) {
        const {
          seconds,
          minutes,
          hours,
          days,
          isRunning,
          start,
          pause,
          resume,
          restart,
        } = useTimer({ expiryTimestamp: param.expiryTimestamp, onExpire:  () => console.warn('onExpire called') });
      
      
        return (
          <Stack direction={"row"} sx={{ ...MainStyles.container }} spacing={1}>
            <Typography sx={{ ...GoblinStyles.sessionTitleText }} >{param.title}</Typography>
            <Typography sx={{ ...GoblinStyles.textMain }} >{days + " days " + hours + " hr " + minutes + " min " + seconds + " sec"}</Typography>
          </Stack>
        );
    }

    function getMonthlyReward(ranking: number) {
        if (ranking == 1) {
            return <img draggable="false"  src={Gobox3} style={{ height: 54 }} alt={"Gobox Rare"} />;
        }
        else if (ranking == 2) {
            return <img draggable="false"  src={Gobox2} style={{ height: 54 }} alt={"Gobox Uncommon"} />;
        }
        else if (ranking == 3) {
            return <img draggable="false"  src={Gobox1} style={{ height: 54 }} alt={"Gobox Common"} />;
        }
        else if (ranking == 4) {
            return <img draggable="false"  src={ItemLegendary} style={{ height: 54 }} alt={"ItemBox Legendary"} />;
        }
        else if (ranking == 5) {
            return <img draggable="false"  src={ItemEpic} style={{ height: 54 }} alt={"ItemBox Epic"} />;
        }
        else if (ranking == 6) {
            return <img draggable="false"  src={ItemRare} style={{ height: 54 }} alt={"ItemBox Rare"} />;
        }
        else if (ranking == 7) {
            return <img draggable="false"  src={ItemUncommon} style={{ height: 54 }} alt={"ItemBox Uncommon"} />;
        }
        else if (ranking == 8) {
            return <img draggable="false"  src={ItemCommon} style={{ height: 54 }} alt={"ItemBox Common"} />;
        }
        else {
            return <Box sx={{ height: 54, width: 54 }}><Typography> </Typography></Box>
        }
    }

    function getWeeklyReward(ranking: number) {
        if (ranking == 1) {
            return <img draggable="false"  src={ItemLegendary} style={{ height: 54 }} alt={"ItemBox Legendary"} />;
        }
        else if (ranking == 2) {
            return <img draggable="false"  src={ItemEpic} style={{ height: 54 }} alt={"ItemBox Epic"} />;
        }
        else if (ranking == 3) {
            return <img draggable="false"  src={ItemRare} style={{ height: 54 }} alt={"ItemBox Rare"} />;
        }
        else if (ranking == 4) {
            return <img draggable="false"  src={ItemUncommon} style={{ height: 54 }} alt={"ItemBox Uncommon"} />;
        }
        else if (ranking == 5) {
            return <img draggable="false"  src={ItemCommon} style={{ height: 54 }} alt={"ItemBox Common"} />;
        }
        else if (ranking == 6) {
            return <img draggable="false"  src={ItemCommon} style={{ height: 54 }} alt={"ItemBox Common"} />;
        }
        else {
            return <Box sx={{ height: 54, width: 54 }}><Typography> </Typography></Box>
        }
    }

    function getBoxType(boxType: number) {
        if (boxType == 1) {
            return <img draggable="false"  src={Gobox1} style={{ height: 54 }} alt={"Gobox Common"} />;
        }
        else if (boxType == 2) {
            return <img draggable="false"  src={Gobox2} style={{ height: 54 }} alt={"Gobox Uncommon"} />;
        }
        else if (boxType == 3) {
            return <img draggable="false"  src={Gobox3} style={{ height: 54 }} alt={"Gobox Rare"} />;
        }
        else if (boxType == 4) {
            return <img draggable="false"  src={ItemCommon} style={{ height: 54 }} alt={"ItemBox Common"} />;
        }
        else if (boxType == 5) {
            return <img draggable="false"  src={ItemUncommon} style={{ height: 54 }} alt={"ItemBox Uncommon"} />;
        }
        else if (boxType == 6) {
            return <img draggable="false"  src={ItemRare} style={{ height: 54 }} alt={"ItemBox Rare"} />;
        }
        else if (boxType == 7) {
            return <img draggable="false"  src={ItemEpic} style={{ height: 54 }} alt={"ItemBox Epic"} />;
        }
        else if (boxType == 8) {
            return <img draggable="false"  src={ItemLegendary} style={{ height: 54 }} alt={"ItemBox Legendary"} />;
        }
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

    useEffect(() => {
        miningContext.listRankTop100().then((ret) => {
            if (!ret.sucesso) {
                showDialog(ret.mensagemErro, 'error');
            }
        });
        miningContext.listRankWeekly().then((ret) => {
            if (!ret.sucesso) {
                showDialog(ret.mensagemErro, 'error');
            }
        });
        miningContext.listRankMonthly().then((ret) => {
            if (!ret.sucesso) {
                showDialog(ret.mensagemErro, 'error');
            }
        });
        miningContext.listHistoryByUser().then((ret) => {
            if (!ret.sucesso) {
                showDialog(ret.mensagemErro, 'error');
            }
        });
    }, [])

    return (
        <GwViewPort>
            <Box sx={{ ...MainStyles.container, mb: 4, width: 1 }}>
                <Stack>
                    <StyledTabs value={value} onChange={handleChange} centered  >
                        <StyledTab label="TOP 100 HASH POWER" />
                        <StyledTab label="WEEKLY TOP 6" />
                        <StyledTab label="MONTHLY TOP 10" />
                        <StyledTab label="MY REWARDS" />
                    </StyledTabs>
                    <Box sx={{ ...MainStyles.container, width: 1, position: "relative" }}>
                        <Fade in={value == 0}>
                        {
                            miningContext.rankingTop100 && value == 0 ?
                            <Stack direction="row" sx={{ ...MainStyles.container, position: "absolute", top: 0, width: maxWidth, flexWrap: "wrap" }}>
                                <Paper sx={{ ...MainStyles.container, p: 2, width: maxWidth, bgcolor: GoblinWarsColors.darkBox }} elevation={6}>
                                    <Stack sx={{ ...MainStyles.container, width: 1 }}>
                                        <Typography sx={{ ...GoblinStyles.sessionTitleText, mb: 2 }} >TOP 100 Hash Power</Typography>
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
                                                width: "100%"
                                            }}
                                            initial="hidden"
                                            animate="visible"
                                            variants={list}>
                                                {
                                                    miningContext.rankingTop100.map((value, index) => (      
                                                        <motion.li variants={items} key={index} style={{ width: "100%" }}>
                                                            <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox, p: 1, mb: 1 }} >
                                                                <Stack direction={isMobile ? "column" : "row"} sx={{ ...MainStyles.container, flexWrap: "wrap" }}>
                                                                        {
                                                                            !isMobile &&
                                                                            <Box sx={{ ...MainStyles.container, width: 250, justifyContent: "flex-start" }}>
                                                                                <Stack sx={{ ...MainStyles.container }} direction="row" spacing={2}>
                                                                                    <Typography sx={{ ...GoblinStyles.textMain }} >{index + 1} ª  </Typography>
                                                                                    <Typography sx={{ ...statsText }} >{value.name}</Typography>
                                                                                </Stack>
                                                                            </Box>
                                                                        }
                                                                        {
                                                                            isMobile &&
                                                                            <Stack sx={{ ...MainStyles.container, mr: isMobile ? 0 : 3 }} direction="row" spacing={2}>
                                                                                <Typography sx={{ ...GoblinStyles.textMain }} >{index + 1} ª  </Typography>
                                                                                <Typography sx={{ ...statsText }} >{value.name}</Typography>
                                                                            </Stack>
                                                                        }
                                                                        {
                                                                            !isMobile && 
                                                                            <Divider orientation={"vertical"} variant={"middle"} sx={{ height: 36, mr: 3 }} />
                                                                        }
                                                                        <Stack sx={{ ...MainStyles.container, flexWrap: "wrap" }} direction="row" spacing={2}>
                                                                            <Stack direction={"row"} spacing={1} sx={{ justifyContent: "flex-start", alignItems: "center" }} >
                                                                                <img draggable="false"  src={HashPowerIcon} style={{ height: 32 }} alt={"Goblins"} />
                                                                                <Stack sx={{ ...MainStyles.container }} spacing={0} >
                                                                                    <Typography sx={{ ...statsText }} flexWrap={"wrap"} >{value.hashpower}</Typography>
                                                                                    <Typography sx={{ ...subInfoStyle, mt: -1 }} flexWrap={"wrap"} >Hash Power</Typography>
                                                                                </Stack>
                                                                            </Stack>
                                                                            <Stack direction={"row"} spacing={1} sx={{ justifyContent: "flex-start", alignItems: "center" }} >
                                                                                <img draggable="false"  src={HordeIcon} style={{ height: 54 }} alt={"Goblins"} />
                                                                                <Stack sx={{ ...MainStyles.container }} spacing={0} >
                                                                                    <Typography sx={{ ...statsText }} flexWrap={"wrap"} >{value.goblinqtde}</Typography>
                                                                                    <Typography sx={{ ...subInfoStyle, mt: -1 }} flexWrap={"wrap"} >Goblins</Typography>
                                                                                </Stack>
                                                                            </Stack>
                                                                    </Stack>
                                                                </Stack>
                                                            </Paper>
                                                        </motion.li>
                                                    ))   
                                                }
                                        </motion.ul>
                                    </Stack>
                                </Paper>
                            </Stack>
                            : <CircularProgress /> 
                        }
                        </Fade>
                        <Fade in={value == 1}>
                        {
                            miningContext.rankingWeekly && value == 1 ?
                            <Stack direction="row" sx={{ ...MainStyles.container, position: "absolute", top: 0, width: maxWidth, flexWrap: "wrap" }}>
                                <Paper sx={{ ...MainStyles.container, p: 2, width: maxWidth, bgcolor: GoblinWarsColors.darkBox }} elevation={6}>
                                    <Stack sx={{ ...MainStyles.container, width: 1 }} spacing={1}>
                                        <Typography sx={{ ...GoblinStyles.sessionTitleText }} >WEEKLY TOP 6</Typography>
                                        <MyTimer title={"Next Reward in"} expiryTimestamp={new Date(moment(miningContext.rankingWeeklyDate).valueOf())}  />
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
                                                width: "100%"
                                            }}
                                            initial="hidden"
                                            animate="visible"
                                            variants={list}>
                                                {
                                                    miningContext.rankingWeekly.map((value, index) => (      
                                                        <motion.li variants={items} key={index} style={{ width: "100%" }}>
                                                            <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox, p: 1, mb: 1 }} >
                                                                <Stack direction={isMobile ? "column" : "row"} sx={{ ...MainStyles.container, flexWrap: "wrap" }}>
                                                                        {
                                                                            !isMobile &&
                                                                            <Box sx={{ ...MainStyles.container, width: 300, justifyContent: "flex-start" }}>
                                                                                <Stack sx={{ ...MainStyles.container }} direction="row" spacing={2}>
                                                                                    <Typography sx={{ ...GoblinStyles.textMain }} >{value.ranking} ª  </Typography>
                                                                                    <Typography sx={{ ...statsText }} >{value.name}</Typography>
                                                                                </Stack>
                                                                            </Box>
                                                                        }
                                                                        {
                                                                            isMobile &&
                                                                            <Stack sx={{ ...MainStyles.container, mr: isMobile ? 0 : 3 }} direction="row" spacing={2}>
                                                                                <Typography sx={{ ...GoblinStyles.textMain }} >{value.ranking} ª  </Typography>
                                                                                <Typography sx={{ ...statsText }} >{value.name}</Typography>
                                                                            </Stack>
                                                                        }
                                                                        {
                                                                            !isMobile && 
                                                                            <Divider orientation={"vertical"} variant={"middle"} sx={{ height: 36, mr: 3 }} />
                                                                        }
                                                                        <Stack sx={{ ...MainStyles.container, flexWrap: "wrap" }} direction="row" spacing={2}>
                                                                            <Box sx={{ ...MainStyles.container, width: 210, justifyContent: "flex-start" }}>
                                                                                <Stack direction={"row"} spacing={1} sx={{ justifyContent: "flex-start", alignItems: "center" }} >
                                                                                    <img draggable="false"  src={HashPowerIcon} style={{ height: 32 }} alt={"Goblins"} />
                                                                                    <Stack sx={{ ...MainStyles.container }} spacing={0} >
                                                                                        <Typography sx={{ ...statsText }} flexWrap={"wrap"} >{(value.hashforweek/1000000).toFixed(2)}</Typography>
                                                                                        <Typography sx={{ ...subInfoStyle, mt: -1 }} flexWrap={"wrap"} >M/Hash</Typography>
                                                                                    </Stack>
                                                                                </Stack>
                                                                            </Box>
                                                                            <Divider orientation={"vertical"} variant={"middle"} sx={{ height: 36, mr: 3 }} />
                                                                            <Stack direction={"row"} spacing={1} sx={{ justifyContent: "flex-start", alignItems: "center" }} >
                                                                                {getWeeklyReward(value.ranking)}
                                                                            </Stack>
                                                                    </Stack>
                                                                </Stack>
                                                            </Paper>
                                                        </motion.li>
                                                    ))   
                                                }
                                        </motion.ul>
                                    </Stack>
                                </Paper>
                            </Stack>
                            : <CircularProgress /> 
                        }
                        </Fade>
                        <Fade in={value == 2}>
                        {
                            miningContext.rankingMonthly && value == 2 ?
                            <Stack direction="row" sx={{ ...MainStyles.container, position: "absolute", top: 0, width: maxWidth, flexWrap: "wrap" }}>
                                <Paper sx={{ ...MainStyles.container, p: 2, width: maxWidth, bgcolor: GoblinWarsColors.darkBox }} elevation={6}>
                                    <Stack sx={{ ...MainStyles.container, width: 1 }} spacing={1}>
                                        <Typography sx={{ ...GoblinStyles.sessionTitleText }} >MONTHLY TOP 10</Typography>
                                        <MyTimer title={"Next Reward in"} expiryTimestamp={new Date(moment(miningContext.rankingMonthlyDate).valueOf())}  />
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
                                                width: "100%"
                                            }}
                                            initial="hidden"
                                            animate="visible"
                                            variants={list}>
                                                {
                                                    miningContext.rankingMonthly.map((value, index) => (      
                                                        <motion.li variants={items} key={index} style={{ width: "100%" }}>
                                                            <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox, p: 1, mb: 1 }} >
                                                                <Stack direction={isMobile ? "column" : "row"} sx={{ ...MainStyles.container, flexWrap: "wrap" }}>
                                                                        {
                                                                            !isMobile &&
                                                                            <Box sx={{ ...MainStyles.container, width: 300, justifyContent: "flex-start" }}>
                                                                                <Stack sx={{ ...MainStyles.container }} direction="row" spacing={2}>
                                                                                    <Typography sx={{ ...GoblinStyles.textMain }} >{value.ranking} ª  </Typography>
                                                                                    <Typography sx={{ ...statsText }} >{value.name}</Typography>
                                                                                </Stack>
                                                                            </Box>
                                                                        }
                                                                        {
                                                                            isMobile &&
                                                                            <Stack sx={{ ...MainStyles.container, mr: isMobile ? 0 : 3 }} direction="row" spacing={2}>
                                                                                <Typography sx={{ ...GoblinStyles.textMain }} >{value.ranking} ª  </Typography>
                                                                                <Typography sx={{ ...statsText }} >{value.name}</Typography>
                                                                            </Stack>
                                                                        }
                                                                        {
                                                                            !isMobile && 
                                                                            <Divider orientation={"vertical"} variant={"middle"} sx={{ height: 36, mr: 3 }} />
                                                                        }
                                                                        <Stack sx={{ ...MainStyles.container, flexWrap: "wrap" }} direction="row" spacing={2}>
                                                                            <Box sx={{ ...MainStyles.container, width: 210, justifyContent: "flex-start" }}>
                                                                                <Stack direction={"row"} spacing={1} sx={{ justifyContent: "flex-start", alignItems: "center" }} >
                                                                                    <img draggable="false"  src={HashPowerIcon} style={{ height: 32 }} alt={"Goblins"} />
                                                                                    <Stack sx={{ ...MainStyles.container }} spacing={0} >
                                                                                        <Typography sx={{ ...statsText }} flexWrap={"wrap"} >{(value.hashformonth/1000000).toFixed(2)}</Typography>
                                                                                        <Typography sx={{ ...subInfoStyle, mt: -1 }} flexWrap={"wrap"} >M/Hash</Typography>
                                                                                    </Stack>
                                                                                </Stack>
                                                                            </Box>
                                                                            <Divider orientation={"vertical"} variant={"middle"} sx={{ height: 36, mr: 3 }} />
                                                                            <Stack direction={"row"} spacing={1} sx={{ justifyContent: "flex-start", alignItems: "center" }} >
                                                                                {getMonthlyReward(value.ranking)}
                                                                            </Stack>
                                                                    </Stack>
                                                                </Stack>
                                                            </Paper>
                                                        </motion.li>
                                                    ))   
                                                }
                                        </motion.ul>
                                    </Stack>
                                </Paper>
                            </Stack>
                            : <CircularProgress /> 
                        }
                        </Fade>
                        <Fade in={value == 3}>
                        {
                            miningContext.historyOfUser && value == 3 ?
                            <Stack direction="row" sx={{ ...MainStyles.container, position: "absolute", top: 0, width: maxWidth, flexWrap: "wrap" }}>
                                <Paper sx={{ ...MainStyles.container, p: 2, width: maxWidth, bgcolor: GoblinWarsColors.darkBox }} elevation={6}>
                                    <Stack sx={{ ...MainStyles.container, width: 1 }}>
                                        <Typography sx={{ ...GoblinStyles.sessionTitleText, mb: 2 }} >Claim Rewards</Typography>
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
                                                width: "100%"
                                            }}
                                            initial="hidden"
                                            animate="visible"
                                            variants={list}>
                                                {
                                                    miningContext.historyOfUser.map((value, index) => ( 
                                                        <motion.li variants={items} key={index} style={{ width: "100%" }}>
                                                            <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox, p: 1, mb: 1 }} >
                                                                <Stack direction={isMobile ? "column" : "row"} sx={{ ...MainStyles.container, flexWrap: "wrap" }}>
                                                                        {
                                                                            !isMobile &&
                                                                            <Box sx={{ ...MainStyles.container, width: 330, justifyContent: "flex-start" }}>
                                                                                <Typography sx={{ ...GoblinStyles.textMain }} >{value.rewardtype == "M" ? "Monthly reward in " : "Weekly reward in "}{value.rewarddatestr} (GMT)</Typography>
                                                                            </Box>
                                                                        }
                                                                        {
                                                                            isMobile &&
                                                                            <Typography sx={{ ...GoblinStyles.textMain }} >{value.rewardtype == "M" ? "Monthly reward in " : "Weekly reward in "}{value.rewarddatestr} (GMT)</Typography>
                                                                        }
                                                                        {
                                                                            !isMobile && 
                                                                            <Divider orientation={"vertical"} variant={"middle"} sx={{ height: 36, mr: 3 }} />
                                                                        }
                                                                        <Stack sx={{ ...MainStyles.container, flexWrap: "wrap" }} direction="row" spacing={2}>
                                                                            <Stack direction={"row"} spacing={1} sx={{ justifyContent: "flex-start", alignItems: "center" }} >
                                                                                {getBoxType(value.boxtype)}
                                                                            </Stack>
                                                                            <Divider orientation={"vertical"} variant={"middle"} sx={{ height: 36, mr: 3 }} />
                                                                            <Button sx={{ ...MainStyles.mainButton, width:"auto" }} disabled={value.claimed} onClick={ async () => {
                                                                                let ret = await miningContext.claimRankingReward(value.id);
                                                                                if (!ret.sucesso) {
                                                                                    alert(ret.mensagemErro);
                                                                                    return;
                                                                                }
                                                                                goblinUserContext.loadBalance();
                                                                                showDialog("Successfully claimed!", "success");
                                                                                await miningContext.listHistoryByUser();
                                                                            }}>
                                                                                <Typography sx={{ ...GoblinStyles.textMain }} >{
                                                                                        miningContext.loading.claim ? "Claiming..." : "Claim"
                                                                                }</Typography>
                                                                            </Button>
                                                                    </Stack>
                                                                </Stack>
                                                            </Paper>
                                                        </motion.li>
                                                    ))   
                                                }
                                        </motion.ul>
                                    </Stack>
                                </Paper>
                            </Stack>
                            : <CircularProgress /> 
                        }
                        </Fade>
                    </Box>
                    { /*
                        miningContext.loading.list &&
                        <Backdrop
                            sx={{ color: '#fff', zIndex: (theme) => 99 }}
                            open={true}
                        >
                            <CircularProgress color="inherit" />
                        </Backdrop>
                        */
                    }
                </Stack>
            </Box>
            <Snackbar open={openDialog} autoHideDuration={6000} onClose={handleClose} anchorOrigin={{ vertical: "top", horizontal: "right"}}>
                <Alert onClose={handleClose} severity={severity} sx={{ width: '100%' }}>
                    {message}
                </Alert>
            </Snackbar>
        </GwViewPort>
    )
}