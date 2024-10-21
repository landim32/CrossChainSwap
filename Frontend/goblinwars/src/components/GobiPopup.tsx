import { Box, Button, Paper, Stack, Dialog, Slide, Theme, IconButton, Typography, Modal } from "@mui/material";
import { makeStyles } from "@mui/styles";
import { SxProps } from "@mui/system";
import { useState } from "react";
import React from "react";
import { MainStyles, GoblinStyles, SocialStyles } from '../utils/style';
import { OulinedInput } from "./OutlinedInput";
import FacebookIcon from '@mui/icons-material/Facebook';
import TwitterIcon from '@mui/icons-material/Twitter';
import TelegramIcon from '@mui/icons-material/Telegram';
import DiscordIcon from '../assets/images/social/discord.png';
import CloseIcon from '@mui/icons-material/Close';
import { GoblinWarsBackground } from "../dto/styles/GoblinWarsColors";

interface GobiPopupParam {
    open: boolean;
    close: () => void;
}

const noticeTitle : SxProps<Theme> = {
    ...GoblinStyles.sessionTitleText,
    fontSize: 26
  }
  const textStyle : SxProps<Theme> = {
    ...GoblinStyles.infoTextMain,
    fontSize: 22,
    pl: 1,
    pr: 1,
    textAlign: "justify"
  }

export function GobiPopup(param: GobiPopupParam) {

    const Transition = React.forwardRef(function Transition(props : any, ref) {
        return <Slide direction="up" ref={ref} {...props} />;
      });
  return (
        <Dialog
        open={param.open}
        TransitionComponent={Transition}
        keepMounted
        onClose={param.close}
        >
        <Box sx={{ background: GoblinWarsBackground.containerBackground  }}>
            <Paper sx={{ ...GoblinStyles.sessionTitle }}>
            <Stack direction={"row"} sx={{ display: "flex", justifyContent: "space-between" }}>
            <Typography sx={{ ...noticeTitle }} >GOBI Balance</Typography>
                <IconButton onClick={param.close}>
                    <CloseIcon sx={{ color: "white" }} fontSize={"medium"} />
                </IconButton>
                </Stack>
            </Paper>
            <Stack sx={{ ...MainStyles.container, p: 1 }}>
            <Typography sx={{ ...textStyle, pb: 2 }}>
                <div>
                    <p>
                        Stay connected to our social networks. We are always distributing GOBI tokens 
                        in promotions and airdrops. We will soon be announcing our whitelist and 
                        pre-sale.
                    </p>
                    <Stack direction="row" sx={{ ...MainStyles.container, alignContent: "center", flexWrap: "wrap" }}>
                        <Button sx={{ ...SocialStyles.DiscordButton, m: 1 }} onClick={() => {
                            window.open("https://discord.gg/nZr46yy2hs");
                        }} >
                            <Stack direction="row" spacing={1} sx={{ ...MainStyles.container, width: 1 }}>
                                <img draggable="false"  src={DiscordIcon} style={{ height: 18 }} alt={"Discord"} />
                                <Typography sx={{ ...SocialStyles.SocialText }} >Discord</Typography>
                            </Stack>
                        </Button>
                        <Button sx={{ ...SocialStyles.TelegranButton, m: 1 }} onClick={() => {
                            window.open("https://t.me/GoblinWarsOfficial");
                        }}>
                            <Stack direction="row" spacing={1} sx={{ ...MainStyles.container, width: 1 }}>
                                <TelegramIcon sx={{ ...SocialStyles.SocialIcon }} fontSize={"medium"} />
                                <Typography sx={{ ...SocialStyles.SocialText }} >Telegram</Typography>
                            </Stack>
                        </Button>
                        <Button sx={{ ...SocialStyles.TwitterButton, m: 1 }} onClick={() => {
                            window.open("https://twitter.com/GoblinWarsNFT");
                        }}>
                            <Stack direction="row" spacing={1} sx={{ ...MainStyles.container, width: 1 }}>
                                <TwitterIcon sx={{ ...SocialStyles.SocialIcon }} fontSize={"medium"} />
                                <Typography sx={{ ...SocialStyles.SocialText }} >Twitter</Typography>
                            </Stack>
                        </Button>
                        <Button sx={{ ...SocialStyles.FacebookButton, m: 1 }} onClick={() => {
                            window.open("https://www.facebook.com/goblinwarsofficial/");
                        }}>
                            <Stack direction="row" spacing={1} sx={{ ...MainStyles.container, width: 1 }}>
                                <FacebookIcon sx={{ ...SocialStyles.SocialIcon }} fontSize={"medium"} />
                                <Typography sx={{ ...SocialStyles.SocialText }} >Facebook</Typography>
                            </Stack>
                        </Button>
                    </Stack>
                </div>
            </Typography>
            </Stack>
        </Box>
        </Dialog>
    )
}