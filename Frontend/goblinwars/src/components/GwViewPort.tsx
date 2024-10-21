import { Box, CssBaseline, Drawer, Fab, Menu, MenuItem, Stack, Theme } from '@mui/material';
import { makeStyles } from '@mui/styles';
import { SxProps } from '@mui/system';
import { useEffect, useState } from 'react';
import { BrowserView, MobileView, isBrowser, isMobile } from 'react-device-detect';
import { GoblinWarsBackground, GoblinWarsColors } from '../dto/styles/GoblinWarsColors';
import { MainStyles } from '../utils/style';
import { GwDrawer } from './GwDrawer';
import { Header } from './Header';
import BgMobile from "../assets/images/bg.jpg";
import MoreVertIcon from '@mui/icons-material/MoreVert';
import { useHistory } from 'react-router-dom';
import ReactGA from "react-ga";

interface GwViewPortParam {
  children?: any;
}

const useStyles = makeStyles({
  paper: {
    background: "linear-gradient(180deg, rgba(99,145,83,1) 0%, rgba(43,52,33,1) 100%)"
  }
})

const fabStyle : SxProps<Theme> = {
  position: 'absolute',
  bottom: isMobile ? 8 : 16,
  right: isMobile ? 8 : 16,
};

const drawerWidth = 240;
const drawerMinimized = 80;

export function GwViewPort(props: GwViewPortParam) {
  const container = window.document.body;
  const classes = useStyles();
  const [drawerOpen, setDrawerOpen] = useState(false);
  const history = useHistory();

  const handleDrawerToggle = () => {
    setDrawerOpen(!drawerOpen);
  };

  const [anchorEl, setAnchorEl] = useState(null);
  const open = Boolean(anchorEl);

  const handleClick = (event: any) => {
      setAnchorEl(event.currentTarget);
  };
  const handleClose = () => {
      setAnchorEl(null);
  };

  useEffect(() => {
    ReactGA.pageview(window.location.pathname);
  }, []);

  return (
    <Stack sx={{ ...MainStyles.container }} >
      <CssBaseline />
      <BrowserView>
        <Header isMobile={false} drawerWidth={(drawerOpen ? drawerWidth : drawerMinimized)} />
        <Box sx={{ width: 1 }} >
          <Drawer
            variant="permanent"
            classes={{ paper: classes.paper }}
            sx={{
              display: { xs: 'none', sm: 'block' },
              '& .MuiDrawer-paper': { boxSizing: 'border-box', width: (drawerOpen ? drawerWidth : drawerMinimized) },
              color: "red"
            }}
            open
          >
            <GwDrawer isMobile={false} showDrawer={handleDrawerToggle} hideDrawer={handleDrawerToggle} hided={!drawerOpen} />
          </Drawer>
          <Box sx={{ margin: "13vh 0 0 0;", width: { sm: `calc(100% - ${(drawerOpen ? drawerWidth : drawerMinimized)}px)` }, ml: { sm: `${(drawerOpen ? drawerWidth : drawerMinimized)}px` } }}>
            
              {props.children}
            
          </Box>
        </Box>
      </BrowserView>
      <MobileView>
        <img draggable="false"  src={BgMobile} style={{ position: "fixed", top: 0, height: "100vh", zIndex: -1 }} />
        <Header isMobile={true}  handleDrawerToggle={handleDrawerToggle} />
        <Drawer
          container={container}
          variant="temporary"
          open={drawerOpen}
          onClose={handleDrawerToggle}
          classes={{ paper: classes.paper }}
          ModalProps={{
            keepMounted: true, // Better open performance on mobile.
          }}
          sx={{
            display: { xs: 'block', sm: 'none' },
            '& .MuiDrawer-paper': { boxSizing: 'border-box', width: drawerWidth },
          }}
        >
          <GwDrawer isMobile={true} showDrawer={handleDrawerToggle} hideDrawer={handleDrawerToggle} hided={!drawerOpen}  />
        </Drawer>
        <Box sx={{ ...MainStyles.container, margin: "13vh 0 0 0;" }}>
          {props.children}
        </Box>
      </MobileView>
      {/*<Fab sx={{ ...fabStyle }} color={"primary"} onClick={handleClick} >
        <MoreVertIcon sx={{color: "white"}}  />
      </Fab>
      <Menu
          id="basic-menu"
          anchorEl={anchorEl}
          open={open}
          onClose={handleClose}
          MenuListProps={{
          'aria-labelledby': 'basic-button',
          }}
      >
          <MenuItem onClick={() => {
            history.push("/whitelist");
          }}>Whitelist</MenuItem>
        </Menu>*/}
    </Stack>
  )
}