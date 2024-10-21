import { Alert, AlertColor, Box, Button, CircularProgress, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle, Divider, Fade, IconButton, MenuItem, Pagination, PaginationItem, Paper, Snackbar, Stack, SwipeableDrawer, SxProps, Tab, Tabs, TextField, Theme, Toolbar, Typography } from "@mui/material";
import { useContext, useEffect, useState } from "react";
import { GwViewPort } from "../../components/GwViewPort";
import AuctionContext from "../../contexts/auction/AuctionContext";
import { MainStyles, GoblinStyles } from "../../utils/style";
import { BrowserView, MobileView, isBrowser, isMobile } from 'react-device-detect';
import { useHistory, useLocation } from "react-router";
import { makeStyles, styled } from "@mui/styles";
import HideIcon from '../../assets/images/menu/show.png'
import FilterIcon from '../../assets/images/marketplace/filter.png'
import MarketplaceIcon from '../../assets/images/menu/marketplace.png'
import { OulinedInput } from "../../components/OutlinedInput";
import { GoblinWarsColors } from "../../dto/styles/GoblinWarsColors";
import { RarityStyles } from "../../utils/RarityStyles";
import { RarityEnum } from "../../dto/enum/RarityEnum";
import EquipmentCard from "../../components/EquipmentCard";
import AuctionEquipmentFilterInfo from "../../dto/domain/AuctionEquipmentFilterInfo";
import AuctionInfo from "../../dto/domain/AuctionInfo";
import MarketingTabs from "../../components/MarketingTabs";
import { DefaultTabs, DefaultTab } from "../../components/GwTabs";

const textInput : SxProps<Theme> = {
    width: 1,
  }
  
  const textInputProps : SxProps<Theme> = {
    ...GoblinStyles.sessionSubTitleText
  }

const drawerWidth = isMobile ? 300 : 400;

const useStyles = makeStyles({
    paper: {
        background: "linear-gradient(180deg, rgba(99,145,83,1) 0%, rgba(43,52,33,1) 100%)"
    }
})

export function MarketplaceEquipment() {
    const classes = useStyles();

    let location = useLocation();
    const [openDrawer, setOpenDrawer] = useState(false);
    const auctionContext = useContext(AuctionContext);
    
    const [openDialog, setOpenDialog] = useState(false);
    const [message, setMessage] = useState("");
    const [severity, setSeverity] = useState<AlertColor>("success");

    const [value, setValue] = useState(0);

    const handleChange = (event : any, newValue : number) => {
        setValue(newValue);
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

    const handleClose = (ev: any) => {
        if (ev?.reason === 'clickaway') {
            return;
        }
        setOpenDialog(false);
    };

    const handleOpenDrawer = () => {
        setOpenDrawer(true);
    }

    const handleCloseDrawer = () => {
        setOpenDrawer(false);
    }

    const showDialog = (message: string, severity: AlertColor) => {
        setSeverity(severity);
        setMessage(message);
        setOpenDialog(true);
    }

    const [currentAuction, setCurrentAuction] = useState<number>(null);
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
            let ret = await auctionContext.searchEquipment(auctionContext.filter);
            if (!ret.sucesso) {
                showDialog(ret.mensagemErro, 'error');
            }
        }
        else {
            showDialog(ret.mensagemErro, "error");
        }
    };

    useEffect(() => {
        let param: AuctionEquipmentFilterInfo = {
            equipmenttype: null,
            rarity: null,
            page: 1
        };
        auctionContext.searchEquipment(param).then((ret) => {
            if (!ret.sucesso) {
                showDialog(ret.mensagemErro, 'error');
            }
        });
        auctionContext.listByUser(3).then((ret) => {
            if (!ret.sucesso) {
                showDialog(ret.mensagemErro, 'error');
            }
        });
    }, [ location ]);

    const buildFilterDrawer = () => {
        return (
            <SwipeableDrawer
                anchor={"right"}
                open={openDrawer}
                onClose={handleCloseDrawer} 
                onOpen={handleOpenDrawer} 
                classes={{ paper: classes.paper }} 
            >
                <Stack sx={{ width: drawerWidth, height: 1, pb: 4, display: "flex", alignContent: "flex-start", alignItems: "flex-start" }} >
                    <Toolbar sx={{ bgcolor: "#232a1b", width: 1, top: 0 }} >
                        <Stack direction={"row"} sx={{ ...MainStyles.container, width: 1, justifyContent: "space-between", pr: 1 }}>
                            <Stack sx={{ ...MainStyles.container }} direction={"row"} >
                                <IconButton onClick={handleCloseDrawer}>
                                    <img draggable="false"  src={HideIcon} style={{ height: 32 }} alt={"hide"} />
                                </IconButton>
                                <Typography sx={{ ...GoblinStyles.sessionTitleText }} >hide</Typography>
                            </Stack>
                            <Typography sx={{ ...GoblinStyles.textMain }} >Filter</Typography>
                        </Stack>
                    </Toolbar>
                    <Divider />
                    <Stack spacing={3} sx={{ ...MainStyles.container, width: 1, p: 2 }}>
                        <OulinedInput id="rarityCombo" select label="Rarity" value={auctionContext.filterEquipment?.rarity} 
                            onChange={ async (e: any) => {
                                let param: AuctionEquipmentFilterInfo = {...auctionContext.filterEquipment, rarity: e.target.value}; 
                                let ret = await auctionContext.searchEquipment(param);
                                if (!ret.sucesso) {
                                    showDialog(ret.mensagemErro, 'error');
                                }
                            }}
                            sx={{ ...textInput }} InputProps={{ sx: { ...textInputProps } }}
                            FormHelperTextProps={{ sx: { ...textInputProps } }} >
                            <MenuItem key={0} value={999}>Anyone</MenuItem>
                            <MenuItem key={1} value={0}>Common</MenuItem>
                            <MenuItem key={2} value={1}>Uncommon</MenuItem>
                            <MenuItem key={3} value={2}>Rare</MenuItem>
                            <MenuItem key={4} value={3}>Epic</MenuItem>
                            <MenuItem key={5} value={4}>Legendary</MenuItem>
                        </OulinedInput>
                        <OulinedInput id="equipmentTypeCombo" select label="equipmentType" value={auctionContext.filterEquipment?.equipmenttype} 
                            onChange={ async (e: any) => {
                                let param: AuctionEquipmentFilterInfo = {...auctionContext.filterEquipment, equipmenttype: e.target.value}; 
                                let ret = await auctionContext.searchEquipment(param);
                                if (!ret.sucesso) {
                                    showDialog(ret.mensagemErro, 'error');
                                }
                            }}
                            sx={{ ...textInput }} InputProps={{ sx: { ...textInputProps } }}
                            FormHelperTextProps={{ sx: { ...textInputProps } }}>
                            <MenuItem key={999} value={999}>Anyone</MenuItem>
                            <MenuItem key={2} value={2}>Helmet</MenuItem>
                            <MenuItem key={3} value={3}>Body Armor</MenuItem>
                            <MenuItem key={5} value={5}>Hand Armor</MenuItem>
                            <MenuItem key={6} value={6}>Foot Armor</MenuItem>
                            <MenuItem key={9} value={9}>Sword</MenuItem>
                            <MenuItem key={10} value={10}>2 Handed Sword</MenuItem>
                            <MenuItem key={11} value={11}>Shield</MenuItem>
                            <MenuItem key={12} value={12}>Knife</MenuItem>
                            <MenuItem key={13} value={13}>Staff</MenuItem>
                            <MenuItem key={14} value={14}>Crossbow</MenuItem>
                            <MenuItem key={15} value={15}>Hammer</MenuItem>
                            <MenuItem key={16} value={16}>Axe</MenuItem>
                            <MenuItem key={17} value={17}>Greataxe</MenuItem>
                            <MenuItem key={18} value={18}>Mace</MenuItem>
                            <MenuItem key={19} value={19}>Spear</MenuItem>
                            <MenuItem key={20} value={20}>Bow</MenuItem>
                            <MenuItem key={21} value={21}>Pickaxe</MenuItem>
                        </OulinedInput>
                    </Stack>
                </Stack>
            </SwipeableDrawer>
        )
    }

    return (
        <Stack sx={{ ...MainStyles.container }}>
            <Stack direction={"row"} sx={{ ...MainStyles.container }} spacing={1} >
                <img draggable="false"  src={MarketplaceIcon} style={{ height: 30 }} />
                <Typography sx={{ ...GoblinStyles.sessionTitleText }} >Marketplace</Typography>
                <Button sx={{ ...MainStyles.mainButton, width: 130 }} onClick={handleOpenDrawer} >
                    <Stack direction={"row"} sx={{ ...MainStyles.container, ml: 1 }} spacing={1}>
                        <Typography sx={{ ...GoblinStyles.textMain }} >Filter</Typography>
                        <img draggable="false"  src={FilterIcon} style={{ height: 30 }}  />
                    </Stack>
                </Button>
            </Stack>
            <Stack spacing={1} sx={{ ...MainStyles.container, p: 0}}>
                <DefaultTabs value={value} onChange={handleChange} centered >
                    <DefaultTab label="All Boxes" />
                    <DefaultTab label="My Boxes for Sale"  />
                </DefaultTabs>
                <Fade in={value == 0}>
                { !auctionContext.loading && value == 0 ?
                    <Stack direction="row" sx={{ ...MainStyles.container, flexWrap: "wrap" }}>
                        {
                            auctionContext.equipmentList?.auctions.map((value: AuctionInfo) => (
                                <Box sx={{ m: 2 }}>
                                    <EquipmentCard
                                        auction={value}
                                        item={value.item}
                                        loading={auctionContext.loadingAction}
                                        buy={(auction) => {
                                            showAlert(auction.id);
                                        }} 
                                    />
                                </Box>
                            ))
                        }
                        {auctionContext.goblinList && 
                        <Box sx={{ ...MainStyles.container, width: 1 }}>
                            <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox, p: 1 }}>
                                <Pagination 
                                    count={auctionContext.goblinList?.totalpages} 
                                    page={auctionContext.goblinList?.page} 
                                    onChange={ async (event: object, pg: number) => {
                                        let param: AuctionEquipmentFilterInfo = {...auctionContext.filter, page: pg };
                                        let ret = await auctionContext.searchEquipment(param);
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
                { !auctionContext.loading && value == 1 ?
                        <Stack direction="row" sx={{ ...MainStyles.container, flexWrap: "wrap" }}>
                            {
                                auctionContext.myAuctionList?.auctions.map((value: AuctionInfo) => (
                                    <Box sx={{ m: 2 }}>
                                        <EquipmentCard
                                            auction={value}
                                            item={value.item}
                                            loading={auctionContext.loadingAction}
                                            cancel={ async (auction) => {
                                                let ret = await auctionContext.cancel(value.id);
                                                if (!ret.sucesso) {
                                                    showDialog(ret.mensagemErro, 'error');
                                                    return;
                                                }
                                                let retEquip = await auctionContext.searchEquipment(auctionContext.filterEquipment);
                                                if (!retEquip.sucesso) {
                                                    showDialog(retEquip.mensagemErro, 'error');
                                                }
                                                showDialog("Sales successfully canceled.", 'success');
                                            }} 
                                        />
                                    </Box>
                                ))
                            }
                        </Stack>
                        : <CircularProgress />
                    }
                </Fade>
            </Stack>
            { buildFilterDrawer() }
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
        </Stack>
    )
}