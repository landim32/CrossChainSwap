import { Alert, AlertColor, Backdrop, Box, Button, CircularProgress, Dialog, Divider, Grid, IconButton, MenuItem, Pagination, PaginationItem, Paper, Snackbar, Stack, SwipeableDrawer, SxProps, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, TextField, Theme, Toolbar, Typography } from "@mui/material";
import { useContext, useEffect, useState } from "react";
import { GwViewPort } from "../../components/GwViewPort";
import { MainStyles, GoblinStyles } from "../../utils/style";
import { BrowserView, MobileView, isBrowser, isMobile } from 'react-device-detect';
import { useHistory, useLocation } from "react-router";
import FinanceContext from "../../contexts/finance/FinanceContext";
import gobiCoin from '../../assets/images/coins/gobiCoin.png';
import pancakeIcon from '../../assets/images/pancakeswap.png';
import gobiCoinOrange from '../../assets/images/coins/gobiCoinOrange.png';
import { DepositForm } from "./DepositForm";
import { WithdrawalForm } from "./WithdrawalForm";
import Moment from "moment";
// @ts-ignore
import MiddleEllipsis from "react-middle-ellipsis";
import Web3 from "web3";
import GoblinUserContext from "../../contexts/goblinUser/GoblinUserContext";

const textFinance = {
    ...GoblinStyles.textMain,
    fontSize: isMobile ? 16 : 22
}


export function Finance() {

    let location = useLocation();
    const financeContext = useContext(FinanceContext);
    const goblinUserContext = useContext(GoblinUserContext);

    const [openDialog, setOpenDialog] = useState<boolean>(false);
    const [message, setMessage] = useState("");
    const [severity, setSeverity] = useState<AlertColor>("success");
    const [depositDialog, setDepositDialog] = useState(false);
    const [withdrawalDialog, setWithdrawalDialog] = useState(false);

    const openDepositDialog = () => {
        setDepositDialog(true);
    };
    const closeDepositDialog = () => {
        setDepositDialog(false);
    };

    const openWithdrawalDialog = () => {
        setWithdrawalDialog(true);
    };
    const closeWithdrawalDialog = () => {
        setWithdrawalDialog(false);
    };

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

    const updateFinance = () => {
        financeContext.getFinance().then((ret) => {
            if (ret.sucesso) {
                goblinUserContext.loadBalance();
                financeContext.list(1).then((ret) => {
                    if (!ret.sucesso) {
                        showDialog(ret.mensagemErro, 'error');
                    }
                });
            }
            else {
                showDialog(ret.mensagemErro, "error");
            }
        });
    };

    useEffect(() => {
        updateFinance();
    }, [ location ]);

    const widthBase = isMobile ? 350 : 850

    return (
        <GwViewPort>
            <Stack spacing={3} sx={{ ...MainStyles.container, m: 2 }}>
                {
                    financeContext.finance &&
                    <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox, width: widthBase }}>
                        <Grid sx={{ ...MainStyles.container }} container spacing={2}>
                            <Grid item xs={12}>
                                <Typography sx={{ ...textFinance, textAlign: "center"}}>FINANCE</Typography>
                                <Divider />
                            </Grid>
                            {
                                !isMobile &&
                                <>
                                    <Grid item xs={3}>
                                        <Typography sx={{ ...textFinance, textAlign: "right"}}>Address:</Typography>
                                    </Grid>
                                    <Grid item xs={9}>
                                        <Typography sx={{ ...textFinance, textAlign: "left"}}>{financeContext.finance?.publicaddress}</Typography>
                                    </Grid>
                                </>
                            }
                            <MobileView>
                                <Grid item xs={12} sx={{ ...MainStyles.container, my: 1 }} >
                                    <Stack sx={{ ...MainStyles.container, width: 1, pl: 1.5 }}>
                                        <Typography sx={{ ...textFinance}}>{financeContext.finance?.publicaddress}</Typography>
                                        <Typography sx={{ ...GoblinStyles.sessionSubTitleText}}>Wallet Address</Typography>
                                    </Stack>
                                </Grid>
                            </MobileView>
                            <Grid item xs={isMobile ? 6 : 3}>
                                <Typography sx={{ ...textFinance, textAlign: "right"}}>CloudWallet Balance:</Typography>
                            </Grid>
                            <Grid item xs={isMobile ? 6 : 3}>
                                <Stack direction={"row"} spacing={1} sx={{ ...MainStyles.container, justifyContent: "flex-start" }}>
                                    <img draggable="false"  src={gobiCoin} style={{width: "35px", height: "35px"}} />
                                    <Typography sx={{ ...textFinance, textAlign: "left"}}>{financeContext.finance?.gobioncloudwallet.toFixed(4)}</Typography>
                                </Stack>
                            </Grid>
                            <Grid item xs={isMobile ? 6 : 3}>
                                <Typography sx={{ ...textFinance, textAlign: "right"}}>Metamask Balance:</Typography>
                            </Grid>
                            <Grid item xs={isMobile ? 6 : 3}>
                                <Stack direction={"row"} spacing={1} sx={{ ...MainStyles.container, justifyContent: "flex-start" }}>
                                    <img draggable="false"  src={gobiCoinOrange} style={{width: "35px", height: "35px"}} />
                                    <Typography sx={{ ...textFinance, textAlign: "left"}}>{financeContext.finance?.gobionmetamask}</Typography>
                                </Stack>
                            </Grid>
                            <Grid item xs={12} sx={{ ...MainStyles.container }}>
                                <Typography sx={{ ...GoblinStyles.textMain, textAlign: "right"}}>Token Bridge</Typography>
                            </Grid>
                            <Grid item xs={12}>
                                <Stack direction={"row"} spacing={3} sx={{ ...MainStyles.container, flexWrap: "wrap" }}>
                                    <Button sx={{ ...MainStyles.mainButton, width: isMobile ? 150 : 200 }} onClick={openDepositDialog}><Typography sx={{ ...textFinance, textAlign: "left"}}>Deposit GOBI</Typography></Button>
                                    <Button sx={{ ...MainStyles.mainButton, width: isMobile ? 150 : 200 }} 
                                        disabled={!financeContext.finance?.canwithdrawal} 
                                        onClick={openWithdrawalDialog}><Typography sx={{ ...textFinance, textAlign: "left"}}>Withdrawal GOBI</Typography></Button>
                                    <Button sx={{ p: isMobile ? 2 : 0 }} onClick={() => window.open("https://pancakeswap.finance/swap?outputCurrency=0x02b976553528e6e4E4adE644A1d0418179eEd3fb", "_blank")}>
                                        <img draggable="false"  src={pancakeIcon} style={{width: isMobile ? "200px" : "220px" }} />
                                    </Button>
                                </Stack>
                            </Grid>
                            <Grid item xs={12} sx={{ ...MainStyles.container }}>
                                <Typography sx={{ ...GoblinStyles.textMain, textAlign: "left"}}>
                                Note: To activate the withdrawal, it is necessary to deposit 400 GOBI, buy at least one GOBOX and open at least one GOBOX.
                                </Typography>
                            </Grid>
                        </Grid>
                    </Paper>
                }
                {!financeContext.loadingTransaction ?
                    <Stack spacing={1} sx={{ ...MainStyles.container, p: 0, width: isMobile ? widthBase : "auto"}}>
                        <Typography sx={{ ...textFinance }}>Transactions</Typography>
                        <BrowserView>
                            <TableContainer sx={{ ...MainStyles.floatingBox }}>
                                <Table aria-label="customized table">
                                <TableHead>
                                    <TableRow>
                                        <TableCell><Typography sx={{ ...textFinance, fontSize: 18, textAlign: "center" }}>Date (GMT)</Typography></TableCell>
                                        <TableCell><Typography sx={{ ...textFinance, fontSize: 18, textAlign: "center" }}>Credit</Typography></TableCell>
                                        <TableCell><Typography sx={{ ...textFinance, fontSize: 18, textAlign: "center" }}>Debit</Typography></TableCell>
                                        <TableCell><Typography sx={{ ...textFinance, fontSize: 18, textAlign: "center" }}>Fee</Typography></TableCell>
                                        <TableCell><Typography sx={{ ...textFinance, fontSize: 18, textAlign: "center" }}>Balance</Typography></TableCell>
                                        <TableCell><Typography sx={{ ...textFinance, fontSize: 18, textAlign: "center" }}>Message</Typography></TableCell>
                                        <TableCell><Typography sx={{ ...textFinance, fontSize: 18, textAlign: "center" }}>Transaction</Typography></TableCell>
                                        <TableCell><Typography sx={{ ...textFinance, fontSize: 18, textAlign: "center" }}>Status</Typography></TableCell>
                                        <TableCell><Typography sx={{ ...textFinance, fontSize: 18, textAlign: "center" }}>Success</Typography></TableCell>
                                    </TableRow>
                                </TableHead>
                                <TableBody>
                                    {financeContext.transactions?.transactions.map((row) => (
                                    <TableRow key={row.id}>
                                        <TableCell component="td" scope="row">
                                            <Typography sx={{ ...GoblinStyles.sessionSubTitleText, textAlign: "center"}}>
                                                {Moment(row.insertdate).format("MM/DD/YYYY [at] HH:mm:ss")}
                                            </Typography>
                                        </TableCell>
                                        <TableCell component="td" scope="row">
                                            <Typography sx={{ ...GoblinStyles.sessionSubTitleText, textAlign: "center"}}>
                                                {row.credit.toFixed(4)}
                                            </Typography>
                                        </TableCell>
                                        <TableCell component="td" scope="row">
                                            <Typography sx={{ ...GoblinStyles.sessionSubTitleText, textAlign: "center"}}>
                                                {row.debit.toFixed(4)}
                                            </Typography>
                                        </TableCell>
                                        <TableCell component="td" scope="row">
                                            <Typography sx={{ ...GoblinStyles.sessionSubTitleText, textAlign: "center"}}>
                                                {row.fee?.toFixed(4)}
                                            </Typography>
                                        </TableCell>
                                        <TableCell component="td" scope="row">
                                            <Typography sx={{ ...GoblinStyles.sessionSubTitleText, textAlign: "center"}}>
                                                {row.balance.toFixed(4)}
                                            </Typography>
                                        </TableCell>
                                        <TableCell component="td" scope="row">
                                            <Typography sx={{ ...GoblinStyles.sessionSubTitleText, textAlign: "center"}}>
                                                {row.message}
                                            </Typography>
                                        </TableCell>
                                        <TableCell component="td" scope="row">
                                            <Typography sx={{ ...GoblinStyles.sessionSubTitleText, width: 150, textAlign: "center"}}>
                                                <MiddleEllipsis>
                                                    <a href={"https://bscscan.com/tx/" + row.txhash} target={"_blank"}>{row.txhash}</a>
                                                </MiddleEllipsis>
                                            </Typography>
                                        </TableCell>
                                        <TableCell component="td" scope="row">
                                            <Typography sx={{ ...GoblinStyles.sessionSubTitleText, textAlign: "center"}}>
                                                {row.statusmsg}
                                            </Typography>
                                        </TableCell>
                                        <TableCell component="td" scope="row">
                                            <Typography sx={{ ...GoblinStyles.sessionSubTitleText, textAlign: "center"}}>
                                                {row.success ? "Yes" : "No"}
                                            </Typography>
                                        </TableCell>
                                    </TableRow>
                                    ))}
                                </TableBody>
                                </Table>
                            </TableContainer>
                        </BrowserView>
                        <MobileView>
                            <Stack sx={{ ...MainStyles.container }} spacing={1} >
                                {
                                    financeContext.transactions?.transactions.map((row) => (
                                        <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox }}>
                                            <Stack sx={{ ...MainStyles.container }}>
                                                <Grid sx={{ ...MainStyles.container }} container >
                                                    <Grid sx={{ ...MainStyles.container }} item xs={4} >
                                                        <Typography sx={{ ...textFinance, textAlign: "right", width: 1}}>Date (GMT):</Typography>
                                                    </Grid>
                                                    <Grid sx={{ ...MainStyles.container }} item xs={8} >
                                                        <Typography sx={{ ...GoblinStyles.sessionSubTitleText, textAlign: "left"}}>{Moment(row.insertdate).format("MM/DD/YYYY [at] HH:mm:ss")}</Typography>
                                                    </Grid>
                                                    <Grid sx={{ ...MainStyles.container }} item xs={4} >
                                                        <Typography sx={{ ...textFinance, textAlign: "right", width: 1}}>Credit:</Typography>
                                                    </Grid>
                                                    <Grid sx={{ ...MainStyles.container }} item xs={8} >
                                                        <Typography sx={{ ...GoblinStyles.sessionSubTitleText, textAlign: "left"}}>{row.credit}</Typography>
                                                    </Grid>
                                                    <Grid sx={{ ...MainStyles.container }} item xs={4} >
                                                        <Typography sx={{ ...textFinance, textAlign: "right", width: 1}}>Debit:</Typography>
                                                    </Grid>
                                                    <Grid sx={{ ...MainStyles.container }} item xs={8} >
                                                        <Typography sx={{ ...GoblinStyles.sessionSubTitleText, textAlign: "left"}}>{row.debit}</Typography>
                                                    </Grid>
                                                    <Grid sx={{ ...MainStyles.container }} item xs={4} >
                                                        <Typography sx={{ ...textFinance, textAlign: "right", width: 1}}>Message:</Typography>
                                                    </Grid>
                                                    <Grid sx={{ ...MainStyles.container }} item xs={8} >
                                                        <Typography sx={{ ...GoblinStyles.sessionSubTitleText, textAlign: "left"}}>{row.message}</Typography>
                                                    </Grid>
                                                    <Grid sx={{ ...MainStyles.container }} item xs={4} >
                                                        <Typography sx={{ ...textFinance, textAlign: "right", width: 1}}>Fee:</Typography>
                                                    </Grid>
                                                    <Grid sx={{ ...MainStyles.container }} item xs={8} >
                                                        <Typography sx={{ ...GoblinStyles.sessionSubTitleText, textAlign: "left"}}>{row.fee}</Typography>
                                                    </Grid>
                                                    <Grid sx={{ ...MainStyles.container }} item xs={4} >
                                                        <Typography sx={{ ...textFinance, textAlign: "right", width: 1}}>Transaction:</Typography>
                                                    </Grid>
                                                    <Grid sx={{ ...MainStyles.container }} item xs={8} >
                                                        <Typography sx={{ ...GoblinStyles.sessionSubTitleText, width: 230, textAlign: "center"}}>
                                                            <MiddleEllipsis>
                                                                <a href={"https://bscscan.com/tx/" + row.txhash} target={"_blank"}>{row.txhash}</a>
                                                            </MiddleEllipsis>
                                                        </Typography>
                                                    </Grid>
                                                    <Grid sx={{ ...MainStyles.container }} item xs={4} >
                                                        <Typography sx={{ ...textFinance, textAlign: "right", width: 1}}>Status:</Typography>
                                                    </Grid>
                                                    <Grid sx={{ ...MainStyles.container }} item xs={8} >
                                                        <Typography sx={{ ...GoblinStyles.sessionSubTitleText, textAlign: "left"}}>{row.statusmsg}</Typography>
                                                    </Grid>
                                                    <Grid sx={{ ...MainStyles.container }} item xs={4} >
                                                        <Typography sx={{ ...textFinance, textAlign: "right", width: 1}}>Success:</Typography>
                                                    </Grid>
                                                    <Grid sx={{ ...MainStyles.container }} item xs={8} >
                                                        <Typography sx={{ ...GoblinStyles.sessionSubTitleText, textAlign: "left"}}>{row.success ? "Yes" : "No"}</Typography>
                                                    </Grid>
                                                </Grid>
                                            </Stack>
                                        </Paper>
                                    ))
                                }
                            </Stack>
                        </MobileView>
                        <Stack direction="row" sx={{ ...MainStyles.container, flexWrap: "wrap" }}>
                            
                            {financeContext.transactions && 
                            <Box sx={{ ...MainStyles.container, width: 1 }}>
                                <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox, p: 1 }}>
                                    <Pagination 
                                        count={financeContext.transactions.totalpages} 
                                        page={financeContext.transactions.page} 
                                        onChange={(event: object, pg: number) => {
                                            financeContext.list(pg).then((ret) => {
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
                {
                    !financeContext.finance &&
                    <Backdrop
                        sx={{ color: '#fff', zIndex: (theme) => 99 }}
                        open={true}
                    >
                        <CircularProgress color="inherit" />
                    </Backdrop>
                }
            </Stack>
            <Dialog open={depositDialog} keepMounted onClose={closeDepositDialog}>
                <DepositForm deposit={ async (value: number) => {
                    let ret = await financeContext.deposit(value);
                    if (ret.sucesso) {
                        closeDepositDialog();
                        updateFinance();
                    }
                    else {
                        showDialog(ret.mensagemErro, 'error');
                    }
                }}
                close={closeDepositDialog} 
                valueGobi={financeContext.finance?.gobionmetamask}
                loading={financeContext.loadingDeposit} 
                />
            </Dialog>
            <Dialog open={withdrawalDialog} keepMounted onClose={closeWithdrawalDialog}>
                <WithdrawalForm 
                withdrawl={ async (value: number) => {
                    let ret = await financeContext.withdrawl(value);
                    if (ret.sucesso) {
                        closeWithdrawalDialog();
                        updateFinance();
                    }
                    else {
                        showDialog(ret.mensagemErro, 'error');
                    }
                }}
                calculateFee={ async (value: number) => {
                    let ret = await financeContext.calculateFee(value);
                    if (!ret.sucesso) {
                        showDialog(ret.mensagemErro, 'error');
                        closeWithdrawalDialog();
                    }
                }}
                close={closeWithdrawalDialog} 
                currentFee={financeContext.currentFee}
                finance={financeContext.finance}
                loading={financeContext.loadingWithdraw} 
                loadingCalculate={financeContext.loadingCalculate} 
                />
            </Dialog>
            <Snackbar open={openDialog} autoHideDuration={6000} onClose={handleClose} anchorOrigin={{ vertical: "top", horizontal: "right"}}>
                <Alert onClose={handleClose} severity={severity} sx={{ width: '100%' }}>
                    {message}
                </Alert>
            </Snackbar>
        </GwViewPort>
    )
}