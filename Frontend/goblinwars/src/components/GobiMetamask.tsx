import { CircularProgress, Paper, Popover, Stack, SxProps, Theme, Typography } from '@mui/material'
import { useContext, useState } from 'react'
import { Link } from 'react-router-dom'
import gobiCoin from '../assets/images/coins/gobiCoinOrange.png'
import { GoblinWarsBackground } from '../dto/styles/GoblinWarsColors'
import { FontTitleSession } from '../utils/fontStyle'
import { GoblinStyles, MainStyles } from '../utils/style'

interface GobiMetamaskParam {
  cost?: number;
  balance?: number;
  loadingCost: boolean;
  text?: string;
  subtext?: string;
}

const styleBalance : SxProps<Theme> = { 
  fontSize: 24,
  ...FontTitleSession
}

export function GobiMetamask(param: GobiMetamaskParam) {

  const [anchorEl, setAnchorEl] = useState(null);

  const handleClick = (event: any) => {
    setAnchorEl(event.currentTarget);
  };

  const handleClose = () => {
    setAnchorEl(null);
  };

  const open = Boolean(anchorEl);
  const id = open ? 'gobi-popover' : undefined;


  return (
    <>
      <Stack spacing={1} sx={{ ...MainStyles.container, cursor: "pointer" }} direction={"row"} onClick={handleClick}>
        <img draggable="false"  src={gobiCoin} style={{ height: 60  }} alt={"GOBI"} />
        <Stack sx={{ ...MainStyles.container }} spacing={0}>
          {
            param.cost && !param.loadingCost ?
            <Typography sx={{ ...styleBalance }} >{param.cost}/{param.balance.toFixed(0)} {param.text}</Typography>
            : <CircularProgress />
          }
          <Typography sx={{ ...GoblinStyles.sessionSubTitleText}} >{param.subtext}</Typography>
        </Stack>
      </Stack>
      <Popover
        id={id}
        open={open}
        anchorEl={anchorEl}
        onClose={handleClose}
        anchorOrigin={{
          vertical: 'bottom',
          horizontal: 'left',
        }}
      >
        <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox }}>
          <Typography sx={{ ...GoblinStyles.sessionSubTitleText }}>
            GOBI on your Metamask.<br />
            If you don't have GOBI in your metamask, you can withdraw from your wallet. <Link to="/finance" style={{ color: "#46839e" }} >Click here to see your wallet.</Link>
            </Typography>
        </Paper>
      </Popover>
    </>
  )
}