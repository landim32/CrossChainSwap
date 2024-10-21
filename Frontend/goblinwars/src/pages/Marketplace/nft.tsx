import { Alert, AlertColor, Box, Button, CircularProgress, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle, Divider, Fade, IconButton, MenuItem, Pagination, PaginationItem, Paper, Snackbar, Stack, SwipeableDrawer, SxProps, Tab, Tabs, TextField, Theme, Toolbar, Typography } from "@mui/material";
import { useContext, useEffect, useState } from "react";
import { motion } from "framer-motion";
import { Goblin } from "../../components/Goblin";
import { GwViewPort } from "../../components/GwViewPort";
import AuctionContext from "../../contexts/auction/AuctionContext";
import { MainStyles, GoblinStyles } from "../../utils/style";
import { useHistory, useLocation } from "react-router";
import SizeGoblinCard from '../../dto/enum/SizeGoblinCard';
import { makeStyles } from "@mui/styles";
import { GoblinWarsColors } from "../../dto/styles/GoblinWarsColors";
import { RarityStyles } from "../../utils/RarityStyles";
import { RarityEnum } from "../../dto/enum/RarityEnum";
import GoblinContext from "../../contexts/goblin/GoblinContext";
import { styled } from "@mui/system";
import GoblinNftContext from "../../contexts/goblinNft/GoblinNftContext";
import { GoblinInfo } from "../../dto/domain/GoblinInfo";
import GoblinUserContext from "../../contexts/goblinUser/GoblinUserContext";
import MarketingTabs from "../../components/MarketingTabs";
import MarketplaceIcon from '../../assets/images/menu/marketplace.png'
import { DefaultTabs, DefaultTab } from "../../components/GwTabs";
import { isMobile } from 'react-device-detect';

const ITEMS_PER_PAGE: number = 14;

export function GoblinNft() {
    //const classes = useStyles();

    let location = useLocation();
    const history = useHistory();
    const goblinContext = useContext(GoblinContext);
    const goblinUserContext = useContext(GoblinUserContext);
    const nftContext = useContext(GoblinNftContext);
    
    const reloadBalance = async () => {
        let ret = await goblinUserContext.loadBalance();
        if (!ret.sucesso) {
            showDialog(ret.mensagemErro, 'error');
        }
    };

    const [openDialog, setOpenDialog] = useState(false);
    const [message, setMessage] = useState("");
    const [severity, setSeverity] = useState<AlertColor>("success");

    const [value, setValue] = useState(0);

    const handleChange = (event : any, newValue : number) => {
        setValue(newValue);
    };

    const handleClose = (ev: any) => {
        if (ev?.reason === 'clickaway') {
            return;
        }
        setOpenDialog(false);
    };

    const getSelectColor = () => {
        switch(value) {
            case 0:
                return RarityStyles.getRarityColor(RarityEnum.Uncommon);
            case 1:
                return RarityStyles.getRarityColor(RarityEnum.Rare);
            case 2:
                return RarityStyles.getRarityColor(RarityEnum.Rare);
        }
    }

    const showDialog = (message: string, severity: AlertColor) => {
        setSeverity(severity);
        setMessage(message);
        setOpenDialog(true);
    }

    const reloadList = async (pg: number) => {
        let ret = await goblinContext.listByUser(pg, ITEMS_PER_PAGE);
        if (!ret.sucesso) {
            showDialog(ret.mensagemErro, 'error');
            return;
        }
        let retNft = await nftContext.list();
        if (!retNft.sucesso) {
            showDialog(retNft.mensagemErro, 'error');
            return;
        }
        reloadBalance();
    };

    const [goblinCurrent, setGoblinCurrent] = useState<GoblinInfo>(null);
    const [openAlertMint, setOpenAlertMint] = useState<boolean>(false);
    const [openAlertClaim, setOpenAlertClaim] = useState<boolean>(false);

    const showAlertMint = (goblin: GoblinInfo) => {
        setGoblinCurrent(goblin);
        setOpenAlertMint(true);
    };

    const closeAlertMint = () => {
        setOpenAlertMint(false);
    };

    const executeAlertMint = async () => {
        setOpenAlertMint(false);
        let ret = await nftContext.mint(goblinCurrent.idToken);
        if (ret.sucesso) {
            showDialog(ret.mensagemSucesso, 'success');
            reloadList(goblinContext.currentPage);
        }
        else {
            showDialog(ret.mensagemErro, 'error');
            return;
        }
    };

    const showAlertClaim = (goblin: GoblinInfo) => {
        setGoblinCurrent(goblin);
        setOpenAlertClaim(true);
    };

    const closeAlertClaim = () => {
        setOpenAlertClaim(false);
    };

    const executeAlertClaim = async () => {
        setOpenAlertClaim(false);
        let ret = await nftContext.claim(goblinCurrent.idToken);
        if (ret.sucesso) {
            showDialog(ret.mensagemSucesso, 'success');
            reloadList(goblinContext.currentPage);
        }
        else {
            showDialog(ret.mensagemErro, 'error');
            return;
        }
    };

    useEffect(() => {
        reloadList(1);
    }, [ location ]);

    return (
        <Stack sx={{ ...MainStyles.container }}>
            <Stack direction={"row"} sx={{ ...MainStyles.container }} spacing={1} >
                <img draggable="false"  src={MarketplaceIcon} style={{ height: 30 }} />
                <Typography sx={{ ...GoblinStyles.sessionTitleText }} >MARKETPLACE</Typography>
            </Stack>
            <Stack>
                <DefaultTabs value={value} onChange={handleChange} centered >
                    <DefaultTab label="Goblins in Game" />
                    <DefaultTab label="In my Wallet"  />
                </DefaultTabs>
                <Fade in={value == 0}>
                { !goblinContext.loading.list && value == 0 ?
                    <Stack direction="row" sx={{ ...MainStyles.container, flexWrap: "wrap" }}>
                        {
                            goblinContext.goblins?.map((goblin) => (
                                <Box sx={{ m: 2 }}>
                                    <Goblin
                                        id={goblin.id}
                                        idToken={goblin.idToken}
                                        name={goblin.name}
                                        image={goblin.imageURL}
                                        size={isMobile ? SizeGoblinCard.VerySmall : SizeGoblinCard.Small}
                                        mainColor={goblin.skincolor}
                                        inCooldown={goblin.inCooldown}
                                        cooldownDate={goblin.cooldownDate}
                                        goblinSkillList={goblin.goblinSkillList}
                                        rarity={goblin.rarityenum}
                                        showStatus={true}
                                        status={goblin.status}
                                        onElemClick={(tokenId:number) => {
                                            history.push("/goblin?tokenId=" + tokenId);
                                        }}
                                    />
                                    <Button sx={{ ...MainStyles.mainButton }} disabled={!goblin.isavaliable} onClick={ async (e: any) => {
                                        if (goblin.minted) {
                                            showAlertClaim(goblin);
                                        }
                                        else {
                                            showAlertMint(goblin);
                                        }
                                    }} >
                                        {nftContext.loadingAction ? "Claimming..." : (goblin.minted ? "Claim" : "Mint and Claim")}
                                    </Button>
                                </Box>
                            ))
                        }
                        {goblinContext.goblins && 
                        <Box sx={{ ...MainStyles.container, width: 1 }}>
                            <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox, p: 1 }}>
                                <Pagination 
                                    count={goblinContext.totalPages} 
                                    page={goblinContext.currentPage} 
                                    onChange={ async (event: object, pg: number) => {
                                        let ret = await goblinContext.listByUser(pg, ITEMS_PER_PAGE);
                                        if (!ret.sucesso) {
                                            showDialog(ret.mensagemErro, 'error');
                                        }
                                    }} renderItem={(item)=> <PaginationItem {...item} sx={{ ...GoblinStyles.sessionSubTitleText }} /> }
                                />
                            </Paper>
                        </Box>
                        }
                    </Stack>
                    : <CircularProgress />
                }
                </Fade>
                <Fade in={value == 1}>
                { !nftContext.loadingList && value == 1 ?
                    <Stack >
                        <Stack direction="row" sx={{ ...MainStyles.container, flexWrap: "wrap" }}>
                            {
                                nftContext.goblins?.map((goblin) => (
                                    <Box sx={{ m: 2 }}>
                                        <Goblin
                                            id={goblin.id}
                                            idToken={goblin.idToken}
                                            name={goblin.name}
                                            image={goblin.imageURL}
                                            size={isMobile ? SizeGoblinCard.VerySmall : SizeGoblinCard.Small}
                                            mainColor={goblin.skincolor}
                                            inCooldown={goblin.inCooldown}
                                            cooldownDate={goblin.cooldownDate}
                                            goblinSkillList={goblin.goblinSkillList}
                                            rarity={goblin.rarityenum}
                                            showStatus={false}
                                            status={goblin.status}
                                            onElemClick={(tokenId:number) => {
                                                history.push("/goblin?tokenId=" + tokenId);
                                            }}
                                        />
                                        <Button sx={{ ...MainStyles.mainButton }} onClick={ async (e: any) => {
                                            let ret = await nftContext.deposit(goblin.idToken);
                                            if (ret.sucesso) {
                                                showDialog(ret.mensagemSucesso, 'success');
                                                reloadList(goblinContext.currentPage);
                                            }
                                            else {
                                                showDialog(ret.mensagemErro, 'error');
                                                return;
                                            }
                                        }} >
                                            {nftContext.loadingAction ? "Depositing..." : "Deposit"}
                                        </Button>
                                    </Box>
                                ))
                            }
                        </Stack>
                        <Typography sx={{ ...GoblinStyles.textMain, fontSize: 16, textAlign: "center"}}>
                            NFT Contract: <a href={"https://bscscan.com/token/" + process.env.REACT_APP_CONTRACT_GOBLIN_ADDRESS} target={"_blank"} style={{color: "#fff"}}>{process.env.REACT_APP_CONTRACT_GOBLIN_ADDRESS}</a></Typography>
                    </Stack>
                    : <CircularProgress />
                }
                </Fade>
            </Stack>
            <Dialog open={openAlertMint} onClose={closeAlertMint}>
                <DialogTitle>{"Warning"}</DialogTitle>
                <DialogContent>
                    <DialogContentText>
                        Mint and claim with cost you 20 GOBI. Are you sure?
                    </DialogContentText>
                </DialogContent>
                <DialogActions>
                    <Button onClick={executeAlertMint}>Yes</Button>
                    <Button onClick={closeAlertMint}>No</Button>
                </DialogActions>
            </Dialog>
            <Dialog open={openAlertClaim} onClose={closeAlertClaim}>
                <DialogTitle>{"Warning"}</DialogTitle>
                <DialogContent>
                    <DialogContentText>
                        Claim with cost you 10 GOBI. Are you sure?
                    </DialogContentText>
                </DialogContent>
                <DialogActions>
                    <Button onClick={executeAlertClaim}>Yes</Button>
                    <Button onClick={closeAlertClaim}>No</Button>
                </DialogActions>
            </Dialog>
            <Snackbar open={openDialog} autoHideDuration={6000} onClose={handleClose} anchorOrigin={{ vertical: "top", horizontal: "right"}}>
                <Alert onClose={handleClose} severity={severity} sx={{ width: '100%' }}>
                    {message}
                </Alert>
            </Snackbar>
        </Stack>
    )
}