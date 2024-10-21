import { Alert, AlertColor, Backdrop, Box, Button, CircularProgress, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle, Grid, Paper, Snackbar, Stack, Theme, Typography } from "@mui/material";
import { useContext, useEffect, useState } from "react";
import { Goblin } from "../../components/Goblin";
import SizeGoblinCard from "../../dto/enum/SizeGoblinCard";
import { GoblinStyles, MainStyles } from "../../utils/style";
import GoblinUserContext from "../../contexts/goblinUser/GoblinUserContext";
import { useHistory, useLocation } from "react-router-dom";
import { FontButton, FontTitleSession } from "../../utils/fontStyle";
import { SxProps } from "@mui/system";
import gobiCoin from '../../assets/images/coins/gobiCoinOrange.png'
import { GwViewPort } from "../../components/GwViewPort";
import { isMobile } from 'react-device-detect';
import { RarityStyles } from "../../utils/RarityStyles";
import FuseContext from "../../contexts/Fusion/FuseContext";
import MergerIcon from '../../assets/images/goblin/merger.png';
import PlusIcon from '../../assets/images/goblin/plus.png';
import ApprovedIcon from '../../assets/images/goblin/approved.png';
import { GobiMetamask } from "../../components/GobiMetamask";
import GoboxContext from "../../contexts/payment/GoboxContext";

export function Fusion() {
  let targetTokenId : number;
  let sacrificeTokenId : number;

  const fuseContext = useContext(FuseContext);
  const goblinUserContext = useContext(GoblinUserContext);
  const goboxContext = useContext(GoboxContext);

  let location = useLocation();
  const history = useHistory();

  const [open, setOpen] = useState(false);
  const [tokenRet, setTokenRet] = useState(-1);
  const [openDialog, setOpenDialog] = useState(false);
  const [message, setMessage] = useState("");
  const [severity, setSeverity] = useState<AlertColor>("success");

  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleSuccessClose = () => {
    setOpen(false);
    if(tokenRet > -1) {
      history.push("/goblin?tokenId=" + tokenRet);
    } else {
      history.push("/horde");
    }
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

  const reloadBalance = async () => {
    let ret = await goblinUserContext.loadBalance();
    if (!ret.sucesso) {
        showDialog(ret.mensagemErro, 'error');
    }
  };

  useEffect(() => {
    targetTokenId = parseInt(new URLSearchParams(location.search).get("targetTokenId"));
    sacrificeTokenId = parseInt(new URLSearchParams(location.search).get("sacrificeTokenId"));
    fuseContext.getGoblins(targetTokenId, sacrificeTokenId);
    fuseContext.getFuseCost(targetTokenId).then( async (ret) => {
      if (!ret.sucesso) {
        showDialog(ret.mensagemErro, "error");
        return;
      }
      /*
      let retApprove = await fuseContext.isGobiApproved(ret.dataResult);
      if (!retApprove.sucesso) {
        showDialog(retApprove.mensagemErro, "error");
        return;
      }
      */
    })
    //goboxContext.gobiBalanceOf();
    setTokenRet(-1);
  }, []);

  const styleBalance : SxProps<Theme> = { 
    fontSize: 24,
    ...FontTitleSession
  }

  const msgAlertText: SxProps<Theme> = {
    ...FontButton,
    fontSize: 22
}

  const msgAlert = () => {
    return (
      <Box sx={{ ...MainStyles.container, m: 1 }}>
        <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox, width: isMobile ? 350 : 750 }}>
            <Typography sx={{ ...msgAlertText }} >
              <p>The fusion creates a new goblin of higher rarity, with the same characteristics as the target goblin. Two goblins enter, a new higher rarity globin leaves</p>
              <p>Warning: This goblins will be burned, all achievements and items will be lost.</p>
            </Typography>
        </Paper>
      </Box>
    );
  }

  const buildCostBlock = () => {
    return (
      <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox, width: 300 }} elevation={6}>
        <Stack sx={{ ...MainStyles.container, width: 1 }} spacing={1}>
          <Stack spacing={0} sx={{ ...MainStyles.container }}>
            <Typography sx={{ ...styleBalance  }} >Result</Typography>
            {
              fuseContext.goblinTarget ?
              <Typography sx={{ ...GoblinStyles.textMain, color: RarityStyles.getRarityColor(fuseContext.goblinTarget.rarityenum + 1) }} >{RarityStyles.getRarityName(fuseContext.goblinTarget.rarityenum + 1)}</Typography>
              : <CircularProgress />
            }
          </Stack>
          <GobiMetamask 
            loadingCost={fuseContext.loadingCost} 
            cost={fuseContext.fuseCost}
            balance={goblinUserContext.balance?.cloudWalletGobiBalance}
            text="GOBI"
            subtext="Fusion Cost"
          />
        </Stack>
      </Paper>
    )
  }

  const buildGoblinTarget = () => {
    return (
      <>
        {
          fuseContext.goblinTarget ?
          <Stack spacing={1} sx={{ ...MainStyles.container }}>
            <Goblin
                id={fuseContext.goblinTarget.id}
                idToken={fuseContext.goblinTarget.idToken}
                name={fuseContext.goblinTarget.name}
                image={fuseContext.goblinTarget.imageURL}
                size={isMobile ? SizeGoblinCard.VerySmall : SizeGoblinCard.Big}
                mainColor={fuseContext.goblinTarget.skincolor}
                goblinSkillList={fuseContext.goblinTarget.goblinSkillList}
                rarity={fuseContext.goblinTarget.rarityenum}
                onElemClick={(tokenId:number) => {}}
            />
          </Stack>
          : <CircularProgress />
        }
      </>
    )
  }

  const buildGoblinSacrifice = () => {
    return (
      <>
        {
          fuseContext.goblinSacrifice ?
          <Stack spacing={1} sx={{ ...MainStyles.container }}>
            <Goblin
                id={fuseContext.goblinSacrifice.id}
                idToken={fuseContext.goblinSacrifice.idToken}
                name={fuseContext.goblinSacrifice.name}
                image={fuseContext.goblinSacrifice.imageURL}
                size={isMobile ? SizeGoblinCard.VerySmall : SizeGoblinCard.Big}
                mainColor={fuseContext.goblinSacrifice.skincolor}
                goblinSkillList={fuseContext.goblinSacrifice.goblinSkillList}
                rarity={fuseContext.goblinSacrifice.rarityenum}
                onElemClick={(tokenId:number) => {}}
            />
          </Stack>
          : <CircularProgress />
        }
      </>
    )
  }
  
  return (
    <GwViewPort>
      <Box sx={{ ...MainStyles.container, alignContent: "center" }}>
        <Stack sx={{...MainStyles.container, mb: 5}} spacing={2} >
          <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox, px: 3 }} elevation={6}>
              <Typography sx={{ ...GoblinStyles.sessionTitleText }} >GOBLIN FUSION</Typography>
          </Paper>
          <Stack sx={{ ...MainStyles.container, width: 350 }}>
            {
              fuseContext.goblinTarget &&
              <Typography sx={{ ...GoblinStyles.textMain }} >Target: {fuseContext.goblinTarget.name}</Typography>
            }
            <Typography sx={{ ...GoblinStyles.sessionSubTitleText, textAlign: "center"}} >It is necessary to approve both goblins to proceed with the fusion</Typography>
          </Stack>
          <Grid container sx={{ ...MainStyles.container }}>
            <Grid item xs={5} sx={{ ...MainStyles.container, justifyContent: "flex-end" }}>
              { buildGoblinTarget() }
            </Grid>
            <Grid item xs={2} sx={{ ...MainStyles.container }}>
              <Stack spacing={3}>
                <img draggable="false"  src={PlusIcon} style={{ height: 48 }} alt={"to"} />
                <img draggable="false"  src={MergerIcon} style={{ height: 48 }} alt={"to"} />
              </Stack>
            </Grid>
            <Grid item xs={5} sx={{ ...MainStyles.container, justifyContent: "flex-start" }}>
             { buildGoblinSacrifice() }
            </Grid>
          </Grid>
          { buildCostBlock() }
          <Stack direction={"row"} spacing={1}>
            <Button sx={{ ...MainStyles.mainButton, width: 180 }} 
              //disabled={!fuseContext.gobiApproved}
              onClick={() => {
              if(!fuseContext.loadingFuse)
                fuseContext.fuse().then((ret) => {
                  if(ret.sucesso) {
                    if(ret.dataResult)
                      setTokenRet(ret.dataResult);
                    handleClickOpen();
                  } else {
                    showDialog(ret.mensagemErro, "error");
                  }
                });
            }} >{fuseContext.loadingFuse ? "Fusing..." : "Start Fuse"}</Button>
          </Stack>
          { msgAlert() }
        </Stack>
      </Box>
      <Dialog
        open={open}
        onClose={handleClose}
      >
        <DialogTitle>
          {"Fusion complete !"}
        </DialogTitle>
        <DialogContent>
          <DialogContentText>
            Congratulations, fusion successfully completed
          </DialogContentText>
        </DialogContent>
        <DialogActions>
          <Button onClick={handleSuccessClose}>Yay !</Button>
        </DialogActions>
      </Dialog>
      <Snackbar open={openDialog} autoHideDuration={6000} onClose={handleClose} anchorOrigin={{ vertical: "top", horizontal: "right"}}>
          <Alert onClose={handleClose} severity={severity} sx={{ width: '100%' }}>
              {message}
          </Alert>
      </Snackbar>
      {
        fuseContext.loadingFuse && 
        <Backdrop
            sx={{ color: '#fff', zIndex: (theme) => 99 }}
            open={true}
        >
            <CircularProgress color="inherit" />
        </Backdrop>
      }
    </GwViewPort> 
  )
}