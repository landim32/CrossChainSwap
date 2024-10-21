import { Stack, Grid, Box, Typography, Paper, Button, Theme, Divider, Snackbar, Alert, AlertColor, Tabs, Tab, styled, CircularProgress, Fade, Dialog, DialogTitle, DialogContent, DialogContentText, DialogActions } from "@mui/material";
import { GwViewPort } from "../../components/GwViewPort";
import { SxProps } from "@mui/system";
import React, {useContext, useEffect, useState} from 'react';
import { GoblinStyles, MainStyles } from "../../utils/style";
import Gobox1 from '../../assets/images/box/gobox1.png';
import Gobox2 from '../../assets/images/box/gobox2.png';
import Gobox3 from '../../assets/images/box/gobox3.png';
import ItemBoxCommon from '../../assets/images/box/item-common.png';
import ItemBoxUncommon from '../../assets/images/box/item-uncommon.png';
import ItemBoxRare from '../../assets/images/box/item-rare.png';
import ItemBoxEpic from '../../assets/images/box/item-epic.png';
import ItemBoxLegendary from '../../assets/images/box/item-legendary.png';
import GoboxContext from "../../contexts/payment/GoboxContext";
import { useHistory } from "react-router";
import { isMobile } from 'react-device-detect';
import { GoblinWarsColors } from "../../dto/styles/GoblinWarsColors";
import { RarityStyles } from "../../utils/RarityStyles";
import { RarityEnum } from "../../dto/enum/RarityEnum";
import { BoxSell } from "./BoxSell";
import AuctionInsertInfo from "../../dto/domain/AuctionInsertInfo";
import AuctionContext from "../../contexts/auction/AuctionContext";
import { GenericSlot } from "../../components/GenericSlot";
import { GetItemAssets } from "../../utils/ItemAssetsUtils";
import { ItemInfo } from "../../dto/domain/ItemInfo";
import { AnchorElItem } from "../../dto/business/AnchorElItem";
import { ItemPopover } from "../../components/ItemPopover";

const rarityLeft : SxProps<Theme> = {
    textAlign: "left",
    color: "#fff"
};
const rarityRight : SxProps<Theme> = {
    textAlign: "right",
    color: "#fff"
};

const textInputProps : SxProps<Theme> = {
    color: "#fff"
}

const maxWidth = isMobile ? "350" : "auto";

interface OpenResult {
    open: boolean;
    itens: ItemInfo[];
}

export function BoxOpen() {

    const goboxContext = useContext(GoboxContext);
    const auctionContext = useContext(AuctionContext);

    const history = useHistory();

    const [openDialog, setOpenDialog] = useState(false);
    const [message, setMessage] = useState("");
    const [severity, setSeverity] = useState<AlertColor>("success");

    const [indexBoxType, setIndexBoxType] = useState<number>(0);
    const [openAlert, setOpenAlert] = useState<boolean>(false);

    const [openResult, setOpenResult] = useState<OpenResult>(null);

    const showResult = (itens: ItemInfo[]) => {
        setOpenResult({open: true, itens: itens});
        goboxContext.listMyBox();
    }

    const closeResult = () => {
        setOpenResult(null);
    }

    const showAlert = (boxType: number) => {
        //setCurrentBoxType(boxType);
        setOpenAlert(true);
    };

    const closeAlert = () => {
        setOpenAlert(false);
    };

    const executeAlert = async () => {
        setOpenAlert(false);
        setOpenLoading(true);
        if(indexBoxType < 3) {
            goboxContext.openBox(getBoxType()).then((ret) => {
                setOpenLoading(false);
                if (ret.sucesso) {
                    showDialog(ret.mensagemSucesso, "success");
                    if(ret.dataResult > -1) {
                        history.push("/goblin?tokenId=" + ret.dataResult);
                    }
                }
                else {
                    showDialog(ret.mensagemErro, "error");
                }
            });
        } else {
            goboxContext.openItemBox(getBoxType()).then((ret) => {
                setOpenLoading(false);
                if (ret.sucesso) {
                    showResult(ret.dataResult);
                }
                else {
                    showDialog(ret.mensagemErro, "error");
                }
            });
        }
    };

    //const [value, setValue] = useState(0);

    const handleChange = (event : any, newValue : number) => {
        console.log("Teste: " + newValue);
        setIndexBoxType(newValue);
    };

    const [openLoading, setOpenLoading] = useState(false);

    const showDialog = (message: string, severity: AlertColor) => {
        setSeverity(severity);
        setMessage(message);
        setOpenDialog(true);
    }

    const handleClose = (ev: any) => {
        if (ev?.reason === 'clickaway') {
            return;
        }
        setOpenDialog(false);
    };

    const [sellBox, setSellBox] = useState(false);

    const openSellBox = () => {
        setSellBox(true);
    };
    const closeSellBox = () => {
        setSellBox(false);
    };

    useEffect(() => {
        goboxContext.listMyBox().then((ret) => {
            if (!ret.sucesso) {
                showDialog(ret.mensagemErro, "error")
            }
        });
    }, []);

    const [anchorEl, setAnchorEl] = useState<AnchorElItem>(null);

    const handleClick = (event: any, selectEquip: ItemInfo) => {
        setAnchorEl({anchorEl: event, selectItem: selectEquip});
    };

    const handleClosePopOver = () => {
        setAnchorEl(null);
    };

    const open = Boolean(anchorEl);
    const id = open ? 'inventory-popover' : undefined;

    const getSelectColor = () => {
        switch(indexBoxType) {
            case 0:
                return RarityStyles.getRarityColor(RarityEnum.Common);
            case 1:
                return RarityStyles.getRarityColor(RarityEnum.Uncommon);
            case 2:
                return RarityStyles.getRarityColor(RarityEnum.Rare);
            case 3:
                return RarityStyles.getRarityColor(RarityEnum.Common);
            case 4:
                return RarityStyles.getRarityColor(RarityEnum.Uncommon);
            case 5:
                return RarityStyles.getRarityColor(RarityEnum.Rare);
            case 6:
                return RarityStyles.getRarityColor(RarityEnum.Epic);
            case 7:
                return RarityStyles.getRarityColor(RarityEnum.Legendary);
        }
    }

    const getBoxType = () => {
        switch(indexBoxType) {
            case 0:
                return goboxContext.COMMON_ID;
            case 1:
                return goboxContext.UNCOMMON_ID;
            case 2:
                return goboxContext.RARE_ID;
            case 3:
                return goboxContext.ITEM_COMMON_ID;
            case 4:
                return goboxContext.ITEM_UNCOMMON_ID;
            case 5:
                return goboxContext.ITEM_RARE_ID;
            case 6:
                return goboxContext.ITEM_EPIC_ID;
            case 7:
                return goboxContext.ITEM_LEGENDARY_ID;
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
        '& .MuiTabs-scrollButtons': {
            color: GoblinWarsColors.titleColor
        }
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
                color: getSelectColor(),
                fontWeight: "bold",
                textShadow: "0px 5px 4px #191719,1px 1px 0px #181813, rgb(61, 59, 46) 3px 0px 0px, rgb(61, 59, 46) 2.83487px 0.981584px 0px, rgb(61, 59, 46) 2.35766px 1.85511px 0px, rgb(61, 59, 46) 1.62091px 2.52441px 0px, rgb(61, 59, 46) 0.705713px 2.91581px 0px, rgb(61, 59, 46) -0.287171px 2.98622px 0px, rgb(61, 59, 46) -1.24844px 2.72789px 0px, rgb(61, 59, 46) -2.07227px 2.16926px 0px, rgb(61, 59, 46) -2.66798px 1.37182px 0px, rgb(61, 59, 46) -2.96998px 0.42336px 0px, rgb(61, 59, 46) -2.94502px -0.571704px 0px, rgb(61, 59, 46) -2.59586px -1.50383px 0px, rgb(61, 59, 46) -1.96093px -2.27041px 0px, rgb(61, 59, 46) -1.11013px -2.78704px 0px, rgb(61, 59, 46) -0.137119px -2.99686px 0px, rgb(61, 59, 46) 0.850987px -2.87677px 0px, rgb(61, 59, 46) 1.74541px -2.43999px 0px, rgb(61, 59, 46) 2.44769px -1.73459px 0px, rgb(61, 59, 46) 2.88051px -0.838247px 0px;"
            }
        }),
    );

    const boxComponent = (boxImage: string, tokenId: number, goboxName: string, balance: number) => {
        return (
        <Stack spacing={1} sx={{ ...MainStyles.container, width: 1, borderLeft: isMobile ? 0 : 1, borderColor: isMobile ? 'transparent': 'divider' }} >
            <Typography sx={{ ...GoblinStyles.textMain, textAlign: "center"}}>{goboxName} #{tokenId}</Typography>
            <img draggable="false"  src={boxImage} style={{width: isMobile ? "300px" : "400px"}} />
            {
                balance > -1 ? 
                <>
                    <Typography sx={{ ...GoblinStyles.sessionTitleText, textAlign: "center"}}>Qtdy: {balance}</Typography>
                    {
                        isMobile && 
                        <Divider sx={{color: "#fff", m: 2, width: "100%" }}></Divider>
                    }
                    <Stack direction={"row"}  sx={{ display: "flex", justifyContent: "space-around", width: 1 }}>
                        <Button sx={{ ...MainStyles.mainButton, width: 110 }} onClick={() => {
                            if (balance > 0) {
                                showAlert(tokenId);
                            }
                            else {
                                showDialog("You dont have any box!", "error");
                            }
                            }}>{openLoading ? "OPENING..." : "OPEN"}</Button>
                        <Button sx={{ ...MainStyles.mainButton, width: 110 }} onClick={openSellBox}>SELL</Button>
                        {
                            tokenId < 3 && !isMobile && 
                            <Button sx={{ ...MainStyles.mainButton, width: "auto" }} onClick={() => {
                                history.push("/buy-gobox")
                            }}>BUY YOUR GOBOX</Button>
                        }
                        {
                            tokenId >= 3 && !isMobile && 
                            <Button sx={{ ...MainStyles.mainButton, width: "auto" }} onClick={() => {
                                history.push("/marketplace-gobox")
                            }}>BUY ITEM BOX</Button>
                        }
                    </Stack>
                    {
                        tokenId < 3 && isMobile && 
                        <Button sx={{ ...MainStyles.mainButton, width: "auto" }} onClick={() => {
                            history.push("/buy-gobox")
                        }}>BUY YOUR GOBOX</Button>
                    }
                    {
                        tokenId >= 3 && isMobile && 
                        <Button sx={{ ...MainStyles.mainButton, width: "auto" }} onClick={() => {
                            history.push("/marketplace-gobox")
                        }}>BUY ITEM BOX</Button>
                    }
                </>
                : <CircularProgress />
            }
        </Stack>)
    }

    return (
        <GwViewPort>
            <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox, width: maxWidth }}>
                {
                    isMobile ? 
                    <Stack>
                        <Box sx={{ borderBottom: 1, borderColor: 'divider', mb: 2, maxWidth: 340 }}>
                            <StyledTabs value={indexBoxType} onChange={handleChange} variant="scrollable" scrollButtons allowScrollButtonsMobile >
                                <StyledTab label="Common" />
                                <StyledTab label="Uncommon"  />
                                <StyledTab label="Rare" />
                                <StyledTab label="Item Common" />
                                <StyledTab label="Item Uncommon" />
                                <StyledTab label="Item Rare" />
                                <StyledTab label="Item Epic" />
                                <StyledTab label="Item Legendary" />
                            </StyledTabs>
                        </Box>
                        <Fade in={indexBoxType == 0}>
                            {
                                indexBoxType == 0 ?
                                boxComponent(Gobox1, goboxContext.COMMON_ID, "GOBOX Common", goboxContext.goboxCommon?.qtdy)
                                : <Box></Box>
                            }
                        </Fade>
                        <Fade in={indexBoxType == 1}>
                            {
                                indexBoxType == 1 ?
                               boxComponent(Gobox2, goboxContext.UNCOMMON_ID, "GOBOX Uncommon", goboxContext.goboxUncommon?.qtdy)
                               : <Box></Box>
                            }
                        </Fade>
                        <Fade in={indexBoxType == 2}>
                            {
                                indexBoxType == 2 ?
                                boxComponent(Gobox3, goboxContext.RARE_ID, "GOBOX Rare", goboxContext.goboxRare?.qtdy)
                                : <Box></Box>
                            }
                        </Fade>
                        <Fade in={indexBoxType == 3}>
                            {
                                indexBoxType == 3 ?
                                boxComponent(ItemBoxCommon, goboxContext.ITEM_COMMON_ID, "Item Box Common", goboxContext.itemBoxCommon?.qtdy)
                                : <Box></Box>
                            }
                        </Fade>
                        <Fade in={indexBoxType == 4}>
                            {
                                indexBoxType == 4 ?
                                boxComponent(ItemBoxUncommon, goboxContext.ITEM_UNCOMMON_ID, "Item Box Uncommon", goboxContext.itemBoxUncommon?.qtdy)
                                : <Box></Box>
                            }
                        </Fade>
                        <Fade in={indexBoxType == 5}>
                            {
                                indexBoxType == 5 ?
                                boxComponent(ItemBoxRare, goboxContext.ITEM_RARE_ID, "Item Box Rare", goboxContext.itemBoxRare?.qtdy)
                                : <Box></Box>
                            }
                        </Fade>
                        <Fade in={indexBoxType == 6}>
                            {
                                indexBoxType == 6 ?
                                boxComponent(ItemBoxEpic, goboxContext.ITEM_EPIC_ID, "Item Box Epic", goboxContext.itemBoxEpic?.qtdy)
                                : <Box></Box>
                            }
                        </Fade>
                        <Fade in={indexBoxType == 7}>
                            {
                                indexBoxType == 7 ?
                                boxComponent(ItemBoxLegendary, goboxContext.ITEM_LEGENDARY_ID, "Item Box Legendary", goboxContext.itemBoxLegendary?.qtdy)
                                : <Box></Box>
                            }
                        </Fade>
                    </Stack>
                    :<Stack direction={"row"} sx={{ display: "flex", alignItems: "flex-start" }} >
                        <Box sx={{ width: 240 }} >
                            <StyledTabs value={indexBoxType} onChange={handleChange} orientation="vertical" >
                                <StyledTab label="Common" />
                                <StyledTab label="Uncommon"  />
                                <StyledTab label="Rare" />
                                <StyledTab label="Item Common" />
                                <StyledTab label="Item Uncommon" />
                                <StyledTab label="Item Rare" />
                                <StyledTab label="Item Epic" />
                                <StyledTab label="Item Legendary" />
                            </StyledTabs>
                        </Box>
                        <Fade in={indexBoxType == 0}>
                            {
                                indexBoxType == 0 ?
                                boxComponent(Gobox1, goboxContext.COMMON_ID, "GOBOX Common", goboxContext.goboxCommon?.qtdy)
                                : <Box></Box>
                            }
                        </Fade>
                        <Fade in={indexBoxType == 1}>
                            {
                                indexBoxType == 1 ?
                               boxComponent(Gobox2, goboxContext.UNCOMMON_ID, "GOBOX Uncommon", goboxContext.goboxUncommon?.qtdy)
                               : <Box></Box>
                            }
                        </Fade>
                        <Fade in={indexBoxType == 2}>
                            {
                                indexBoxType == 2 ?
                                boxComponent(Gobox3, goboxContext.RARE_ID, "GOBOX Rare", goboxContext.goboxRare?.qtdy)
                                : <Box></Box>
                            }
                        </Fade>
                        <Fade in={indexBoxType == 3}>
                            {
                                indexBoxType == 3 ?
                                boxComponent(ItemBoxCommon, goboxContext.ITEM_COMMON_ID, "Item Box Common", goboxContext.itemBoxCommon?.qtdy)
                                : <Box></Box>
                            }
                        </Fade>
                        <Fade in={indexBoxType == 4}>
                            {
                                indexBoxType == 4 ?
                                boxComponent(ItemBoxUncommon, goboxContext.ITEM_UNCOMMON_ID, "Item Box Uncommon", goboxContext.itemBoxUncommon?.qtdy)
                                : <Box></Box>
                            }
                        </Fade>
                        <Fade in={indexBoxType == 5}>
                            {
                                indexBoxType == 5 ?
                                boxComponent(ItemBoxRare, goboxContext.ITEM_RARE_ID, "Item Box Rare", goboxContext.itemBoxRare?.qtdy)
                                : <Box></Box>
                            }
                        </Fade>
                        <Fade in={indexBoxType == 6}>
                            {
                                indexBoxType == 6 ?
                                boxComponent(ItemBoxEpic, goboxContext.ITEM_EPIC_ID, "Item Box Epic", goboxContext.itemBoxEpic?.qtdy)
                                : <Box></Box>
                            }
                        </Fade>
                        <Fade in={indexBoxType == 7}>
                            {
                                indexBoxType == 7 ?
                                boxComponent(ItemBoxLegendary, goboxContext.ITEM_LEGENDARY_ID, "Item Box Legendary", goboxContext.itemBoxLegendary?.qtdy)
                                : <Box></Box>
                            }
                        </Fade>
                    </Stack>
                }
                
            </Paper>
            <Dialog open={sellBox} keepMounted onClose={closeSellBox}>
                <BoxSell insert={async (boxType: number, price: number, qtdy: number) => {
                    if (!auctionContext.loadingAction) {
                        let param: AuctionInsertInfo = {
                            auction: 2,
                            boxType: boxType,
                            price: price * qtdy,
                            qtdy: qtdy
                        };
                        //alert(JSON.stringify(param));
                        let ret = await auctionContext.insert(param);
                        if (!ret.sucesso) {
                            showDialog(ret.mensagemErro, "error");
                            return;
                        }
                        closeSellBox();
                        showDialog("Sales started successfully.", "success");
                        goboxContext.listMyBox().then((ret) => {
                            if (!ret.sucesso) {
                                showDialog(ret.mensagemErro, "error");
                            }
                        });
                    }
                } }
                close={closeSellBox}
                //dollarPrice={dollarPrice}
                boxType={getBoxType()}
                qtdy={1}
                loading={auctionContext.loadingAction} 
                error={(msg) => {
                    showDialog(msg, "error");
                } }                
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
            <Dialog open={openResult?.open} onClose={closeResult}>
                <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox }}>
                    <Stack sx={{ ...MainStyles.container }} spacing={2}>
                        <Typography sx={{ ...GoblinStyles.textMain }}>Item Reward</Typography>
                        <Stack sx={{ ...MainStyles.container }} spacing={1} direction={"row"}>
                            {
                                openResult && openResult.itens &&
                                openResult.itens.map(item => (
                                    <GenericSlot boxSize={80} rarity={item.rarity} >
                                        <Box sx={{ ...MainStyles.container, height: 80, width: 80 }} onClick={(ev: any) => {
                                            handleClick(ev.currentTarget, item);
                                        }}>
                                            <img draggable="false"  style={{ width: 70 }} src={GetItemAssets(item.iconAsset)} />
                                        </Box>
                                    </GenericSlot>
                                ))
                            }
                            
                        </Stack>
                        <Button sx={{ ...MainStyles.mainButton }} onClick={closeResult} >Yay !</Button>
                    </Stack>
                </Paper>
            </Dialog>
            <Snackbar open={openDialog} autoHideDuration={6000} onClose={handleClose} anchorOrigin={{ vertical: "top", horizontal: "right"}}>
                <Alert onClose={handleClose} severity={severity} sx={{ width: '100%' }}>
                    {message}
                </Alert>
            </Snackbar>
            <ItemPopover anchorEl={anchorEl} equipCb={() => {}} moreDetail={(item: ItemInfo) => {
                history.push("/equipment?key=" + item.key);
            }} loading={false} open={open} closeCb={handleClosePopOver} id={id} canEquip={false} />
        </GwViewPort>
    )
}