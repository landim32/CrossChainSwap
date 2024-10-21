import { Backdrop, CircularProgress, Grid, Paper, Stack, Theme, Typography, styled, Tabs, Tab, Box, Fade } from "@mui/material";
import { motion } from "framer-motion";
import { useContext, useEffect, useState } from "react";
import { useHistory } from "react-router-dom";
import { Header } from "../../components/Header";
import { QuestCard } from "../../components/QuestCard";
import QuestContext from "../../contexts/quest/QuestContext";
import { FontButton } from "../../utils/fontStyle";
import { MainStyles } from "../../utils/style";
import { SxProps } from '@mui/system';
import { GwViewPort } from "../../components/GwViewPort";
import { DevPages } from "../../components/DevPage";
import { QuestPeriod } from "../../dto/enum/QuestPeriod";
import { GoblinWarsColors } from "../../dto/styles/GoblinWarsColors";

const list = {
    visible: {
        opacity: 1,
        transition: {
            when: "beforeChildren",
            staggerChildren: 0.15,
            delayChildren: 0.30,
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
                            Quests
                        </p>
                        <p>
                        You don't any quests. Every day new quests will come to you.
                        </p>
                    </div>
                </Typography>
            </Paper>
        </Grid>
    );
}

export function Quests() {
    const questContext = useContext(QuestContext);
    const history = useHistory();

    useEffect(() => {
        questContext.list();
    }, []);

    const [value, setValue] = useState(0);
    const handleChange = (event : any, newValue : number) => {
        setValue(newValue);
    };

    return (
        <GwViewPort>
            <Box sx={{ ...MainStyles.container, mb: 4, width: 1 }}>
                <Stack>
                    <StyledTabs value={value} onChange={handleChange} centered  >
                        <StyledTab label="Daily" />
                        <StyledTab label="Weekly" />
                        <StyledTab label="Jorney" />
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
                                    <Grid item xs={12} sx={{ margin: "10vh 0 5vh 0;" }}>
                                        <Grid container justifyContent="center" spacing={3}>
                                        {!questContext.loading.list ?
                                            questContext.quests.length > 0 ?
                                                questContext.quests.filter(x => x.quest.period == QuestPeriod.Daily)?.map((value) => (
                                                    <Grid key={value.id} item>
                                                        <motion.li variants={items}>
                                                            <QuestCard
                                                                userQuestInfo={value}
                                                                detail={(userQuestInfo) => {
                                                                    history.push("/questdetail?questId=" + userQuestInfo.id + "&questKey=" + userQuestInfo.questkey);
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
                                        {!questContext.loading.list ?
                                            questContext.quests.length > 0 ?
                                                questContext.quests.filter(x => x.quest.period == QuestPeriod.Weekly)?.map((value) => (
                                                    <Grid key={value.id} item>
                                                        <motion.li variants={items}>
                                                            <QuestCard
                                                                userQuestInfo={value}
                                                                detail={(userQuestInfo) => {
                                                                    history.push("/questdetail?questId=" + userQuestInfo.id + "&questKey=" + userQuestInfo.questkey);
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
                        <Fade in={value == 2}>
                        {
                            value == 2 ?
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
                                            <Grid xs={12} item key={"msgEmpty"}>
                                                <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox, p: 1 }}>
                                                    <Typography sx={{ ...msgEmptyTitle }} >
                                                        <div>
                                                            <p>
                                                            You don't any Jorney. Journeys are non-repeatable quest sequences with much greater rewards.
                                                            </p>
                                                        </div>
                                                    </Typography>
                                                </Paper>
                                            </Grid>
                                        </Grid>
                                    </Grid>
                                </motion.ul>
                            : <Box></Box>
                        }
                        </Fade>
                    </Box>
                </Stack>
            </Box>
            
        </GwViewPort>
    )
}