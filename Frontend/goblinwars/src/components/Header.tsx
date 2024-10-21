import React, { useContext, useEffect, useState } from 'react';
import logoImage from '../assets/logo.png';
import { Alert, AppBar, Box, Button, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle, IconButton, Menu, MenuItem, Modal, Paper, Snackbar, Stack, Theme, Toolbar, Tooltip, Typography } from '@mui/material';
import { makeStyles } from '@mui/styles';
import AuthContext from '../contexts/auth/AuthContext';
import { useHistory } from 'react-router-dom'; 
import ServiceFactory from '../services/ServiceFactory';
import { UserInfo } from './UserInfo';
import { BuyGoblin } from './BuyGoblin';
import { ValidateEmail } from '../utils/utils';
import { GoblinStyles, MainStyles } from '../utils/style';
import GoblinUserContext from '../contexts/goblinUser/GoblinUserContext';
import { LoginButton } from '../pages/Start/LoginButton';
import AvatarIcon from '../assets/images/avatar.png'
import GoblinContext from '../contexts/goblin/GoblinContext';
import MenuIcon from '@mui/icons-material/Menu';
import { GobiBalance } from './GobiBalance';
import { GoldBalance } from './GoldBalance';
// @ts-ignore
import MiddleEllipsis from "react-middle-ellipsis";
import useInterval from '@use-it/interval';

const sizeProfile = 40;

const useStyles = makeStyles(() => ({
    toolbar: {
        display: "flex",
        justifyContent: "space-between",
        backgroundColor: 'rgb(99,145,83)',
        background: 'linear-gradient(45deg, rgba(99,145,83,1) 0%, rgba(43,52,33,1) 80%)'
    },
    logo: {
        marginLeft: 15,
        height: 80
    }
}));



interface HeaderParam {
    isMobile?: boolean;
    drawerWidth?: number;
    handleDrawerToggle?: () => void;
}

export function Header(props: HeaderParam) {
    const goblinContext = useContext(GoblinContext);
    const authContext = useContext(AuthContext);
    const goblinUserContext = useContext(GoblinUserContext);
    
    const history = useHistory();
    ServiceFactory.setLogoffCallback(authContext.logout);

    const { toolbar, logo } = useStyles();

    const [anchorEl, setAnchorEl] = useState(null);
    const open = Boolean(anchorEl);

    const handleClick = (event: any) => {
        setAnchorEl(event.currentTarget);
    };
    const handleClose = () => {
        setAnchorEl(null);
    };

    const [openDialog, setOpenDialog] = useState(false);
    const [errMessage, setErrMessage] = useState("");

    const [showUserInfo, setShowUserInfo] = useState(false);
    const openUserInfo = () => {
        setShowUserInfo(true);
    }
    const closeUserInfo = () => {
        setShowUserInfo(false);
    }

    const handleCloseSnack = (ev: any) => {
        if (ev?.reason === 'clickaway') {
        return;
        }

        setOpenDialog(false);
    };

    const [openSuccess, setOpenSuccess] = useState(false);
    const handleOpenSuccess = () => {
        setOpenSuccess(true);
    };
    
    const handleSuccessClose = () => {
        setOpenSuccess(false);
        history.push("/home");
        goblinContext.listGoblins(true);
    };

    const logout = async () => {
        handleClose();
        let logoutResult = authContext.logout();
        if(logoutResult.sucesso) {
            history.push("/login");
        } else {
            window.alert(logoutResult.mensagemErro);
        }
    }

    useInterval(() => {
        goblinUserContext.loadBalance();
    }, 150000);
    
    useEffect(() => {
        authContext.loadUserSession();
        goblinUserContext.loadBalance();
    }, [])
    
    

    const getItensCoins = () => {
        return (
            <Stack direction="row" spacing={2} sx={{ ...MainStyles.container }} >
                <GoldBalance />
                <GobiBalance />
            </Stack>
        )
    }

    const displayDesktop = () => {
        return (
            <Toolbar className={toolbar} >
                <Stack direction="row" spacing={1} sx={{ ...MainStyles.container }}>
                    { props.isMobile && 
                        <IconButton
                            color="inherit"
                            aria-label="open drawer"
                            edge="start"
                            onClick={props.handleDrawerToggle}
                            sx={{ mr: 2, display: { sm: 'none' } }}
                        >
                            <MenuIcon sx={{ color: "white" }} fontSize='large' />
                        </IconButton>
                    }
                    <img draggable="false"  className={logo} src={logoImage} alt={"Goblin Wars"} style={{ marginBottom: -40 }} />
                </Stack>
                {
                    authContext.sessionInfo ?
                        <Stack direction={"row"}>
                            {!props.isMobile && getItensCoins()}
                            <Tooltip title="Profile">
                                <Box sx={{ ...MainStyles.container, height: sizeProfile, width: 140, ml: 2, mr: 1, position: "relative", mt: 0.5, cursor: "pointer" }} 
                                    onClick={handleClick} >
                                    <Box sx={{ ...MainStyles.container, position: "absolute", height: "30px", borderRadius: 2, width: 130, 
                                        pr: 0.8, pl: (sizeProfile + 5) + "px", justifyContent: "flex-end", right: 0 }} 
                                        style={{ background: "linear-gradient(261deg, #5c261b 0%, #2b211f 100%)" }} >
                                        <Box sx={{ ...MainStyles.container, height: 24, width: 120 }} >
                                            <MiddleEllipsis>
                                                <Typography noWrap sx={{ ...GoblinStyles.sessionTitleText, fontSize: 14 }} >{authContext.sessionInfo.publicAddress}</Typography>
                                            </MiddleEllipsis>
                                        </Box>
                                    </Box>
                                    <img draggable="false"  src={AvatarIcon} alt={"profile"} style={{ width: sizeProfile, borderRadius: sizeProfile/2, position: "absolute", left: 0 }} />
                                </Box>
                            </Tooltip> 
                            <Menu
                                id="basic-menu"
                                anchorEl={anchorEl}
                                open={open}
                                onClose={handleClose}
                                MenuListProps={{
                                'aria-labelledby': 'basic-button',
                                }}
                            >
                                <MenuItem onClick={openUserInfo}>Profile</MenuItem>
                                <MenuItem onClick={logout}>Logout</MenuItem>
                            </Menu>
                        </Stack>
                    :  <LoginButton msgErrorCb={function (msg: string): void {
                            setErrMessage(msg);
                            setOpenDialog(true);
                        } } />
                }
                
                <Snackbar open={openDialog} autoHideDuration={6000} onClose={handleCloseSnack} anchorOrigin={{ vertical: "top", horizontal: "right"}}>
                    <Alert onClose={handleCloseSnack} severity="error" sx={{ width: '100%' }}>
                        {errMessage}
                    </Alert>
                </Snackbar>
                <Dialog
                    open={showUserInfo}
                    keepMounted
                    onClose={closeUserInfo}
                >
                    <UserInfo name={authContext.sessionInfo?.name} email={authContext.sessionInfo?.email} registerCb={ async (name: string, email: string) => {
                        if(ValidateEmail(email)){
                            const ret = await authContext.updateUser(name, email);
                            if(!ret.sucesso) {
                                setErrMessage(ret.mensagemErro);
                                setOpenDialog(true);
                            } else {
                                closeUserInfo();
                            }
                        } else {
                            setErrMessage("Invalid email address");
                            setOpenDialog(true);
                        }
                    } } loading={authContext.loading} btnText={"Save"} btnLoadingText={"Saving..."} />
                </Dialog>
                <Dialog
                    open={openSuccess}
                    onClose={handleCloseSnack}
                >
                    <DialogTitle>
                        {"Success !"}
                    </DialogTitle>
                    <DialogContent>
                    <DialogContentText>
                        Great! You get a new Goblin!!!
                    </DialogContentText>
                    </DialogContent>
                    <DialogActions>
                        <Button onClick={handleSuccessClose}>Yay !</Button>
                    </DialogActions>
                </Dialog>
                
            </Toolbar>
        );
      };
      
      return (
        props?.isMobile ?
        <AppBar elevation={7} color={"transparent"}>{displayDesktop()}</AppBar>
        :
        <AppBar elevation={7} color={"transparent"} sx={{
            width: { sm: `calc(100% - ${props?.drawerWidth || 0}px)` },
            ml: { sm: `${props?.drawerWidth || 0}px` },
        }}>{displayDesktop()}</AppBar>
      );
} 