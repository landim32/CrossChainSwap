import { Alert, AlertColor, Box, CircularProgress, Modal, Paper, Snackbar, Stack, Typography } from "@mui/material";
import { useContext, useEffect, useState } from "react";
import { Goblin } from "../../components/Goblin";
import GoblinContext from "../../contexts/goblin/GoblinContext";
import { GoblinInfo } from "../../dto/domain/GoblinInfo";
import SizeGoblinCard from "../../dto/enum/SizeGoblinCard";
import { GoblinStyles, MainStyles } from "../../utils/style";
import { Header } from "../../components/Header";
import { useHistory, useLocation } from "react-router-dom";
import InfiniteScroll from "react-infinite-scroll-component";
import { GwViewPort } from "../../components/GwViewPort";


const getLoadingBlock = () => {
  return (
    <Box sx={{ width: 1 }}>
      <Stack direction={"row"} sx={{ ...MainStyles.container, pb: 4, pt: 1 }} spacing={1}>
        <CircularProgress />
        <Typography variant={"subtitle1"} color="white" >Loading...</Typography>
      </Stack>
    </Box>
  );
}


export function BreedList() {
  const goblinContext = useContext(GoblinContext);
  const [loadMore, setLoadMore] = useState(true);

  const [openDialog, setOpenDialog] = useState(false);
  const [message, setMessage] = useState("");
  const [severity, setSeverity] = useState<AlertColor>("success");

  let location = useLocation();
  const history = useHistory();

  useEffect(() => {
    let tokenId = parseInt(new URLSearchParams(location.search).get("idToken"));
    //alert(tokenId);
    //alert(JSON.stringify(goblinContext.goblin.idToken));
    //if(!goblinContext.goblin || goblinContext.goblin.idToken !== tokenId)
    //{
      //alert("entrou");
    goblinContext.myGoblin(tokenId).then((ret) => {
      if (!ret.sucesso) {
        showDialog(ret.mensagemErro, "error");
        return;
      }
      goblinContext.listSpouseCandidates(tokenId, true).then((ret) => {
        setLoadMore(ret.sucesso);
      });
    });
    //}
      
  }, []);

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
  
  return (
    <GwViewPort >
      <Stack sx={{ ...MainStyles.container }}>
        {
          goblinContext.goblin ?
          <Box sx={{ ...MainStyles.container }}>
              <Goblin
                id={goblinContext.goblin.id}
                idToken={goblinContext.goblin.idToken}
                name={goblinContext.goblin.name}
                image={goblinContext.goblin.imageURL}
                size={SizeGoblinCard.Big}
                mainColor={goblinContext.goblin.skincolor}
                goblinSkillList={goblinContext.goblin.goblinSkillList}
                rarity={goblinContext.goblin.rarityenum}
                onElemClick={(tokenId:number) => {}}
              />
          </Box>
          : <CircularProgress />
        }
        <Box sx={{ ...MainStyles.container, p: 3, width: 1 }} >
          <Paper sx={{ ...GoblinStyles.sessionDivider }} elevation={6}>
            <Stack spacing={0}>
              <Typography sx={{ ...GoblinStyles.sessionTitleText }} >BREED</Typography>
              <Typography sx={{ ...GoblinStyles.sessionSubTitleText }} >Select an goblin for breed<br />Warning: Cannot breed goblins that are on cooldown, mining or available on the marketplace.</Typography>
            </Stack>
          </Paper>
        </Box>
        {
          goblinContext.goblin ?
            <InfiniteScroll
              style={{ padding: 1, margin: 1, display: "flex", flexWrap: "wrap", alignItems: "center", alignContent: "center", justifyContent: "center" }}
              dataLength={goblinContext.spouseCandidates?.length}
              next={async () => {
                var ret = await goblinContext.listSpouseCandidates(goblinContext.goblin.idToken, false);
                setLoadMore(ret.sucesso);
              }}
              hasMore={loadMore}
              loader={ goblinContext.loading.breedCandidates && getLoadingBlock()
              }
              endMessage={
                <Box sx={{ width: 1 }}>
                  <Stack direction={"row"} sx={{ ...MainStyles.container, pb: 4, pt: 1 }} spacing={1}>
                    <Typography variant={"subtitle1"} color="white" >No more goblins for fetch !</Typography>
                  </Stack>
                </Box>
              }
            >
              {
                goblinContext.spouseCandidates && goblinContext.spouseCandidates.length > 0 ? goblinContext.spouseCandidates.map((value) => (
                <Box sx={{ ...MainStyles.container, m: 2 }}>
                  <Goblin
                      id={value.id}
                      idToken={value.idToken}
                      name={value.name}
                      image={value.imageURL}
                      size={SizeGoblinCard.Big}
                      mainColor={value.skincolor}
                      goblinSkillList={value.goblinSkillList}
                      rarity={value.rarityenum}
                      onElemClick={(tokenId:number) => {
                        history.push("/breed?idToken1=" + goblinContext.goblin.idToken + "&idToken2=" + tokenId);
                      }}
                  />
                </Box>
              )) : getLoadingBlock()
            }
            </InfiniteScroll>
          : <CircularProgress />
        }
      </Stack>
      <Snackbar open={openDialog} autoHideDuration={6000} onClose={handleClose} anchorOrigin={{ vertical: "top", horizontal: "right"}}>
          <Alert onClose={handleClose} severity={severity} sx={{ width: '100%' }}>
              {message}
          </Alert>
      </Snackbar>
    </GwViewPort>
  )
}