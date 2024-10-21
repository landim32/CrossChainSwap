import React, { useContext, useEffect, useState } from 'react';
import { motion } from "framer-motion";
import { Box, Button, CircularProgress, Fab, Menu, MenuItem, Paper, Stack, Theme, Typography } from '@mui/material';
import { Goblin } from '../../components/Goblin';
import GoblinContext from '../../contexts/goblin/GoblinContext';
import { useHistory, useLocation } from 'react-router-dom';
import SizeGoblinCard from '../../dto/enum/SizeGoblinCard';
import { MainStyles, SocialStyles, GoblinStyles } from '../../utils/style';
import { SxProps } from '@mui/system';
import { FontButton } from '../../utils/fontStyle';
import FacebookIcon from '@mui/icons-material/Facebook';
import TwitterIcon from '@mui/icons-material/Twitter';
import TelegramIcon from '@mui/icons-material/Telegram';
import DiscordIcon from '../../assets/images/social/discord.png';
import { GwViewPort } from '../../components/GwViewPort';
import InfiniteScroll from 'react-infinite-scroll-component';
import { isMobile } from 'react-device-detect';
import { StatusEnum } from '../../dto/enum/StatusEnum';
import Gobox3 from '../../assets/images/box/gobox3.png';

const list = {
    visible: {
        opacity: 1,
        transition: {
            when: "beforeChildren",
            staggerChildren: 0.15,
            delayChildren: 0.25,
        },
    },
    hidden: {
        opacity: 0,
        transition: {
            when: "afterChildren",
        },
    },
}

const items = {
    visible: { opacity: 1, x: 0 },
    hidden: { opacity: 0, x: -150 },
}

const msgEmptyTitle : SxProps<Theme> = {
    ...FontButton,
    fontSize: 22
}

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

const fabStyle : SxProps<Theme> = {
    position: 'fixed',
    bottom: isMobile ? 8 : 16,
    right: isMobile ? 8 : 16,
    height: 80,
    width: 80
  };

let showNotice = true;

export function Home(props : any) {
    const goblinContext = useContext(GoblinContext);
    let query = new URLSearchParams(useLocation().search);
    const history = useHistory();
    const [loadMore, setLoadMore] = useState(true);

    const [anchorEl, setAnchorEl] = useState(null);
    const open = Boolean(anchorEl);

    const handleClick = (event: any) => {
        //setAnchorEl(event.currentTarget);
        history.push("/buy-gobox");
    };
    const handleClose = () => {
        setAnchorEl(null);
    };

    const msgEmpty = () => {
        return (
            <Box sx={{ ...MainStyles.container, width: isMobile ? 350 : 500, mb: 2 }}>
                <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox, p: 1 }}>
                    <Stack sx={{ ...MainStyles.container }}>
                        <Typography sx={{ ...msgEmptyTitle }} >
                                <p>
                                    Welcome, Warchielf!
                                </p>
                                <p>
                                You don't any goblin. You can buy new goblins from the marketplace or by buying an GOBOX.<br />
                                </p>
                        </Typography>
                        <Stack direction={"row"} sx={{ ...MainStyles.container }} spacing={1}>
                            <Button sx={{ ...MainStyles.mainButton }} onClick={() => (history.push("/marketplace"))} >Marketplace</Button>
                            <Button sx={{ ...MainStyles.mainButton }} onClick={() => (history.push("/buy-gobox"))}>Buy Gobox</Button>
                        </Stack>
                        <Typography sx={{ ...msgEmptyTitle }} >
                            <p>
                            Keep an eye on our social networks, we are doing promotions where you can win some.
                            </p>
                        </Typography>
                        <Stack direction="row" sx={{ ...MainStyles.container, alignContent: "center", flexWrap: "wrap" }}>
                            <Button sx={{ ...SocialStyles.DiscordButton }} onClick={() => {
                                window.open("https://discord.gg/nZr46yy2hs");
                            }} >
                                <Stack direction="row" spacing={1} sx={{ ...MainStyles.container, width: 1 }}>
                                    <img draggable="false"  src={DiscordIcon} style={{ height: 18 }} alt={"Discord"} />
                                    <Typography sx={{ ...SocialStyles.SocialText }} >Discord</Typography>
                                </Stack>
                            </Button>
                            <Button sx={{ ...SocialStyles.TelegranButton }} onClick={() => {
                                window.open("https://t.me/GoblinWarsOfficial");
                            }}>
                                <Stack direction="row" spacing={1} sx={{ ...MainStyles.container, width: 1 }}>
                                    <TelegramIcon sx={{ ...SocialStyles.SocialIcon }} fontSize={"medium"} />
                                    <Typography sx={{ ...SocialStyles.SocialText }} >Telegram</Typography>
                                </Stack>
                            </Button>
                            <Button sx={{ ...SocialStyles.TwitterButton }} onClick={() => {
                                window.open("https://twitter.com/GoblinWarsNFT");
                            }}>
                                <Stack direction="row" spacing={1} sx={{ ...MainStyles.container, width: 1 }}>
                                    <TwitterIcon sx={{ ...SocialStyles.SocialIcon }} fontSize={"medium"} />
                                    <Typography sx={{ ...SocialStyles.SocialText }} >Twitter</Typography>
                                </Stack>
                            </Button>
                            <Button sx={{ ...SocialStyles.FacebookButton }} onClick={() => {
                                window.open("https://www.facebook.com/goblinwarsofficial/");
                            }}>
                                <Stack direction="row" spacing={1} sx={{ ...MainStyles.container, width: 1 }}>
                                    <FacebookIcon sx={{ ...SocialStyles.SocialIcon }} fontSize={"medium"} />
                                    <Typography sx={{ ...SocialStyles.SocialText }} >Facebook</Typography>
                                </Stack>
                            </Button>
                        </Stack>
                    </Stack>
                </Paper>
            </Box>
        );
    }

    useEffect(() => {
        goblinContext.listGoblins(true).then((ret) => {
            if(ret)
                setLoadMore(ret.sucesso);
        })
    }, []);

    return (
        <GwViewPort>
            <motion.ul
            style={{
                display: 'flex',
                flexWrap: 'wrap',
                listStyleType: 'none',
                paddingInlineStart: '0px',
                marginBlockStart: '0px',
                marginBlockEnd: '0px',
                alignItems: 'center',
                justifyContent: 'center',
            }}
            initial="hidden"
            animate="visible"
            variants={list}>
                <Stack sx={{ ...MainStyles.container }} >
                    <InfiniteScroll
                        style={{ display: "flex", flexWrap: "wrap", alignItems: "center", alignContent: "center", justifyContent: "center", overflowX: "hidden" }}
                        dataLength={goblinContext.goblins.length}
                        scrollableTarget="scrollableDiv"
                        next={async () => {
                            var ret = await goblinContext.listGoblins(false);
                            if(ret)
                                setLoadMore(ret.sucesso);
                        }}
                        hasMore={loadMore}
                        loader={<Box></Box>}
                        endMessage={
                            goblinContext.goblins.length > 0 ? 
                            <Box sx={{ width: 1 }}>
                                <Stack direction={"row"} sx={{ ...MainStyles.container, pb: 4, pt: 1 }} spacing={1}>
                                <Typography variant={"subtitle1"} color="white" >No more goblins for fetch !</Typography>
                                </Stack>
                            </Box>
                            : msgEmpty()
                        }
                    >
                        {
                        goblinContext.goblins && goblinContext.goblins.length > 0 && goblinContext.goblins.map((value) => (
                            
                            <motion.li variants={items} key={value.id}>
                                <Box sx={{ ...MainStyles.container, m: 2 }} key={value.id} >
                                    <Goblin
                                        id={value.id}
                                        idToken={value.idToken}
                                        name={value.name}
                                        image={value.imageURL}
                                        size={SizeGoblinCard.Big}
                                        mainColor={value.skincolor}
                                        inCooldown={value.inCooldown}
                                        cooldownDate={value.cooldownDate}
                                        goblinSkillList={value.goblinSkillList}
                                        rarity={value.rarityenum}
                                        showStatus={true}
                                        status={!value.isavaliable ? value.status : StatusEnum.Avaliable}
                                        onElemClick={(tokenId:number) => {
                                            history.push("/goblin?tokenId=" + tokenId);
                                        }}
                                    />
                                </Box>
                            </motion.li>
                        ))
                    }
                    </InfiniteScroll>
                    {
                        loadMore && !goblinContext.loading.list && 
                        <Button onClick={async () => {
                            var ret = await goblinContext.listGoblins(false);
                            if(ret)
                                setLoadMore(ret.sucesso);
                        }} sx={{ ...MainStyles.mainButton, width: 150 }}>Load more</Button>
                    }
                    {
                        goblinContext.loading.list && getLoadingBlock()
                    }
                </Stack>
            </motion.ul>
            <Fab sx={{ ...fabStyle }} color={"primary"} onClick={handleClick} >
                <Box sx={{ ...MainStyles.container, position: "relative" }} >
                    <img draggable="false"  src={Gobox3} style={{ height: 50 }} />
                    <Typography sx={{ ...GoblinStyles.textMain, position: "absolute", bottom: 0, fontSize: 15 }} >On Sale</Typography>
                </Box>
            </Fab>
        </GwViewPort>
    )
}


