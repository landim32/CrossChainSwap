import { Alert, AlertColor, Backdrop, Box, Button, CircularProgress, Dialog, Divider, Grid, IconButton, Paper, Popover, Snackbar, Stack, SwipeableDrawer, Theme, Toolbar, Typography } from "@mui/material";
import { GwViewPort } from "../../components/GwViewPort";
import MiningContext from "../../contexts/mining/MiningContext";
import { GoblinStyles, MainStyles } from "../../utils/style";
import { useContext, useEffect, useState } from "react";
import gobiCoin from '../../assets/images/coins/gobiCoin.png';
import gobiCoinBlue from '../../assets/images/coins/gobiCoinBlue.png';
import HashPowerIcon from '../../assets/images/mining/hashPower.png';
import { GenericSlot } from "../../components/GenericSlot";
import { isMobile } from 'react-device-detect';
import { GoblinWarsColors } from "../../dto/styles/GoblinWarsColors";
import { motion } from "framer-motion";
import InfiniteScroll from "react-infinite-scroll-component";
import SizeGoblinCard from "../../dto/enum/SizeGoblinCard";
import { Goblin } from "../../components/Goblin";
import { FontButton } from "../../utils/fontStyle";
import { SxProps } from "@mui/system";
import { makeStyles } from "@mui/styles";
import HideIcon from '../../assets/images/menu/show.png';
import MiningCanvas from "../../components/MiningCanvas";
import MinersRankIcon from '../../assets/images/menu/rank.png';
import { useHistory } from "react-router-dom";
import { GoblinMiningCard } from "../../components/GoblinMiningCard";
import GoblinUserContext from "../../contexts/goblinUser/GoblinUserContext";
import { MinerPosInfo } from "../../dto/domain/MinerPosInfo";
import { GoblinInfo } from "../../dto/domain/GoblinInfo";
import { TransactionGobi } from "../../components/TransactionGobi";
import useInterval from '@use-it/interval';


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

const msgEmptyTitle : SxProps<Theme> = {
    ...FontButton,
    fontSize: 22
}

const titleSectionStyle : SxProps<Theme> = {
    ...GoblinStyles.sessionTitleText,
    fontSize: 30
}

const infoStyle : SxProps<Theme> = {
    ...GoblinStyles.infoTextMain,
    fontSize: 20
}

const subInfoStyle : SxProps<Theme> = {
    ...GoblinStyles.sessionSubTitleText,
    fontSize: 14,
}

const statsText : SxProps<Theme> = {
    ...FontButton,
    fontSize: 23
}
const geneIconSize = 44;

const getLoadingBlock = () => {
    return (
        <Box sx={{ width: 1 }}>
        <Stack direction={"row"} sx={{ ...MainStyles.container, pb: 4, pt: 1 }} spacing={1}>
            <CircularProgress />
            <Typography variant={"subtitle1"} color="white" >Loading...</Typography>
        </Stack>
        </Box>
    );
}

interface AnchorElInterface {
    anchorEl: any;
    selectGoblin: MinerPosInfo;
}

const msgEmpty = () => {
    return (
        <Box sx={{ ...MainStyles.container, width: isMobile ? 350 : 500, mb: 2 }}>
            <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox, p: 1 }}>
                <Stack sx={{ ...MainStyles.container }}>
                    <Typography sx={{ ...msgEmptyTitle }} >
                            <p>
                                You don't any goblin for mining.
                            </p>
                    </Typography>
                </Stack>
            </Paper>
        </Box>
    );
}

const useStyles = makeStyles({
    paper: {
        background: "linear-gradient(180deg, rgba(99,145,83,1) 0%, rgba(43,52,33,1) 100%)"
    }
})

export function Mining() {
    const miningContext = useContext(MiningContext);
    const goblinUserContext = useContext(GoblinUserContext);
    const [openDrawer, setOpenDrawer] = useState(false);
    const [openDrawerMining, setOpenDrawerMining] = useState(false);
    const [loadMore, setLoadMore] = useState(true);
    const history = useHistory();
    const [openDialog, setOpenDialog] = useState(false);
    const [message, setMessage] = useState("");
    const [severity, setSeverity] = useState<AlertColor>("success");
    const [refreshInfo, setRefreshInfo] = useState(0);
    const [anchorEl, setAnchorEl] = useState<AnchorElInterface>(null);
    const [transactionGobi, setTransactionGobi] = useState(false);

    const handleClick = (event: any, selectGoblin: MinerPosInfo) => {
        setAnchorEl({anchorEl: event, selectGoblin: selectGoblin});
    };

    const handleClosePopOver = () => {
        setAnchorEl(null);
    };

    const open = Boolean(anchorEl);
    const id = open ? 'simple-popover' : undefined;

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

    const classes = useStyles();

    const handleOpenDrawer = () => {
        setOpenDrawer(true);
    }

    const handleCloseDrawer = () => {
        setOpenDrawer(false);
    }

    const handleOpenMiningDrawer = () => {
        setOpenDrawerMining(true);
    }

    const handleCloseMiningDrawer = () => {
        setOpenDrawerMining(false);
    }
    const openTransaction = () => {
        setTransactionGobi(true);
    };

    const closeTransaction = () => {
        setTransactionGobi(false);
    };

    useEffect(() => {
        miningContext.info(false);
        miningContext.listGoblinsCanMining(true);
    }, [])

    useInterval(() => {
        miningContext.info(true).then(() => {
            setRefreshInfo(refreshInfo+1);
        });
    }, 60000)

    const buildSelectGoblinDrawer = () => {
        return (
            <SwipeableDrawer
                anchor={"right"}
                open={openDrawer}
                onClose={handleCloseDrawer} 
                onOpen={handleOpenDrawer} 
                classes={{ paper: classes.paper }} 
            >
                
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
                    <Stack sx={{ ...MainStyles.container, width: isMobile ? 250 : 800, height: 1, pb: 4 }} >
                        <Toolbar sx={{ bgcolor: "#232a1b", display: "flex", alignContent: "center", justifyContent: "flex-start", width: 1 }} >
                            <Stack sx={{ ...MainStyles.container }} direction={"row"} >
                                <IconButton onClick={handleCloseDrawer}>
                                    <img draggable="false"  src={HideIcon} style={{ height: 32 }} alt={"hide"} />
                                </IconButton>
                                <Typography sx={{ ...GoblinStyles.sessionTitleText }} >hide</Typography>
                            </Stack>
                        </Toolbar>
                        <Divider />
                        <Stack sx={{ ...MainStyles.container, width: 1 }} >
                            <InfiniteScroll
                                style={{ display: "flex", flexWrap: "wrap", alignItems: "center", alignContent: "center", justifyContent: "center", overflowX: "hidden" }}
                                dataLength={miningContext.goblinsCanMining.length}
                                next={async () => {
                                    var ret = await miningContext.listGoblinsCanMining(false);
                                    if(ret)
                                        setLoadMore(ret.sucesso);
                                }}
                                hasMore={loadMore}
                                loader={<Box></Box>}
                                endMessage={
                                    miningContext.goblinsCanMining.length > 0 ? 
                                    <Box sx={{ width: 1 }}>
                                        <Stack direction={"row"} sx={{ ...MainStyles.container, pb: 4, pt: 1 }} spacing={1}>
                                        <Typography variant={"subtitle1"} color="white" >No more goblins for fetch !</Typography>
                                        </Stack>
                                    </Box>
                                    : msgEmpty()
                                }
                            >
                                {
                                miningContext.goblinsCanMining && miningContext.goblinsCanMining.length > 0 && miningContext.goblinsCanMining.map((value) => (
                                    
                                    <motion.li variants={items} key={value.id}>
                                        <Box sx={{ ...MainStyles.container, m: isMobile ? 1 : 1 }} key={value.id} >
                                            <Goblin
                                                id={value.id}
                                                idToken={value.idToken}
                                                name={value.name}
                                                image={value.imageURL}
                                                size={isMobile ? SizeGoblinCard.VerySmall : SizeGoblinCard.Small}
                                                mainColor={value.skincolor}
                                                inCooldown={value.inCooldown}
                                                cooldownDate={value.cooldownDate}
                                                goblinSkillList={value.goblinSkillList}
                                                rarity={value.rarityenum}
                                                onElemClick={async (tokenId:number) => {
                                                    handleCloseDrawer();
                                                    var ret = await miningContext.startMining(miningContext.goblinsCanMining.find(x => x.idToken == tokenId));
                                                    if(ret.sucesso) {
                                                        showDialog("Your goblin has started mining", "success");
                                                        miningContext.info(false);
                                                        miningContext.listGoblinsCanMining(true);
                                                    } else {
                                                        showDialog("Failed to add goblin in mining", "error");
                                                    }
                                                }}
                                            />
                                        </Box>
                                    </motion.li>
                                ))
                            }
                            </InfiniteScroll>
                            {
                                loadMore && !miningContext.loading.listGoblinsCanMining && 
                                <Button onClick={async () => {
                                    var ret = await miningContext.listGoblinsCanMining(false);
                                    if(ret)
                                        setLoadMore(ret.sucesso);
                                }} sx={{ ...MainStyles.mainButton, width: 150 }}>Load more</Button>
                            }
                            {
                                miningContext.loading.listGoblinsCanMining && getLoadingBlock()
                            }
                        </Stack>
                    </Stack>
                </motion.ul>
            </SwipeableDrawer>
        )
    }

    const buildMiningGoblinDrawer = () => {
        return (
            <SwipeableDrawer
                anchor={"right"}
                open={openDrawerMining}
                onClose={handleCloseMiningDrawer} 
                onOpen={handleOpenMiningDrawer} 
                classes={{ paper: classes.paper }} 
            >
                
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
                    <Stack sx={{ ...MainStyles.container, width: 350, height: 1, pb: 4 }} >
                        <Toolbar sx={{ bgcolor: "#232a1b", display: "flex", alignContent: "center", justifyContent: "flex-start", width: 1 }} >
                            <Stack sx={{ ...MainStyles.container }} direction={"row"} >
                                <IconButton onClick={handleCloseMiningDrawer}>
                                    <img draggable="false"  src={HideIcon} style={{ height: 32 }} alt={"hide"} />
                                </IconButton>
                                <Typography sx={{ ...GoblinStyles.sessionTitleText }} >hide</Typography>
                            </Stack>
                        </Toolbar>
                        <Divider />
                        <Stack sx={{ ...MainStyles.container, width: 1, flexWrap: "wrap" }} direction={"row"} >
                            {
                                !miningContext.loading.info && miningContext.myMining && miningContext.myMining.goblins.length > 0 ? 
                                miningContext.myMining.goblins.map((value) => (
                                    <motion.li variants={items} key={value.id}>
                                        <Box sx={{ ...MainStyles.container, m: 1 }} key={value.id} >
                                            <GoblinMiningCard goblinMining={value} 
                                                rechargeCb={goblin => {
                                                    if(!miningContext.loading.recharge)
                                                        miningContext.rechargeGoblin(goblin.idToken).then((ret) => {
                                                            if(ret.sucesso) {
                                                                showDialog("Successfully recharged goblin", "success");
                                                                miningContext.info(false);
                                                            } else {
                                                                showDialog(ret.mensagemErro, "error");
                                                            }
                                                        });
                                                }} 
                                                walletBalance={goblinUserContext.balance?.cloudWalletGobiBalance} 
                                                loading={miningContext.loading.recharge} 
                                                titleSectionStyle={titleSectionStyle} infoText={infoStyle} 
                                                statsText={statsText} subInfoStyle={subInfoStyle} geneIconSize={geneIconSize}   
                                                isMobile={isMobile} 
                                                stopMining={(goblin: GoblinInfo) => {
                                                    if(!miningContext.loading.stop)
                                                        miningContext.stopMining(goblin).then((ret) => {
                                                            if (ret.sucesso) {
                                                                handleClosePopOver();
                                                                showDialog("Mining stopped", "success");
                                                                miningContext.info(false);
                                                                miningContext.listGoblinsCanMining(true);
                                                            } else {
                                                                showDialog(ret.mensagemErro, "error");
                                                            }
                                                        });
                                                } } loadingMining={miningContext.loading.stop}                                               
                                            />
                                        </Box>
                                    </motion.li>
                                ))
                                : getLoadingBlock()
                            }
                        </Stack>
                    </Stack>
                </motion.ul>
            </SwipeableDrawer>
        )
    }

    return (
        <GwViewPort>
            <Stack sx={{ ...MainStyles.container, pl: 1.5, pr: 1.5, mb: 4, width: 1 }} spacing={2}>
                
                <Box sx={{ ...MainStyles.container}} >
                    <Stack spacing={isMobile ? 0 : 2} direction={isMobile ? "column" : "row"} sx={{ ...MainStyles.container }}>
                        <Typography sx={{ ...GoblinStyles.sessionTitleText }} >Mining Pool</Typography>
                        
                        <Stack direction={"row"} spacing={2}>
                            <GenericSlot boxSize={60} >
                            {
                                <img draggable="false"  src={gobiCoin} style={{ height: 45 }} alt={"GOBI"} />
                            }
                            </GenericSlot>
                            {
                                miningContext.myMining ?
                                <Stack sx={{ ...MainStyles.container }}>
                                    <Typography sx={{ ...GoblinStyles.textMain }} >{miningContext.myMining.dailyreward}</Typography>
                                    <Typography sx={{ ...GoblinStyles.sessionSubTitleText }} >Daily Distribution</Typography>
                                </Stack>
                                : <CircularProgress />
                            }
                        </Stack>
                    </Stack>
                </Box>
                
                {
                    miningContext.myMining ?
                    <>
                        <Paper elevation={8} sx={{ p: 1, borderRadius: 6, bgcolor: GoblinWarsColors.darkBox, ...MainStyles.container, }} >
                            <Stack spacing={1} sx={{ ...MainStyles.container }} >
                                <MiningCanvas mining={miningContext.myMining} minerPos={miningContext.minerPos} isMobile={isMobile} listGoblins={handleOpenMiningDrawer}
                                    showCard={(goblinMining: MinerPosInfo, event: any) => {
                                        handleClick(event, goblinMining);
                                    } } 
                                    loadingRecharge={miningContext.loading.recharge} 
                                    rechargeAll={() => {
                                        if(!miningContext.loading.recharge)
                                            openTransaction();
                                    } } />
                            </Stack>
                        </Paper>
                        {
                            /*
                            miningContext.myMining.hashpower > miningContext.myMining.minhashpower && 
                            <Box sx={{ width: isMobile ? 350 : 650 }}>
                                <Typography sx={{ ...GoblinStyles.textMain, textAlign: "center" }} >You are on the {miningContext.myMining.ranking}ª place in the global rank</Typography>
                            </Box>
                            */
                        }
                        <Grid container sx={{ ...MainStyles.container, width: 1 }}>
                            <Grid item sx={{ m: 1 }}>
                                <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox, width: "315px", ml: 1 }}>
                                    <Stack sx={{ ...MainStyles.container, width: 1 }}>
                                        <Typography sx={{ ...GoblinStyles.sessionSubTitleText }} >GOBI estimative per month ≈ {
                                        miningContext.myMining.rewardpermonth.toPrecision(7)
                                        }</Typography>
                                        <Stack sx={{ ...MainStyles.container, width: 1 }} direction={"row"} spacing={1}>
                                            <Stack sx={{ ...MainStyles.container }}>
                                                <Typography sx={{ ...GoblinStyles.textMain }} >{miningContext.myMining.goblinqtde}</Typography>
                                                <Typography sx={{ ...GoblinStyles.sessionSubTitleText }} >Goblins Mining</Typography>
                                            </Stack>
                                            <Divider orientation={"vertical"} variant={"middle"} sx={{ height: 72 }} />
                                            <Box sx={{ position: "relative" }}>
                                                <Button sx={{ ...MainStyles.mainButton, width: 160 }} onClick={handleOpenDrawer}><img draggable="false"  src={HashPowerIcon} style={{ marginRight: "8px", height: 22 }} />Add Goblin</Button>
                                            </Box>
                                        </Stack>
                                    </Stack>
                                    
                                </Paper>
                            </Grid>
                            <Grid item sx={{ m: 1 }}>
                                <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox }} >
                                    <Stack spacing={1} sx={{ ...MainStyles.container }}>
                                        <Grid container sx={{ ...MainStyles.container }} >
                                            <Grid item xs={isMobile ? 12 : 0} sx={{ ...MainStyles.container, m: isMobile ? 0.5 : 1 }}>
                                                <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox, width: "180px", background: undefined, bgcolor: GoblinWarsColors.darkBox }}>
                                                    <Stack sx={{ ...MainStyles.container }}>
                                                        <Stack sx={{ ...MainStyles.container }} direction={"row"} spacing={1}>
                                                            <img draggable="false"  src={gobiCoinBlue} style={{ height: 26 }} />
                                                            <Typography sx={{ ...GoblinStyles.textMain }} >{miningContext.myRewardGobi.toPrecision(7)}</Typography>
                                                        </Stack>
                                                        <Typography sx={{ ...GoblinStyles.sessionSubTitleText }} >My Rewards</Typography>
                                                    </Stack>
                                                </Paper>
                                            </Grid>
                                            <Grid item sx={{ ...MainStyles.container, m: isMobile ? 0.5 : 1 }}>
                                                <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox, width: "170px", background: undefined, bgcolor: GoblinWarsColors.darkBox }}>
                                                    <Stack sx={{ ...MainStyles.container }}>
                                                        <Stack sx={{ ...MainStyles.container }} direction={"row"} spacing={1}>
                                                            <img draggable="false"  src={HashPowerIcon} style={{ height: 26 }} />
                                                            <Typography sx={{ ...GoblinStyles.textMain }} >{miningContext.myMining.hashpower}</Typography>
                                                        </Stack>
                                                        <Typography sx={{ ...GoblinStyles.sessionSubTitleText }} >My Hash Power</Typography>
                                                    </Stack>
                                                </Paper>
                                            </Grid>
                                            <Grid item sx={{ ...MainStyles.container, m: isMobile ? 0.5 : 1 }}>
                                                <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox, width: "170px", background: undefined, bgcolor: GoblinWarsColors.darkBox }}>
                                                    <Stack sx={{ ...MainStyles.container }}>
                                                        <Typography sx={{ ...GoblinStyles.textMain }} >{miningContext.myMining.totalhashpower}</Typography>
                                                        <Typography sx={{ ...GoblinStyles.sessionSubTitleText }} >Total Hash Power</Typography>
                                                    </Stack>
                                                </Paper>
                                            </Grid>
                                        </Grid>
                                        <Typography sx={{ ...GoblinStyles.sessionSubTitleText, textAlign: "center" }} >You need at least {miningContext.myMining.minhashpower} Hash Power for reward</Typography>
                                    </Stack>
                                </Paper>
                            </Grid>
                        </Grid>
                        <Stack direction={"row"} spacing={1}>
                            <Button sx={{ ...MainStyles.mainButton, width:"auto" }} onClick={() => {
                                history.push("/miningrank");
                            }}>
                                <Stack sx={{ ...MainStyles.container, ml: 1, mr: 1 }} direction={"row"} spacing={1}>
                                    <img draggable="false"  src={MinersRankIcon} style={{ height: 32 }} />
                                    <Typography sx={{ ...GoblinStyles.textMain }} >Miners Rank</Typography>
                                </Stack>
                            </Button>
                            <Button sx={{ ...MainStyles.mainButton, width:"auto" }} onClick={() => {
                                history.push("/miningclaim");
                            }}>
                                <Stack sx={{ ...MainStyles.container, ml: 1, mr: 1 }} direction={"row"} spacing={1}>
                                    <img draggable="false"  src={gobiCoinBlue} style={{ height: 32 }} />
                                    <Typography sx={{ ...GoblinStyles.textMain }} >Claim Reward</Typography>
                                </Stack>
                            </Button>
                        </Stack>
                    </>
                    : <CircularProgress />
                }
                
            </Stack>
            { buildSelectGoblinDrawer() }
            { buildMiningGoblinDrawer() }
            { (miningContext.myMining && (miningContext.loading.info || miningContext.loading.start || miningContext.loading.stop || miningContext.loading.recharge)) &&
                <Backdrop
                    sx={{ color: '#fff', zIndex: (theme) => 99 }}
                    open={true}
                >
                    <CircularProgress color="inherit" />
                </Backdrop>
            }
            <Dialog
                open={transactionGobi}
                keepMounted
                onClose={closeTransaction}
            >
                {
                !miningContext.loading.info && goblinUserContext.balance && miningContext.myMining && miningContext.myMining.goblins && miningContext.myMining.goblins.length > 0 &&
                <TransactionGobi close={closeTransaction} approve={() => { 
                    if(!miningContext.loading.recharge) {
                        if(miningContext.myMining.goblins.map(goblin => goblin.goblinMining.energycost).reduce((previousValue, currentValue) => previousValue + currentValue) < goblinUserContext.balance.cloudWalletGobiBalance){
                            miningContext.rechargeall().then((ret) => {
                                if(ret.sucesso) {
                                    showDialog("Successfully recharged", "success");
                                    miningContext.info(false);
                                } else {
                                    showDialog(ret.mensagemErro, "error");
                                }
                            });
                        } else {
                            showDialog("insufficient balance on Cloud Wallet", "error");
                        }
                    }
                 }} 
                    gobiCost={miningContext.myMining.goblins.map(goblin => goblin.goblinMining.energycost).reduce((previousValue, currentValue) => previousValue + currentValue)} 
                    text={"Are you sure you would like to make the energy recharge for all goblins (Value is estimated and may vary depending on mining entropy) ?"} />
                }
            </Dialog>
            <Snackbar open={openDialog} autoHideDuration={6000} onClose={handleClose} anchorOrigin={{ vertical: "top", horizontal: "right"}}>
                <Alert onClose={handleClose} severity={severity} sx={{ width: '100%' }}>
                    {message}
                </Alert>
            </Snackbar>
            <Popover
                id={id}
                open={open}
                anchorEl={anchorEl?.anchorEl}
                onClose={handleClosePopOver}
                anchorOrigin={{
                vertical: 'bottom',
                horizontal: 'left',
                }}
            >
                {
                    miningContext.myMining && miningContext.myMining.goblins && anchorEl?.selectGoblin && 
                    <GoblinMiningCard goblinMining={miningContext.myMining.goblins.find((item) => item.idToken == anchorEl.selectGoblin.idtoken)}
                    rechargeCb={goblin => {
                        if(!miningContext.loading.recharge)
                            miningContext.rechargeGoblin(goblin.idToken).then((ret) => {
                                if (ret.sucesso) {
                                    handleClosePopOver();
                                    showDialog("Successfully recharged goblin", "success");
                                    miningContext.info(false);
                                } else {
                                    showDialog(ret.mensagemErro, "error");
                                }
                            });
                    } }
                    walletBalance={goblinUserContext.balance?.cloudWalletGobiBalance}
                    loading={miningContext.loading.recharge}
                    titleSectionStyle={titleSectionStyle} infoText={infoStyle}
                    statsText={statsText} subInfoStyle={subInfoStyle} geneIconSize={geneIconSize}
                    isMobile={isMobile} stopMining={(goblin: GoblinInfo) => {
                        if(!miningContext.loading.stop)
                            miningContext.stopMining(goblin).then((ret) => {
                                if (ret.sucesso) {
                                    handleClosePopOver();
                                    showDialog("Mining stopped", "success");
                                    miningContext.info(false);
                                    miningContext.listGoblinsCanMining(true);
                                } else {
                                    showDialog(ret.mensagemErro, "error");
                                }
                            });
                    } } loadingMining={miningContext.loading.stop} />
                }
            </Popover>
        </GwViewPort>
    )
}