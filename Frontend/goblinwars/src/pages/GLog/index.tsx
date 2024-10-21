import { Alert, AlertColor, Box, Button, CircularProgress, Divider, IconButton, MenuItem, Pagination, PaginationItem, Paper, Snackbar, Stack, SwipeableDrawer, SxProps, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, TextField, Theme, Toolbar, Typography } from "@mui/material";
import { useContext, useEffect, useState } from "react";
import { GwViewPort } from "../../components/GwViewPort";
import { MainStyles, GoblinStyles } from "../../utils/style";
import { BrowserView, MobileView, isBrowser, isMobile } from 'react-device-detect';
import { useHistory, useLocation } from "react-router";
import GLogContext from "../../contexts/glog/GLogContext";
import { GoblinWarsColors } from "../../dto/styles/GoblinWarsColors";
import Moment from 'moment';
import gobiCoin from '../../assets/images/coins/gobiCoin.png';
import MarketplaceIcon from '../../assets/images/menu/marketplace.png';
import PickaxeIcon from '../../assets/images/menu/pickaxe.png';
import InfoIcon from '@mui/icons-material/Info';
import QuestIcon from '../../assets/images/menu/quests.png';
import JobsIcon from '../../assets/images/menu/jobs.png';
import ItensIcon from '../../assets/images/menu/inventory.png';

export function GLog() {

    let location = useLocation();
    const glogContext = useContext(GLogContext);

    const [openDialog, setOpenDialog] = useState<boolean>(false);
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
        glogContext.list(1).then((ret) => {
            if (!ret.sucesso) {
                showDialog(ret.mensagemErro, 'error');
            }
        });
    }, [ location ]);

    const getLogIcon = (type: string) => {
        const size = 22;
        switch(type){
            case "Recharge":
                return <img draggable="false"  src={gobiCoin} style={{ height: size }} />;
            case "Finance":
                return <img draggable="false"  src={gobiCoin} style={{ height: size }} />;
            case "Auction":
                return <img draggable="false"  src={MarketplaceIcon} style={{ height: size }} />;
            case "Mining":
                return <img draggable="false"  src={PickaxeIcon} style={{ height: size }} />;
            case "Quest":
                return <img draggable="false"  src={QuestIcon} style={{ height: size }} />;
            case "Job":
                return <img draggable="false"  src={JobsIcon} style={{ height: size }} />;
            case "Item":
                return <img draggable="false"  src={ItensIcon} style={{ height: size }} />;
            default:
                return <InfoIcon fontSize="medium" sx={{ color: GoblinWarsColors.titleColor }} />
        }
    }


    return (
        <GwViewPort>
            {!glogContext.loading ?
            <Stack spacing={1} sx={{ ...MainStyles.container, p: 0, mb: 5}}>
                <TableContainer >
                    <Table sx={{ maxWidth: isMobile ? 350 : 750, ...MainStyles.floatingBox }} >
                        <TableHead sx={{ bgcolor: GoblinWarsColors.darkBox }}>
                            <TableRow>
                                <TableCell sx={{ width: isMobile ? 120 : 230 }}>
                                    <Typography sx={{ ...GoblinStyles.textMain, width: 1, textAlign: "center" }}>Date (GMT)</Typography>
                                </TableCell>
                                <TableCell>
                                    <Typography sx={{ ...GoblinStyles.textMain, width: 1, textAlign: "center" }}>Message</Typography>
                                </TableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {glogContext.glogList?.logs.map((row) => (
                                <TableRow key={row.idlog}>
                                    <TableCell component="td" scope="row">
                                        <Typography sx={{ ...GoblinStyles.sessionSubTitleText, fontSize: 16 }}>{Moment(row.insertdate).format("MM/DD/YYYY [at] HH:mm:ss")}</Typography>
                                    </TableCell>
                                    <TableCell component="td" scope="row">
                                        <Stack direction={"row"} spacing={0.5} sx={{ ...MainStyles.container }}>
                                            {
                                                getLogIcon(row.logtype)
                                            }
                                            <Typography sx={{ ...GoblinStyles.infoTextMain, width: 1, textAlign: "center" }}>{row.message}</Typography>
                                        </Stack>
                                    </TableCell>
                                </TableRow>
                            ))}
                        </TableBody>
                    </Table>
                </TableContainer>
                <Stack direction="row" sx={{ ...MainStyles.container, flexWrap: "wrap" }}>
                    
                    {glogContext.glogList && 
                    <Box sx={{ ...MainStyles.container, width: 1 }}>
                        <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox, p: 1 }}>
                            <Pagination 
                                count={glogContext.glogList.totalpages} 
                                page={glogContext.glogList.page} 
                                onChange={(event: object, pg: number) => {
                                    glogContext.list(pg).then((ret) => {
                                        if (!ret.sucesso) {
                                            showDialog(ret.mensagemErro, 'error');
                                        }
                                    });
                                }} renderItem={(item)=> <PaginationItem {...item} sx={{ ...GoblinStyles.sessionSubTitleText }} /> }
                            />
                        </Paper>
                    </Box>
                    }
                </Stack>
            </Stack>
                : <CircularProgress />
            }
            <Snackbar open={openDialog} autoHideDuration={6000} onClose={handleClose} anchorOrigin={{ vertical: "top", horizontal: "right"}}>
                <Alert onClose={handleClose} severity={severity} sx={{ width: '100%' }}>
                    {message}
                </Alert>
            </Snackbar>
        </GwViewPort>
    )
}