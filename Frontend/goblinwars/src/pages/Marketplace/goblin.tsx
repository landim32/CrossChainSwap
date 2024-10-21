import { Alert, AlertColor, Box, Button, CircularProgress, Divider, IconButton, MenuItem, Pagination, PaginationItem, Paper, Snackbar, Stack, SwipeableDrawer, SxProps, TextField, Theme, Toolbar, Typography } from "@mui/material";
import { useContext, useEffect, useState } from "react";
import { Goblin } from "../../components/Goblin";
import { GwViewPort } from "../../components/GwViewPort";
import AuctionContext from "../../contexts/auction/AuctionContext";
import { MainStyles, GoblinStyles } from "../../utils/style";
import { BrowserView, MobileView, isBrowser, isMobile } from 'react-device-detect';
import { useHistory, useLocation } from "react-router";
import SizeGoblinCard from '../../dto/enum/SizeGoblinCard';
import DollarContext from "../../contexts/payment/DollarContext";
import { makeStyles } from "@mui/styles";
import HideIcon from '../../assets/images/menu/show.png'
import FilterIcon from '../../assets/images/marketplace/filter.png'
import MarketplaceIcon from '../../assets/images/menu/marketplace.png'
import { OulinedInput } from "../../components/OutlinedInput";
import AuctionFilterInfo from "../../dto/domain/AuctionFilterInfo";
import MarketingTabs from "../../components/MarketingTabs";

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

export function MarketplaceGoblin() {
    const classes = useStyles();

    let location = useLocation();
    const history = useHistory();
    const [openDrawer, setOpenDrawer] = useState(false);
    const auctionContext = useContext(AuctionContext);
    
    const [openDialog, setOpenDialog] = useState(false);
    const [message, setMessage] = useState("");
    const [severity, setSeverity] = useState<AlertColor>("success");

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

    useEffect(() => {
        //updateDollarPrice();
        let param: AuctionFilterInfo = {
            rarity: 999,
            genre: "",
            page: 1
        };
        auctionContext.searchGoblin(param).then((ret) => {
            //alert(JSON.stringify(ret));
            if (!ret.sucesso) {
                showDialog(ret.mensagemErro, 'error');
            }
        });
        //reloadGoblin();
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
                        <OulinedInput id="rarityCombo" select label="Rarity" value={auctionContext.filter?.rarity} 
                            onChange={ async (e: any) => {
                                let param: AuctionFilterInfo = {...auctionContext.filter, rarity: e.target.value}; 
                                let ret = await auctionContext.searchGoblin(param);
                                if (!ret.sucesso) {
                                    showDialog(ret.mensagemErro, 'error');
                                }
                            }}
                            sx={{ ...textInput }} InputProps={{ sx: { ...textInputProps } }}
                            FormHelperTextProps={{ sx: { ...textInputProps } }}>
                            <MenuItem key={0} value={999}>Anyone</MenuItem>
                            <MenuItem key={1} value={0}>Common</MenuItem>
                            <MenuItem key={2} value={1}>Uncommon</MenuItem>
                            <MenuItem key={3} value={2}>Rare</MenuItem>
                            <MenuItem key={4} value={3}>Epic</MenuItem>
                            <MenuItem key={5} value={4}>Legendary</MenuItem>
                        </OulinedInput>
                        <OulinedInput id="genreCombo" select label="Genre" value={auctionContext.filter?.genre} 
                            onChange={ async (e: any) => {
                                let param: AuctionFilterInfo = {...auctionContext.filter, genre: e.target.value}; 
                                let ret = await auctionContext.searchGoblin(param);
                                if (!ret.sucesso) {
                                    showDialog(ret.mensagemErro, 'error');
                                }
                            }}
                            sx={{ ...textInput }} InputProps={{ sx: { ...textInputProps } }}
                            FormHelperTextProps={{ sx: { ...textInputProps } }}>
                            <MenuItem key={0} value={""}>Anyone</MenuItem>
                            <MenuItem key={1} value={"m"}>Male</MenuItem>
                            <MenuItem key={2} value={"f"}>Female</MenuItem>
                        </OulinedInput>
                        <OulinedInput id="raceCombo" select label="Race" value={auctionContext.filter?.race} 
                            onChange={ async (e: any) => {
                                let param: AuctionFilterInfo = {...auctionContext.filter, race: e.target.value};
                                let ret = await auctionContext.searchGoblin(param);
                                if (!ret.sucesso) {
                                    showDialog(ret.mensagemErro, 'error');
                                }
                            }}
                            sx={{ ...textInput }} InputProps={{ sx: { ...textInputProps } }}
                            FormHelperTextProps={{ sx: { ...textInputProps } }}>
                            <MenuItem key={0} value={999}>Any</MenuItem>
                            <MenuItem key={1} value={0}>Forest</MenuItem>
                            <MenuItem key={1} value={1}>Mountain</MenuItem>
                            <MenuItem key={1} value={2}>Desert</MenuItem>
                            <MenuItem key={1} value={3}>Sea</MenuItem>
                            <MenuItem key={1} value={4}>Cave</MenuItem>
                            <MenuItem key={1} value={5}>Dark</MenuItem>
                        </OulinedInput>
                        <OulinedInput id="hairCombo" select label="Hair" value={auctionContext.filter?.hair} 
                            onChange={ async (e: any) => {
                                let param: AuctionFilterInfo = {...auctionContext.filter, race: e.target.value};
                                let ret = await auctionContext.searchGoblin(param);
                                if (!ret.sucesso) {
                                    showDialog(ret.mensagemErro, 'error');
                                }
                            }}
                            sx={{ ...textInput }} InputProps={{ sx: { ...textInputProps } }}
                            FormHelperTextProps={{ sx: { ...textInputProps } }}>
                            <MenuItem key={0} value={999}>Any</MenuItem>
                            <MenuItem key={1} value={0}>Forest</MenuItem>
                            <MenuItem key={1} value={1}>Mountain</MenuItem>
                            <MenuItem key={1} value={2}>Desert</MenuItem>
                            <MenuItem key={1} value={3}>Sea</MenuItem>
                            <MenuItem key={1} value={4}>Cave</MenuItem>
                            <MenuItem key={1} value={5}>Dark</MenuItem>
                        </OulinedInput>
                        <OulinedInput id="earCombo" select label="Ear" value={auctionContext.filter?.ear} 
                            onChange={async (e: any) => {
                                let param: AuctionFilterInfo = {...auctionContext.filter, ear: e.target.value};
                                let ret = await auctionContext.searchGoblin(param);
                                if (!ret.sucesso) {
                                    showDialog(ret.mensagemErro, 'error');
                                }
                            }}
                            sx={{ ...textInput }} InputProps={{ sx: { ...textInputProps } }}
                            FormHelperTextProps={{ sx: { ...textInputProps } }}>
                            <MenuItem key={0} value={999}>Any</MenuItem>
                            <MenuItem key={1} value={0}>Forest</MenuItem>
                            <MenuItem key={1} value={1}>Mountain</MenuItem>
                            <MenuItem key={1} value={2}>Desert</MenuItem>
                            <MenuItem key={1} value={3}>Sea</MenuItem>
                            <MenuItem key={1} value={4}>Cave</MenuItem>
                            <MenuItem key={1} value={5}>Dark</MenuItem>
                        </OulinedInput>
                        <OulinedInput id="eyeCombo" select label="Eye" value={auctionContext.filter?.eye} 
                            onChange={ async (e: any) => {
                                let param: AuctionFilterInfo = {...auctionContext.filter, ear: e.target.value};
                                let ret = await auctionContext.searchGoblin(param);
                                if (!ret.sucesso) {
                                    showDialog(ret.mensagemErro, 'error');
                                }
                            }}
                            sx={{ ...textInput }} InputProps={{ sx: { ...textInputProps } }}
                            FormHelperTextProps={{ sx: { ...textInputProps } }}>
                            <MenuItem key={0} value={999}>Any</MenuItem>
                            <MenuItem key={1} value={0}>Forest</MenuItem>
                            <MenuItem key={1} value={1}>Mountain</MenuItem>
                            <MenuItem key={1} value={2}>Desert</MenuItem>
                            <MenuItem key={1} value={3}>Sea</MenuItem>
                            <MenuItem key={1} value={4}>Cave</MenuItem>
                            <MenuItem key={1} value={5}>Dark</MenuItem>
                        </OulinedInput>
                        <OulinedInput id="mountCombo" select label="Mount" value={auctionContext.filter?.mount} 
                            onChange={ async (e: any) => {
                                let param: AuctionFilterInfo = {...auctionContext.filter, mount: e.target.value};
                                let ret = await auctionContext.searchGoblin(param);
                                if (!ret.sucesso) {
                                    showDialog(ret.mensagemErro, 'error');
                                }
                            }}
                            sx={{ ...textInput }} InputProps={{ sx: { ...textInputProps } }}
                            FormHelperTextProps={{ sx: { ...textInputProps } }}>
                            <MenuItem key={0} value={999}>Any</MenuItem>
                            <MenuItem key={1} value={0}>Forest</MenuItem>
                            <MenuItem key={1} value={1}>Mountain</MenuItem>
                            <MenuItem key={1} value={2}>Desert</MenuItem>
                            <MenuItem key={1} value={3}>Sea</MenuItem>
                            <MenuItem key={1} value={4}>Cave</MenuItem>
                            <MenuItem key={1} value={5}>Dark</MenuItem>
                        </OulinedInput>
                        <OulinedInput id="skinCombo" select label="Skin" value={auctionContext.filter?.skin} 
                            onChange={ async (e: any) => {
                                let param: AuctionFilterInfo = {...auctionContext.filter, skin: e.target.value};
                                let ret = await auctionContext.searchGoblin(param);
                                if (!ret.sucesso) {
                                    showDialog(ret.mensagemErro, 'error');
                                }
                            }}
                            sx={{ ...textInput }} InputProps={{ sx: { ...textInputProps } }}
                            FormHelperTextProps={{ sx: { ...textInputProps } }}>
                            <MenuItem key={0} value={999}>Any</MenuItem>
                            <MenuItem key={1} value={0}>Forest</MenuItem>
                            <MenuItem key={1} value={1}>Mountain</MenuItem>
                            <MenuItem key={1} value={2}>Desert</MenuItem>
                            <MenuItem key={1} value={3}>Sea</MenuItem>
                            <MenuItem key={1} value={4}>Cave</MenuItem>
                            <MenuItem key={1} value={5}>Dark</MenuItem>
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
                { !auctionContext.loading ?
                    <Stack direction="row" sx={{ ...MainStyles.container, flexWrap: "wrap" }}>
                        {
                            auctionContext.goblinList?.auctions.map((value) => (
                                <Box sx={{ m: 2 }}>
                                    <Goblin
                                        id={value.goblin.id}
                                        idToken={value.goblin.idToken}
                                        name={value.goblin.name}
                                        image={value.goblin.imageURL}
                                        size={isMobile ? SizeGoblinCard.VerySmall : SizeGoblinCard.Small}
                                        mainColor={value.goblin.skincolor}
                                        inCooldown={value.goblin.inCooldown}
                                        cooldownDate={value.goblin.cooldownDate}
                                        goblinSkillList={value.goblin.goblinSkillList}
                                        rarity={value.goblin.rarityenum}
                                        showStatus={false}
                                        status={value.goblin.status}
                                        price={value.price}
                                        onElemClick={(tokenId:number) => {
                                            history.push("/goblin?tokenId=" + tokenId);
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
                                        let param: AuctionFilterInfo = {...auctionContext.filter, page: pg };
                                        let ret = await auctionContext.searchGoblin(param);
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
            </Stack>
            { buildFilterDrawer() }
            <Snackbar open={openDialog} autoHideDuration={6000} onClose={handleClose} anchorOrigin={{ vertical: "top", horizontal: "right"}}>
                <Alert onClose={handleClose} severity={severity} sx={{ width: '100%' }}>
                    {message}
                </Alert>
            </Snackbar>
        </Stack>
    )
}