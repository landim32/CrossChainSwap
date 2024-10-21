import { Alert, AlertColor, Backdrop, Box, Button, CircularProgress, Divider, Grid, IconButton, Paper, Snackbar, Stack, SwipeableDrawer, Theme, Toolbar, Typography } from "@mui/material";
import { GwViewPort } from "../../components/GwViewPort";
import MiningContext from "../../contexts/mining/MiningContext";
import { GoblinStyles, MainStyles } from "../../utils/style";
import { useContext, useEffect, useState } from "react";
import { isMobile } from 'react-device-detect';
import { GoblinWarsColors } from "../../dto/styles/GoblinWarsColors";
import { motion } from "framer-motion";
import { FontButton } from "../../utils/fontStyle";
import { SxProps } from "@mui/system";
import gobiCoin from '../../assets/images/coins/gobiCoin.png';
import gobiCoinBlue from '../../assets/images/coins/gobiCoinBlue.png';
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

export function MiningReward() {
    const miningContext = useContext(MiningContext);
    const goblinUserContext = useContext(GoblinUserContext);
    const maxWidth = isMobile ? 350 : 700;

    const [openDialog, setOpenDialog] = useState(false);
    const [message, setMessage] = useState("");
    const [severity, setSeverity] = useState<AlertColor>("success");

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

    useEffect(() => {
        miningContext.listReward();
    }, [])

    return (
        <GwViewPort>
            <Stack sx={{ ...MainStyles.container, pl: 1.5, pr: 1.5, mb: 4, width: 1 }} >
                {
                    miningContext.rewards && 
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
                                        miningContext.rewards.map((value, index) => ( 
                                            <motion.li variants={items} key={index} style={{ width: "100%" }}>
                                                <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox, p: 1, mb: 1 }} >
                                                    <Stack direction={isMobile ? "column" : "row"} sx={{ ...MainStyles.container, flexWrap: "wrap" }}>
                                                            {
                                                                !isMobile &&
                                                                <Box sx={{ ...MainStyles.container, width: 250, justifyContent: "flex-start" }}>
                                                                    <Typography sx={{ ...GoblinStyles.textMain }} >{value.insertdatestr} (GMT)</Typography>
                                                                </Box>
                                                            }
                                                            {
                                                                isMobile &&
                                                                <Typography sx={{ ...GoblinStyles.textMain }} >{value.insertdatestr} (GMT)</Typography>
                                                            }
                                                            {
                                                                !isMobile && 
                                                                <Divider orientation={"vertical"} variant={"middle"} sx={{ height: 36, mr: 3 }} />
                                                            }
                                                            <Stack sx={{ ...MainStyles.container, flexWrap: "wrap" }} direction="row" spacing={2}>
                                                                <Stack direction={"row"} spacing={1} sx={{ justifyContent: "flex-start", alignItems: "center" }} >
                                                                    <img draggable="false"  src={gobiCoinBlue} style={{ height: 32 }} alt={"GOBI"} />
                                                                    <Stack sx={{ ...MainStyles.container }} spacing={0} >
                                                                        <Typography sx={{ ...statsText }} flexWrap={"wrap"} >{value.gobivalue.toFixed(4)}</Typography>
                                                                        <Typography sx={{ ...subInfoStyle, mt: -1 }} flexWrap={"wrap"} >GOBI</Typography>
                                                                    </Stack>
                                                                </Stack>
                                                                <Button sx={{ ...MainStyles.mainButton, width:"auto" }} onClick={ async () => {
                                                                    let ret = await miningContext.claimReward(value.id);
                                                                    if (!ret.sucesso) {
                                                                        alert(ret.mensagemErro);
                                                                        return;
                                                                    }
                                                                    goblinUserContext.loadBalance();
                                                                    showDialog("Successfully claimed!", "success");
                                                                    await miningContext.listReward();
                                                                }}>
                                                                    <Stack sx={{ ...MainStyles.container, ml: 1, mr: 1 }} direction={"row"} spacing={1}>
                                                                        <img draggable="false"  src={gobiCoin} style={{ height: 32 }} />
                                                                        <Typography sx={{ ...GoblinStyles.textMain }} >{
                                                                            miningContext.loading.claim ?
                                                                                "Claiming..." :
                                                                                "Claim (" + (value.percentfee > 0 ? " " + value.percentfee + "% fee " : " no fee ") + ")"
                                                                        }</Typography>
                                                                    </Stack>
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
                }
                { miningContext.loading.listReward &&
                    <Backdrop
                        sx={{ color: '#fff', zIndex: (theme) => 99 }}
                        open={true}
                    >
                        <CircularProgress color="inherit" />
                    </Backdrop>
                }
            </Stack>
            <Snackbar open={openDialog} autoHideDuration={6000} onClose={handleClose} anchorOrigin={{ vertical: "top", horizontal: "right"}}>
                <Alert onClose={handleClose} severity={severity} sx={{ width: '100%' }}>
                    {message}
                </Alert>
            </Snackbar>
        </GwViewPort>
    )
}