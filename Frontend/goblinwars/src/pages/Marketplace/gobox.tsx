import { Alert, AlertColor, Box, Button, CircularProgress, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle, Divider, IconButton, MenuItem, Pagination, PaginationItem, Paper, Snackbar, Stack, SwipeableDrawer, SxProps, TextField, Theme, Toolbar, Typography, styled, Tabs, Tab, Fade } from "@mui/material";
import { useContext, useEffect, useState } from "react";
import { GwViewPort } from "../../components/GwViewPort";
import AuctionContext from "../../contexts/auction/AuctionContext";
import { MainStyles, GoblinStyles } from "../../utils/style";
import { BrowserView, MobileView, isBrowser, isMobile } from 'react-device-detect';
import { useHistory, useLocation } from "react-router";
import { makeStyles } from "@mui/styles";
import HideIcon from '../../assets/images/menu/show.png'
import FilterIcon from '../../assets/images/marketplace/filter.png'
import MarketplaceIcon from '../../assets/images/menu/marketplace.png'
import GoboxCard from "../../components/GoboxCard";
import AuctionInfo from "../../dto/domain/AuctionInfo";
import { GoblinWarsColors } from "../../dto/styles/GoblinWarsColors";
import { RarityStyles } from "../../utils/RarityStyles";
import { RarityEnum } from "../../dto/enum/RarityEnum";
import MarketingTabs from "../../components/MarketingTabs";
import { DefaultTabs, DefaultTab } from "../../components/GwTabs";

const textInput : SxProps<Theme> = {
    width: 1,
  }
  
  const textInputProps : SxProps<Theme> = {
    ...GoblinStyles.sessionSubTitleText
  }

const useStyles = makeStyles({
    paper: {
        background: "linear-gradient(180deg, rgba(99,145,83,1) 0%, rgba(43,52,33,1) 100%)"
    }
})

export function MarketplaceGobox() {
    const classes = useStyles();

    let location = useLocation();
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
            auctionContext.listByAuction(2, 1).then((ret) => {
                if (!ret.sucesso) {
                    showDialog(ret.mensagemErro, 'error');
                }
            });
        }
        else {
            showDialog(ret.mensagemErro, "error");
        }
    };

    useEffect(() => {
        auctionContext.listByAuction(2, 1).then((ret) => {
            if (!ret.sucesso) {
                showDialog(ret.mensagemErro, 'error');
            }
        });
        auctionContext.listByUser(2).then((ret) => {
            if (!ret.sucesso) {
                showDialog(ret.mensagemErro, 'error');
            }
        });
    }, [ location ]);

    return (
        <Stack sx={{ ...MainStyles.container }}>
            <Stack direction={"row"} sx={{ ...MainStyles.container }} spacing={1} >
                <img draggable="false"  src={MarketplaceIcon} style={{ height: 30 }} />
                <Typography sx={{ ...GoblinStyles.sessionTitleText }} >MARKETPLACE</Typography>
            </Stack>
            <Stack>
                <DefaultTabs value={value} onChange={handleChange} centered >
                    <DefaultTab label="All Boxes" />
                    <DefaultTab label="My Boxes for Sale"  />
                </DefaultTabs>
                <Fade in={value == 0}>
                    { !auctionContext.loading && value == 0 ?
                        <Stack direction="row" sx={{ ...MainStyles.container, flexWrap: "wrap" }}>
                            {
                                auctionContext.auctionList?.auctions.map((value) => (
                                    <Box sx={{ m: 2 }}>
                                        <GoboxCard
                                            auction={value}
                                            boxType={value.boxtype}
                                            loading={auctionContext.loadingAction}
                                            buy={(auction) => {
                                                showAlert(auction.id);
                                            }} 
                                        />
                                    </Box>
                                ))
                            }
                            {auctionContext.auctionList && 
                            <Box sx={{ ...MainStyles.container, width: 1 }}>
                                <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox, p: 1 }}>
                                    <Pagination 
                                        count={auctionContext.auctionList.totalpages} 
                                        page={auctionContext.auctionList.page} 
                                        onChange={ async (event: object, pg: number) => {
                                            let ret = await auctionContext.listByAuction(2, pg);
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
                                auctionContext.myAuctionList?.auctions.map((value) => (
                                    <Box sx={{ m: 2 }}>
                                        <GoboxCard
                                            auction={value}
                                            boxType={value.boxtype}
                                            loading={auctionContext.loadingAction}
                                            cancel={ async (auction) => {
                                                let ret = await auctionContext.cancel(value.id);
                                                if (!ret.sucesso) {
                                                    showDialog(ret.mensagemErro, 'error');
                                                    return;
                                                }
                                                let retUser = await auctionContext.listByUser(2);
                                                if (!retUser.sucesso) {
                                                    showDialog(retUser.mensagemErro, 'error');
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