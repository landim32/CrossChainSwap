import React, { useContext, useEffect, useState } from 'react';
import { Alert, AlertColor, Backdrop, Box, Button, CircularProgress, Dialog, Grid, Divider, Pagination, PaginationItem, Paper, Snackbar, Stack, Theme, Typography, DialogTitle, DialogContent, DialogContentText, DialogActions } from '@mui/material';
import Moment from 'moment';
import { useHistory, useLocation } from 'react-router-dom';
import GoblinContext from '../../contexts/goblin/GoblinContext';
import { Goblin } from '../../components/Goblin';
import { makeStyles } from '@mui/styles';
import { MainStyles, GoblinStyles } from '../../utils/style';
import SizeGoblinCard from '../../dto/enum/SizeGoblinCard';
import ModeEditOutlineIcon from '@mui/icons-material/ModeEditOutline';
import { EditGoblinName } from './EditGoblinName';
import AuthContext from '../../contexts/auth/AuthContext';
import { TransferGoblin } from './TransferGoblin';
import { SxProps } from '@mui/system';
import { FontButton, FontInfo } from '../../utils/fontStyle';
import { RaceImages } from '../../utils/RaceImages';
import AvatarIcon from '../../assets/images/avatar.png';
import RarityIcon from '../../assets/images/goblin/rarity.png';
import StrIcon from "../../assets/images/goblin/strength.png";
import AgiIcon from "../../assets/images/goblin/agility.png";
import ChaIcon from "../../assets/images/goblin/charism.png";
import IntIcon from "../../assets/images/goblin/inteligence.png";
import PerIcon from "../../assets/images/goblin/perception.png";
import VigIcon from "../../assets/images/goblin/vigor.png";
import { useTimer } from "react-timer-hook";
import { GwViewPort } from '../../components/GwViewPort';
import { isMobile } from 'react-device-detect';
import MiningContext from '../../contexts/mining/MiningContext';
import { AuctionSell } from './AuctionSell';
import AuctionContext from '../../contexts/auction/AuctionContext';
import DollarContext from '../../contexts/payment/DollarContext';
import { LightenDarkenColor } from '../../utils/utils';
import { RarityStyles } from '../../utils/RarityStyles';
import HashPowerIcon from '../../assets/images/mining/hashPower.png';
import { GoblinWarsBackground, GoblinWarsColors } from '../../dto/styles/GoblinWarsColors';
import { GoblinMiningInfo } from '../../components/GoblinMiningInfo';
import { GoblinInfo } from '../../dto/domain/GoblinInfo';
import GoblinUserContext from '../../contexts/goblinUser/GoblinUserContext';
import { GoblinsCanFuse } from '../../components/GoblinsCanFuse';
import { GoblinDetails } from '../../components/GoblinDetails';
import AuctionInsertInfo from '../../dto/domain/AuctionInsertInfo';
import AttackIcon from "../../assets/images/goblin/attack_power.png";
import BlacksmithIcon from "../../assets/images/goblin/blacksmith_power.png";
import HuntingIcon from "../../assets/images/goblin/hunting_power.png";
import MagicIcon from "../../assets/images/goblin/magic_power.png";
import ResistenceIcon from "../../assets/images/goblin/resistence_power.png";
import SocialIcon from "../../assets/images/goblin/social_power.png";
import StealthIcon from "../../assets/images/goblin/stealth_power.png";
import TailoringIcon from "../../assets/images/goblin/tailoring_power.png";
import { SkillDetailInfo } from '../../dto/domain/SkillDetailInfo';

const geneIconSize = 44;

const titleSectionStyle : SxProps<Theme> = {
    ...GoblinStyles.sessionTitleText,
    fontSize: 30
}

const subTitleSectionStyle : SxProps<Theme> = {
    ...GoblinStyles.sessionTitleText,
    fontSize: 24
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

const statsIconBoxStyle : SxProps<Theme> = {
    ...MainStyles.container, 
    background: GoblinWarsBackground.containerBackground, 
    height: geneIconSize, 
    width: geneIconSize, 
    borderRadius: geneIconSize/2
}

interface TimerParam {
    expiryTimestamp: Date;
    title: string;
}

export function GoblinPage(props : any) {

    const [editingName, setEditingName] = useState(false);
    const [transferingGoblin, setTransferinfGoblin] = useState(false);
    const [sellGoblin, setSellGoblin] = useState(false);
    const [openDialog, setOpenDialog] = useState(false);
    const [message, setMessage] = useState("");
    const [severity, setSeverity] = useState<AlertColor>("success");
    const [loadingMining, setLoadingMining] = useState(false);
    //const [dollarPrice, setDollarPrice] = useState<number>(0);
    const [openDrawer, setOpenDrawer] = useState(false);

    const goblinContext = useContext(GoblinContext);
    const authContext = useContext(AuthContext);
    const miningContext = useContext(MiningContext);
    const auctionContext = useContext(AuctionContext);
    const goblinUserContext = useContext(GoblinUserContext);

    let location = useLocation();
    const history = useHistory();
    const mainContainerSize = isMobile ? 370 : 800;
    const goblinSize = isMobile ? 200 : 400;
    
    const reloadGoblin = async () => {
        let tokenId = parseInt(new URLSearchParams(location.search).get("tokenId"));
        let retGob = await goblinContext.myGoblin(tokenId);
        if (!retGob.sucesso) {
            showDialog(retGob.mensagemErro, "error");
            return;
        }
        let retAuction = await auctionContext.getbytoken(tokenId);
        //alert(JSON.stringify(retAuction));
        if (!retAuction.sucesso) {
            showDialog(retAuction.mensagemErro, "error");
            return;
        }
            //goblinContext.listGoblinsCanFuse();
            /*
            if (ret.sucesso) {
                //alert(goblinContext.goblin.isavaliable);
                auctionContext.isApproved(1, tokenId);
                auctionContext.getPrice(1, tokenId).then((ret) => {
                    if (ret.sucesso) {
                        updateDollarPrice();
                    }
                    else {
                        showDialog(ret.mensagemErro, "error");
                    }
                });
            }
            else {
                showDialog(ret.mensagemErro, "error");
            }
            */
    };

    /*
    const getPriceInDollar = (price: number) => {
        let priceUSD = price * dollarPrice;
        return parseFloat(priceUSD.toFixed(2));
    };

    const updateDollarPrice = () => {
        if (dollarPrice <= 0) {
            dollarContext.getDollar().then((ret) => {
                if (ret.sucesso) {
                    setDollarPrice(ret.dataResult);
                }
                else {
                    showDialog(ret.mensagemErro, "error");
                }
            });
        }
    };
    */


    const [currentAuction, setCurrentAuction] = useState<number>(0);
    const [openAlert, setOpenAlert] = useState<boolean>(false);

    const showAlert = (idAuction: number) => {
        setCurrentAuction(idAuction);
        setOpenAlert(true);
    };

    const closeAlert = () => {
        setOpenAlert(false);
    };

    const executeAlert = async () => {
        setOpenAlert(false);
        let ret = await auctionContext.buy(currentAuction);
        if (ret.sucesso) {
            goblinUserContext.loadBalance();
            reloadGoblin();
        }
        else {
            showDialog(ret.mensagemErro, "error");
        }
    };

    useEffect(() => {
        reloadGoblin();
    }, [ location ]);

    const openSelectBreed = () => {
        if(goblinContext.goblinSpouse) {
            history.push("/breed?idToken1=" + goblinContext.goblin.idToken + "&idToken2=" + goblinContext.goblinSpouse.idToken);
        } else {
            history.push("/breedList?idToken=" + goblinContext.goblin.idToken);
        } 
    }

    const changeMining = () => {
        setLoadingMining(true);
        if (goblinContext.goblin.status == 3) {
            miningContext.stopMining(goblinContext.goblin).then((ret) => {
                if (ret.sucesso) {
                    setLoadingMining(false);
                    showDialog("Mining stopped", "success");
                    goblinContext.myGoblin(parseInt(new URLSearchParams(location.search).get("tokenId")));
                }
                else {
                    setLoadingMining(false);
                    showDialog(ret.mensagemErro, "error");
                }
            });
        }
        else if (goblinContext.goblin.isavaliable) {
            miningContext.startMining(goblinContext.goblin).then((ret) => {
                if (ret.sucesso) {
                    setLoadingMining(false);
                    showDialog("Successfully started mining", "success");
                    goblinContext.myGoblin(parseInt(new URLSearchParams(location.search).get("tokenId")));
                }
                else {
                    setLoadingMining(false);
                    showDialog(ret.mensagemErro, "error");
                }
            });
        }
        else {
            setLoadingMining(false);
            showDialog("This goblin is not avaliable.", "error");
        }
    }

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

    const openEditName = () => {
        setEditingName(true);
    };
    const closeEditName = () => {
        setEditingName(false);
    };

    const openTransferGoblin = () => {
        setTransferinfGoblin(true);
    };
    const closeTransferGoblin = () => {
        setTransferinfGoblin(false);
    };

    const openSellGoblin = () => {
        setSellGoblin(true);
    };
    const closeSellGoblin = () => {
        setSellGoblin(false);
    };

    const handleOpenDrawer = () => {
        setOpenDrawer(true);
    }

    const handleCloseDrawer = () => {
        setOpenDrawer(false);
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
          <Stack sx={{ ...MainStyles.container }}>
            <Typography sx={{ ...GoblinStyles.sessionTitleText }} >{param.title}</Typography>
            <Typography sx={{ ...GoblinStyles.textMain }} >{days + " days " + hours + " hr " + minutes + " min " + seconds + " sec"}</Typography>
          </Stack>
        );
    }
    
    const buildFamilyMembers = () => {
        return (
            <>
                <Stack direction={"row"} sx={{ ...MainStyles.container, width: 1, flexWrap: "wrap" }}>
                    {
                        !goblinContext.loading.father ?
                            goblinContext.goblinFather &&
                            <Paper sx={{...GoblinStyles.boxGoblinParent, m: 1}}>
                                <Stack sx={{ width: 1, ...MainStyles.container }}>
                                    <Paper sx={{ ...GoblinStyles.subSessionTitle }}>
                                        <Typography sx={{ ...subTitleSectionStyle }} >FATHER</Typography>
                                    </Paper>
                                    <Box sx={{ ...MainStyles.container, p: isMobile ? 0.5 : 1 }}>
                                        <Goblin
                                            id={goblinContext.goblinFather.id}
                                            idToken={goblinContext.goblinFather.idToken}
                                            name={goblinContext.goblinFather.name}
                                            size={isMobile ? SizeGoblinCard.VerySmall : SizeGoblinCard.Small}
                                            mainColor={goblinContext.goblinFather.skincolor}
                                            image={goblinContext.goblinFather.imageURL}
                                            goblinSkillList={goblinContext.goblinFather.goblinSkillList}
                                            rarity={goblinContext.goblinFather.rarityenum}
                                            onElemClick={(tokenId:number) => {
                                                history.push("/goblin?tokenId=" + tokenId);
                                            }}
                                        />
                                    </Box>
                                </Stack>
                            </Paper>
                        :   <CircularProgress />
                    }
                    {
                        !goblinContext.loading.mother ?
                        goblinContext.goblinMother &&
                        <Paper sx={{...GoblinStyles.boxGoblinParent, m: 1}}>
                            <Stack sx={{ width: 1, ...MainStyles.container }}>
                                <Paper sx={{ ...GoblinStyles.subSessionTitle }}>
                                    <Typography sx={{ ...subTitleSectionStyle }} >MOTHER</Typography>
                                </Paper>
                                <Box sx={{ ...MainStyles.container, p: isMobile ? 0.5 : 1 }}>
                                    <Goblin
                                        id={goblinContext.goblinMother.id}
                                        idToken={goblinContext.goblinMother.idToken}
                                        name={goblinContext.goblinMother.name}
                                        size={isMobile ? SizeGoblinCard.VerySmall : SizeGoblinCard.Small}
                                        mainColor={goblinContext.goblinMother.skincolor}
                                        image={goblinContext.goblinMother.imageURL}
                                        goblinSkillList={goblinContext.goblinMother.goblinSkillList}
                                        rarity={goblinContext.goblinMother.rarityenum}
                                        onElemClick={(tokenId:number) => {
                                            history.push("/goblin?tokenId=" + tokenId);
                                        }}
                                    />
                                </Box>
                            </Stack>
                        </Paper>
                    :   <CircularProgress />
                    }
                    {
                        !goblinContext.loading.spouse ?
                        goblinContext.goblinSpouse &&
                        <Paper sx={{...GoblinStyles.boxGoblinParent, m: 1}}>
                            <Stack sx={{ width: 1, ...MainStyles.container }}>
                                <Paper sx={{ ...GoblinStyles.subSessionTitle }}>
                                    <Typography sx={{ ...subTitleSectionStyle }} >SPOUSE</Typography>
                                </Paper>
                                <Box sx={{ ...MainStyles.container, p: isMobile ? 0.5 : 1 }}>
                                    <Goblin
                                        id={goblinContext.goblinSpouse.id}
                                        idToken={goblinContext.goblinSpouse.idToken}
                                        name={goblinContext.goblinSpouse.name}
                                        size={isMobile ? SizeGoblinCard.VerySmall : SizeGoblinCard.Small}
                                        mainColor={goblinContext.goblinSpouse.skincolor}
                                        image={goblinContext.goblinSpouse.imageURL}
                                        goblinSkillList={goblinContext.goblinSpouse.goblinSkillList}
                                        rarity={goblinContext.goblinSpouse.rarityenum}
                                        onElemClick={(tokenId:number) => {
                                            history.push("/goblin?tokenId=" + tokenId);
                                        }}
                                    />
                                </Box>
                            </Stack>
                        </Paper>
                        : <CircularProgress />
                    }
                </Stack>
                
                { !goblinContext.loading.sons ?
                    goblinContext.sons && goblinContext.sons.goblins && goblinContext.sons.goblins.length > 0  && 
                    <Box sx={{ ...MainStyles.container, width: 1, p: 1 }}>
                        <Paper sx={{...GoblinStyles.boxGoblinParent, width: 1, pb: 1}}>
                            <Paper sx={{ ...GoblinStyles.subSessionTitle }}>
                                <Typography sx={{ ...subTitleSectionStyle }} >SONS</Typography>
                            </Paper>
                            <Stack direction="row" sx={{ ...MainStyles.container, flexWrap: "wrap" }}>
                                {
                                    goblinContext.sons.goblins.map((value) => (
                                        <Box sx={{ m: 1 }}>
                                            <Goblin
                                                id={value.id}
                                                idToken={value.idToken}
                                                name={value.name}
                                                size={isMobile ? SizeGoblinCard.VerySmall : SizeGoblinCard.Small}
                                                mainColor={value.skincolor}
                                                image={value.imageURL}
                                                goblinSkillList={value.goblinSkillList}
                                                rarity={value.rarityenum}
                                                onElemClick={(tokenId:number) => {
                                                    history.push("/goblin?tokenId=" + tokenId);
                                                }}
                                            />
                                        </Box>
                                    ))
                                }
                                <Box sx={{ ...MainStyles.container, width: 1 }}>
                                    <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox, p: 1 }}>
                                        <Pagination 
                                            count={goblinContext.sons.totalPages} 
                                            page={goblinContext.sons.page} 
                                            onChange={(event: object, page: number) => {
                                                goblinContext.listSons(goblinContext.goblin.idToken, page);
                                            }} renderItem={(item)=> <PaginationItem {...item} sx={{ ...GoblinStyles.sessionSubTitleText }} /> }
                                        />
                                    </Paper>
                                </Box>
                            </Stack>
                        </Paper>
                    </Box>
                    : <CircularProgress />

                }
                { !goblinContext.loading.brothers ?
                    goblinContext.brothers && goblinContext.brothers.goblins && goblinContext.brothers.goblins.length > 0  && 
                    <Box sx={{ ...MainStyles.container, width: 1, p: 1 }}>
                        <Paper sx={{...GoblinStyles.boxGoblinParent,  width: 1, pb: 1}}>
                            <Paper sx={{ ...GoblinStyles.subSessionTitle }}>
                                <Typography sx={{ ...subTitleSectionStyle }} >BROTHERS</Typography>
                            </Paper>
                            <Stack direction="row" sx={{ ...MainStyles.container, flexWrap: "wrap" }}>
                                {
                                    goblinContext.brothers.goblins.map((value) => (
                                        <Box sx={{ m: 1 }}>
                                            <Goblin
                                                id={value.id}
                                                idToken={value.idToken}
                                                name={value.name}
                                                size={isMobile ? SizeGoblinCard.VerySmall : SizeGoblinCard.Small}
                                                mainColor={value.skincolor}
                                                image={value.imageURL}
                                                goblinSkillList={value.goblinSkillList}
                                                rarity={value.rarityenum}
                                                onElemClick={(tokenId:number) => {
                                                    history.push("/goblin?tokenId=" + tokenId);
                                                }}
                                            />
                                        </Box>
                                    ))
                                }
                                <Box sx={{ ...MainStyles.container, width: 1 }}>
                                    <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox, p: 1 }}>
                                        <Pagination 
                                            count={goblinContext.brothers.totalPages} 
                                            page={goblinContext.brothers.page} 
                                            onChange={(event: object, page: number) => {
                                                goblinContext.listBrothers(goblinContext.goblin.idToken, page);
                                            }} renderItem={(item)=> <PaginationItem {...item} sx={{ ...GoblinStyles.sessionSubTitleText }} /> }
                                        />
                                    </Paper>
                                </Box>
                            </Stack>
                        </Paper>
                    </Box>
                    : <CircularProgress />

                }
            </>
        )
    }

    const GetBonusAttribute = (icon: string, text: string, value: SkillDetailInfo) => {
        let isNegativeBonus = value.bonus < 0;
        return (
            <Grid item xs={6} sx={{ ...MainStyles.container, mb: 1 }}>
                <Stack direction={"row"} spacing={1} sx={{ justifyContent: "flex-start", alignItems: "center" }} >
                    <img draggable="false"  src={icon} style={{ height: geneIconSize }} alt={text} />
                    <Stack sx={{ ...MainStyles.container }} spacing={0} >
                        <Stack sx={{ ...MainStyles.container }} spacing={-1}>
                            <Typography sx={{ ...statsText }} flexWrap={"wrap"} >{value.total}</Typography>
                            <Stack sx={{ ...MainStyles.container }} direction={"row"} spacing={0}>
                                <Typography sx={{ ...subInfoStyle }} flexWrap={"wrap"} >{value.base}</Typography>
                                <Typography sx={{ ...subInfoStyle, color: isNegativeBonus ? "red" : "green" }} flexWrap={"wrap"} >{isNegativeBonus ? "-" : "+"}</Typography>
                                <Typography sx={{ ...subInfoStyle, color: isNegativeBonus ? "red" : "green" }} flexWrap={"wrap"} >{value.bonus.toString().replace("-", "")}</Typography>
                            </Stack>
                        </Stack>
                        <Typography sx={{ ...subInfoStyle, mt: -1 }} flexWrap={"wrap"} >{text}</Typography>
                    </Stack>
                </Stack>
            </Grid>
        )
    }

    return (
        <GwViewPort >
            <Box sx={{ mb: 2 }} >
            {!goblinContext.loading.info && goblinContext.goblin ? 
                <Grid item xs={12} >
                    <Grid container justifyContent="center" spacing={3}>
                        <Grid key="main" item>
                            <Paper sx={{ width: mainContainerSize, bgcolor: "#2b211f", pb: 3, border: 1 }} elevation={3} > 
                                <Stack spacing={5} sx={{...MainStyles.container}} >
                                    <Paper sx={{ ...GoblinStyles.sessionTitle }}>
                                        <Stack direction={"row"} sx={{ width: 1, display: "flex", alignItems: "center", justifyContent: "space-between" }} spacing={1}>
                                            <Typography sx={{ ...titleSectionStyle }} >{goblinContext.goblin.name.toUpperCase()}</Typography>
                                            {
                                                authContext.sessionInfo && authContext.sessionInfo.publicAddress.toLowerCase() == goblinContext.goblin.userAddress.toLowerCase() &&
                                                <Box>
                                                    <Button variant="contained" sx={{ ...MainStyles.mainButton }} onClick={() => {
                                                        openEditName();
                                                    }} >
                                                        <Stack direction={"row"} spacing={2} sx={{ ...MainStyles.container }}>
                                                            <ModeEditOutlineIcon fontSize={"medium"} sx={{ color: "white", mr: 1 }} />
                                                            Rename
                                                        </Stack>
                                                    </Button>
                                                </Box>
                                            }
                                        </Stack>
                                    </Paper>
                                    <GoblinDetails 
                                            isMobile={isMobile}
                                            goblin={goblinContext.goblin}
                                            goblinSize={goblinSize} 
                                            //breedCout={goblinContext.breedCount} 
                                            //breedLoading={goblinContext.loading.breedCount}    
                                            isOwner={authContext.sessionInfo && authContext.sessionInfo.publicAddress.toLowerCase() == goblinContext.goblin.userAddress.toLowerCase()}                                />
                                    {
                                        !isMobile &&
                                        buildFamilyMembers()
                                    }
                                </Stack>
                            </Paper>
                        </Grid>
                        <Grid key="detail" item>
                            <Paper sx={{ width: 370, bgcolor: "#2b211f", pb: 3, border: 1 }} elevation={3}>
                                <Stack sx={{...MainStyles.container}} spacing={2} >
                                    <Paper sx={{ ...GoblinStyles.sessionTitle }}>
                                        <Typography sx={{ ...titleSectionStyle }} >OWNER</Typography>
                                    </Paper>
                                    { !goblinContext.loading.info && goblinContext.goblin ?
                                        <>
                                            <Stack sx={{ width: 1, p: 1, justifyContent: "flex-start", alignItems: "center" }} direction="row" spacing={2}>
                                                <img draggable="false"  src={AvatarIcon} alt={goblinContext.goblin.nameUser} style={{ height: 46, borderRadius: 23 }} />
                                                <Stack>
                                                    <Typography sx={{ ...infoStyle }} flexWrap={"wrap"} >{goblinContext.goblin.nameUser}</Typography>
                                                    <Typography sx={{ ...subInfoStyle }} flexWrap={"wrap"} >{goblinContext.goblin.userAddress}</Typography>
                                                </Stack>
                                            </Stack>
                                            {
                                                authContext.sessionInfo && authContext.sessionInfo.publicAddress.toLowerCase() == goblinContext.goblin.userAddress.toLowerCase() &&
                                                (
                                                    goblinContext.goblin.isbusy ? 
                                                    <MyTimer title={"Not avaliable until"} expiryTimestamp={new Date(Moment(goblinContext.goblin.busy).add("minutes", (new Date()).getTimezoneOffset() * -1).valueOf())}  />
                                                    :
                                                    (
                                                    goblinContext.goblin.inCooldown ? 
                                                    <MyTimer title={"In cooldown until"} expiryTimestamp={new Date(Moment(goblinContext.goblin.cooldownDate).valueOf())}  />
                                                    :<Stack sx={{ width: 1 }} spacing={0}>
                                                        {auctionContext.myAuction && auctionContext.myAuction?.price > 0 ? 
                                                        <>
                                                            <Stack sx={{ width: 1, p: 1 }} direction="row" spacing={3}>
                                                                <Box sx={{width: "450px", pt: "5px", pb: "5px"}}>
                                                                    <Typography sx={{ ...GoblinStyles.sessionTitleText, textAlign: "center"}}>{auctionContext.myAuction?.price} GOBI</Typography>
                                                                </Box>
                                                                <Button variant="contained" sx={{ ...MainStyles.mainButton }} onClick={ async () => {
                                                                    if(!auctionContext.loadingAction ) {
                                                                        let ret = await auctionContext.cancel(auctionContext.myAuction?.id);
                                                                        if (ret.sucesso) {
                                                                            reloadGoblin();
                                                                        }
                                                                        else {
                                                                            showDialog(ret.mensagemErro, "error");
                                                                        }
                                                                    }
                                                                }}>{auctionContext.loadingAction ? "Cancelling..." : "Cancel"}</Button>
                                                            </Stack>
                                                        </>:<>
                                                        {goblinContext.goblin.isavaliable ?
                                                            <>
                                                            <Stack sx={{ width: 1, p: 1 }}  direction="row" spacing={2} >
                                                                <Button variant="contained" sx={{ ...MainStyles.mainButton }} onClick={openSelectBreed}>Breed</Button>
                                                                <Button variant="contained" sx={{ ...MainStyles.mainButton }} onClick={handleOpenDrawer}>Fuse</Button>
                                                            </Stack>
                                                            <Stack sx={{ width: 1, p: 1 }}  direction="row" spacing={2} >
                                                                <Button variant="contained" sx={{ ...MainStyles.mainButton }} onClick={openTransferGoblin}>Transfer</Button>
                                                                <Button variant="contained" sx={{ ...MainStyles.mainButton }} onClick={openSellGoblin}>Sell</Button>
                                                            </Stack>
                                                            </>
                                                        : <></>}
                                                        </>
                                                        }
                                                    </Stack>
                                                    )
                                                )
                                            }
                                            {
                                                auctionContext.myAuction?.price > 0 && authContext.sessionInfo && 
                                                authContext.sessionInfo.publicAddress.toLowerCase() != goblinContext.goblin.userAddress.toLowerCase() && (
                                                    <Stack sx={{ width: 1, p: 1 }} direction="row" spacing={3}>
                                                        <Box sx={{width: "450px", pt: "5px", pb: "5px"}}>
                                                            <Typography sx={{ ...GoblinStyles.sessionTitleText, textAlign: "center"}}>{auctionContext.myAuction?.price} GOBI</Typography>
                                                        </Box>
                                                        <Button variant="contained" sx={{ ...MainStyles.mainButton }} onClick={async () => {
                                                            showAlert(auctionContext.myAuction?.id);
                                                        }}>{auctionContext.loadingAction ? "Buying..." : "Buy"}</Button>
                                                    </Stack>
                                                )
                                            }
                                        </>
                                        : <CircularProgress />
                                    }
                                    { !goblinContext.loading.info && goblinContext.goblin && (goblinContext.goblin.isavaliable || goblinContext.goblin.status == 3) && 
                                      authContext.sessionInfo && 
                                      authContext.sessionInfo.publicAddress.toLowerCase() == goblinContext.goblin.userAddress.toLowerCase() &&
                                        <GoblinMiningInfo goblinInfo={goblinContext.goblin}
                                        rechargeCb={(goblin: GoblinInfo) => {
                                            goblinContext.rechargeGoblin().then((ret) => {
                                                if (ret.sucesso) {
                                                    showDialog("Successfully recharged goblin", "success");
                                                    goblinContext.myGoblin(parseInt(new URLSearchParams(location.search).get("tokenId")));
                                                    miningContext.info(true);
                                                    goblinUserContext.loadBalance();
                                                } else {
                                                    showDialog(ret.mensagemErro, "error");
                                                }
                                            });
                                        } }
                                        loading={goblinContext.loading.recharge} titleSectionStyle={titleSectionStyle} infoText={infoStyle}
                                        statsText={statsText} subInfoStyle={subInfoStyle} geneIconSize={geneIconSize} changeMining={changeMining} loadingMining={loadingMining}                                        /> 
                                    }
                                    <Paper sx={{ ...GoblinStyles.sessionTitle }}>
                                        <Typography sx={{ ...titleSectionStyle }} >SKILLS</Typography>
                                    </Paper>
                                    <Grid container sx={{ ...MainStyles.container, p: 1 }}>
                                        {
                                            GetBonusAttribute(HashPowerIcon, "Mining Power", goblinContext.goblin.goblinSkillList.mining)
                                        }
                                        {
                                            GetBonusAttribute(AttackIcon, "Attack Power", goblinContext.goblin.goblinSkillList.attack)
                                        }
                                        {
                                            GetBonusAttribute(BlacksmithIcon, "Blacksmith Power", goblinContext.goblin.goblinSkillList.blacksmith)
                                        }
                                        {
                                            GetBonusAttribute(HuntingIcon, "Hunting Power", goblinContext.goblin.goblinSkillList.hunting)
                                        }
                                        {
                                            GetBonusAttribute(MagicIcon, "Magic Power", goblinContext.goblin.goblinSkillList.magic)
                                        }
                                        {
                                            GetBonusAttribute(ResistenceIcon, "Resistence Power", goblinContext.goblin.goblinSkillList.resistence)
                                        }
                                        {
                                            GetBonusAttribute(SocialIcon, "Social Power", goblinContext.goblin.goblinSkillList.social)
                                        }
                                        {
                                            GetBonusAttribute(StealthIcon, "Stealth Power", goblinContext.goblin.goblinSkillList.stealth)
                                        }
                                        {
                                            GetBonusAttribute(TailoringIcon, "Tailoring Power", goblinContext.goblin.goblinSkillList.tailoring)
                                        }
                                    </Grid>
                                    <Paper sx={{ ...GoblinStyles.sessionTitle }}>
                                        <Typography sx={{ ...titleSectionStyle }} >STATS</Typography>
                                    </Paper>
                                    <Grid container sx={{ ...MainStyles.container, p: 1 }}>
                                        <Grid item xs={6} sx={{ ...MainStyles.container, mb: 1 }}>
                                            <Stack direction={"row"} spacing={1} sx={{ justifyContent: "flex-start", alignItems: "center" }} >
                                                <img draggable="false"  src={RarityIcon} style={{ height: geneIconSize }} alt={"Rarity"} />
                                                <Box sx={{ ...MainStyles.container, flexDirection: "column" }} >
                                                    <Typography sx={{ ...statsText, color: RarityStyles.getRarityColor(goblinContext.goblin.rarityenum) }} flexWrap={"wrap"} >{RarityStyles.getRarityName(goblinContext.goblin.rarityenum)}</Typography>
                                                    <Typography sx={{ ...subInfoStyle, mt: -1 }} flexWrap={"wrap"} >Rarity</Typography>
                                                </Box>
                                            </Stack>
                                        </Grid>
                                        <Grid item xs={12} sx={{ ...MainStyles.container, mb: 1.5, mt: 1.5 }}>
                                            <Divider variant="middle" sx={{ color: GoblinWarsColors.titleColor, width:'100%' }} />
                                        </Grid>
                                        <Grid item xs={6} sx={{ ...MainStyles.container, mb: 1 }}>
                                            <Stack direction={"row"} spacing={1} sx={{ justifyContent: "flex-start", alignItems: "center" }} >
                                                <img draggable="false"  style={{ height: 32 }} src={StrIcon} />
                                                <Stack sx={{ ...MainStyles.container, width: 80 }} spacing={0} >
                                                    <Typography sx={{ ...statsText }} flexWrap={"wrap"} >{goblinContext.goblin.strength}</Typography>
                                                    <Typography sx={{ ...subInfoStyle, mt: -1 }} flexWrap={"wrap"} >Strength</Typography>
                                                </Stack>
                                            </Stack>
                                        </Grid>
                                        <Grid item xs={6} sx={{ ...MainStyles.container, mb: 1 }}>
                                            <Stack direction={"row"} spacing={1} sx={{ justifyContent: "flex-start", alignItems: "center" }} >
                                                <img draggable="false"  style={{ height: 32 }} src={AgiIcon} />
                                                <Stack sx={{ ...MainStyles.container, width: 80 }} spacing={0} >
                                                    <Typography sx={{ ...statsText }} flexWrap={"wrap"} >{goblinContext.goblin.agility}</Typography>
                                                    <Typography sx={{ ...subInfoStyle, mt: -1 }} flexWrap={"wrap"} >Agility</Typography>
                                                </Stack>
                                            </Stack>
                                        </Grid>
                                        <Grid item xs={6} sx={{ ...MainStyles.container, mb: 1 }}>
                                            <Stack direction={"row"} spacing={1} sx={{ justifyContent: "flex-start", alignItems: "center" }} >
                                                <img draggable="false"  style={{ height: 32 }} src={VigIcon} />
                                                <Stack sx={{ ...MainStyles.container, width: 80 }} spacing={0} >
                                                    <Typography sx={{ ...statsText }} flexWrap={"wrap"} >{goblinContext.goblin.vigor}</Typography>
                                                    <Typography sx={{ ...subInfoStyle, mt: -1 }} flexWrap={"wrap"} >Vigor</Typography>
                                                </Stack>
                                            </Stack>
                                        </Grid>
                                        <Grid item xs={6} sx={{ ...MainStyles.container, mb: 1 }}>
                                            <Stack direction={"row"} spacing={1} sx={{ justifyContent: "flex-start", alignItems: "center" }} >
                                                <img draggable="false"  style={{ height: 32 }} src={IntIcon} />
                                                <Stack sx={{ ...MainStyles.container, width: 80 }} spacing={0} >
                                                    <Typography sx={{ ...statsText }} flexWrap={"wrap"} >{goblinContext.goblin.intelligence}</Typography>
                                                    <Typography sx={{ ...subInfoStyle, mt: -1 }} flexWrap={"wrap"} >Inteligence</Typography>
                                                </Stack>
                                            </Stack>
                                        </Grid>
                                        <Grid item xs={6} sx={{ ...MainStyles.container, mb: 1 }}>
                                            <Stack direction={"row"} spacing={1} sx={{ justifyContent: "flex-start", alignItems: "center" }} >
                                                <img draggable="false"  style={{ height: 32 }} src={ChaIcon} />
                                                <Stack sx={{ ...MainStyles.container, width: 80 }} spacing={0} >
                                                    <Typography sx={{ ...statsText }} flexWrap={"wrap"} >{goblinContext.goblin.charism}</Typography>
                                                    <Typography sx={{ ...subInfoStyle, mt: -1 }} flexWrap={"wrap"} >Charism</Typography>
                                                </Stack>
                                            </Stack>
                                        </Grid>
                                        <Grid item xs={6} sx={{ ...MainStyles.container, mb: 1 }}>
                                            <Stack direction={"row"} spacing={1} sx={{ justifyContent: "flex-start", alignItems: "center" }} >
                                                <img draggable="false"  style={{ height: 32 }} src={PerIcon} />
                                                <Stack sx={{ ...MainStyles.container, width: 80 }} spacing={0} >
                                                    <Typography sx={{ ...statsText }} flexWrap={"wrap"} >{goblinContext.goblin.perception}</Typography>
                                                    <Typography sx={{ ...subInfoStyle, mt: -1 }} flexWrap={"wrap"} >Perception</Typography>
                                                </Stack>
                                            </Stack>
                                        </Grid>
                                    </Grid>
                                    <Paper sx={{ ...GoblinStyles.sessionTitle }}>
                                        <Typography sx={{ ...titleSectionStyle }} >GENETICS</Typography>
                                    </Paper>
                                    <Grid container sx={{ ...MainStyles.container, p: 1 }}>
                                        <Grid item xs={6} sx={{ ...MainStyles.container, mb: 1 }}>
                                            <Stack direction={"row"} spacing={1} sx={{ justifyContent: "flex-start", alignItems: "center" }} >
                                                <img draggable="false"  src={RaceImages.getRaceIcon(goblinContext.goblin.race)} style={{ height: geneIconSize }} alt={"Race"} />
                                                <Box sx={{ ...MainStyles.container, flexDirection: "column" }} >
                                                    <Typography sx={{ ...statsText }} flexWrap={"wrap"} >{goblinContext.goblin.raceName}</Typography>
                                                    <Typography sx={{ ...subInfoStyle, mt: -1 }} flexWrap={"wrap"} >Race</Typography>
                                                </Box>
                                            </Stack>
                                        </Grid>
                                        <Grid item xs={6} sx={{ ...MainStyles.container, mb: 1 }}>
                                            <Stack direction={"row"} spacing={1} sx={{ justifyContent: "flex-start", alignItems: "center" }} >
                                                <img draggable="false"  src={RaceImages.getRaceHair(goblinContext.goblin.hair)} style={{ height: geneIconSize }} alt={"Hair"} />
                                                <Stack sx={{ ...MainStyles.container }} spacing={0} >
                                                    <Typography sx={{ ...statsText }} flexWrap={"wrap"} >{goblinContext.goblin.hairName}</Typography>
                                                    <Typography sx={{ ...subInfoStyle, mt: -1 }} flexWrap={"wrap"} >Hair</Typography>
                                                </Stack>
                                            </Stack>
                                        </Grid>
                                        <Grid item xs={6} sx={{ ...MainStyles.container, mb: 1 }}>
                                            <Stack direction={"row"} spacing={1} sx={{ justifyContent: "flex-start", alignItems: "center" }} >
                                                <img draggable="false"  src={RaceImages.getRaceEars(goblinContext.goblin.ear)} style={{ height: geneIconSize }} alt={"Ears"} />
                                                <Stack sx={{ ...MainStyles.container }} spacing={0} >
                                                    <Typography sx={{ ...statsText }} flexWrap={"wrap"} >{goblinContext.goblin.earName}</Typography>
                                                    <Typography sx={{ ...subInfoStyle, mt: -1 }} flexWrap={"wrap"} >Ear</Typography>
                                                </Stack>
                                            </Stack>
                                        </Grid>
                                        <Grid item xs={6} sx={{ ...MainStyles.container, mb: 1 }}>
                                            <Stack direction={"row"} spacing={1} sx={{ justifyContent: "flex-start", alignItems: "center" }} >
                                                <img draggable="false"  src={RaceImages.getRaceEyes(goblinContext.goblin.eye)} style={{ height: geneIconSize }} alt={"Eye"} />
                                                <Stack sx={{ ...MainStyles.container }} spacing={0} >
                                                    <Typography sx={{ ...statsText }} flexWrap={"wrap"} >{goblinContext.goblin.eyeName}</Typography>
                                                    <Typography sx={{ ...subInfoStyle, mt: -1 }} flexWrap={"wrap"} >Eye</Typography>
                                                </Stack>
                                            </Stack>
                                        </Grid>
                                        <Grid item xs={6} sx={{ ...MainStyles.container, mb: 1 }}>
                                            <Stack direction={"row"} spacing={1} sx={{ justifyContent: "flex-start", alignItems: "center" }} >
                                                <img draggable="false"  src={RaceImages.getRaceSkin(goblinContext.goblin.skin)} style={{ height: geneIconSize }} alt={"Skin"} />
                                                <Stack sx={{ ...MainStyles.container }} spacing={0} >
                                                    <Typography sx={{ ...statsText }} flexWrap={"wrap"} >{goblinContext.goblin.skinName}</Typography>
                                                    <Typography sx={{ ...subInfoStyle, mt: -1 }} flexWrap={"wrap"} >Skin</Typography>
                                                </Stack>
                                            </Stack>
                                        </Grid>
                                        <Grid item xs={6} sx={{ ...MainStyles.container, mb: 1 }}>
                                            <Stack direction={"row"} spacing={1} sx={{ justifyContent: "flex-start", alignItems: "center" }} >
                                                <img draggable="false"  src={RaceImages.getRaceMouth(goblinContext.goblin.mount)} style={{ height: geneIconSize }} alt={"Mouth"} />
                                                <Stack sx={{ ...MainStyles.container }} spacing={0} >
                                                    <Typography sx={{ ...statsText, mt: -1 }} flexWrap={"wrap"} >{goblinContext.goblin.mountName}</Typography>
                                                    <Typography sx={{ ...subInfoStyle, mt: -1 }} flexWrap={"wrap"} >Mouth</Typography>
                                                </Stack>
                                                
                                            </Stack>
                                        </Grid>
                                    </Grid>
                                </Stack>
                            </Paper>
                        </Grid>
                        {
                            isMobile &&
                            <Grid key="detail" item>
                                <Paper sx={{ width: mainContainerSize, bgcolor: "#2b211f", pb: 3, border: 1 }} elevation={3}>
                                    <Stack spacing={5} sx={{...MainStyles.container}} >
                                        <Paper sx={{ ...GoblinStyles.sessionTitle }}>
                                            <Typography sx={{ ...titleSectionStyle }} >FAMILY MEMBERS</Typography>
                                        </Paper>
                                        {
                                            buildFamilyMembers()
                                        }
                                    </Stack>
                                </Paper>
                            </Grid>
                        }
                    </Grid>
                </Grid>
                :
                <Backdrop
                    sx={{ color: '#fff', zIndex: (theme) => 99 }}
                    open={true}
                >
                    <CircularProgress color="inherit" />
                </Backdrop>
            }
            </Box>
            <Dialog
                open={editingName}
                keepMounted
                onClose={closeEditName}
            >
                <EditGoblinName editCb={async (name: string) => {
                    if(name.match(/[^A-Za-z0-9\s]+/g) || name.length < 3 || name.length > 25)
                    {
                        showDialog("Invalid name", "error");
                        return;
                    }
                    const ret = await goblinContext.updateGoblinName(goblinContext.goblin.idToken, name);
                    if(ret.sucesso) {
                        showDialog(ret.mensagemSucesso, "success");
                        closeEditName();
                    } else {
                        showDialog(ret.mensagemErro, "error");
                    }
                } }
                close={closeEditName} name={goblinContext.goblin?.name} loading={goblinContext.loading.updateName}  />
            </Dialog>
            <Dialog
                open={transferingGoblin}
                keepMounted
                onClose={closeTransferGoblin}
            >
                <TransferGoblin transferCb={async (address: string) => {
                    const ret = await goblinContext.transferGoblin(goblinContext.goblin, address);
                    if(ret.sucesso) {
                        showDialog(ret.mensagemSucesso, "success");
                        closeTransferGoblin();
                        reloadGoblin();
                    } else {
                        showDialog(ret.mensagemErro, "error");
                    }
                } }
                close={closeTransferGoblin} goblin={goblinContext.goblin} loading={goblinContext.loading.transferGoblin}  />
            </Dialog>
            <Dialog open={sellGoblin} keepMounted onClose={closeSellGoblin}>
                <AuctionSell insert={ async (tokenId: number, price: number) => {
                    if(!auctionContext.loading ) {
                        let param: AuctionInsertInfo = {
                            auction: 1,
                            tokenid: tokenId,
                            price: price,
                            qtdy: 1
                        };
                        let ret = await auctionContext.insert(param);
                        if (ret.sucesso) {
                            closeSellGoblin();
                            reloadGoblin();
                        }
                        else {
                            showDialog(ret.mensagemErro, "error");
                        }
                    }
                }}
                close={closeSellGoblin} 
                //dollarPrice={dollarPrice}
                tokenId={goblinContext.goblin?.idToken}
                loading={auctionContext.loading}
                />
            </Dialog>
            <Dialog open={openAlert} onClose={closeAlert}>
                <DialogTitle>{"Warning"}</DialogTitle>
                <DialogContent>
                    <DialogContentText>
                        Are you sure?
                    </DialogContentText>
                </DialogContent>
                <DialogActions>
                    <Button onClick={executeAlert}>Yes</Button>
                    <Button onClick={closeAlert}>No</Button>
                </DialogActions>
            </Dialog>
            <Snackbar open={openDialog} autoHideDuration={6000} onClose={handleClose} anchorOrigin={{ vertical: "top", horizontal: "right"}}>
                <Alert onClose={handleClose} severity={severity} sx={{ width: '100%' }}>
                    {message}
                </Alert>
            </Snackbar>
            {
                goblinContext.goblin && goblinContext.goblin.isavaliable &&  
                authContext.sessionInfo && 
                authContext.sessionInfo.publicAddress.toLowerCase() == goblinContext.goblin.userAddress.toLowerCase() &&
                <GoblinsCanFuse loading={goblinContext.loading.listCanFuse} 
                    selectGoblin={function (goblin: GoblinInfo): void {
                        history.push("/fusion?targetTokenId=" + goblinContext.goblin.idToken + "&sacrificeTokenId=" + goblin.idToken);
                    } } 
                    goblinsCanFuse={goblinContext.goblinsCanFuse} 
                    isMobile={isMobile} 
                    open={openDrawer} 
                    handleCloseDrawer={handleCloseDrawer} 
                    handleOpenDrawer={handleOpenDrawer} 
                />
            }
        </GwViewPort>
    )
} 