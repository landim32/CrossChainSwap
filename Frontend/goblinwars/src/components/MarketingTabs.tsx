import { Button, Stack, styled, Typography, Tabs, Tab, Paper, Box } from "@mui/material";
import { useHistory } from "react-router";
import { GoblinStyles, MainStyles } from "../utils/style";
import FilterIcon from '../assets/images/marketplace/filter.png'
import { GoblinWarsColors } from "../dto/styles/GoblinWarsColors";
import { BrowserView, MobileView } from "react-device-detect";
import { useState } from "react";

interface EquipmentParam {
    setView: (value: number) => void;
}

const MarketingStyledTabs = styled((props: any) => (
    <Tabs
        {...props}
        TabIndicatorProps={{ children: <span className="MuiTabs-indicatorSpan" /> }}
    />
    ))({
    '& .MuiTabs-indicator': {
        display: 'flex',
        justifyContent: 'center',
        backgroundColor: 'transparent',
    },
    '& .MuiTabs-indicatorSpan': {
        maxWidth: 55,
        width: '100%',
        backgroundColor: GoblinWarsColors.titleColor,
    },
    '& .MuiTabs-scrollButtons': {
        color: GoblinWarsColors.titleColor
    }
  });
  
  const MarketingStyledTab = styled((props: any) => 
    <Tab disableRipple {...props} />)(
    ({ theme }) => ({
        textTransform: 'none',
        fontSize: 18,
        fontFamily: "Yeon Sung",
        color: GoblinWarsColors.titleColor,
        fontWeight: "bold",
        textShadow: "0px 2px 1px #000000,1px 1px 0px #000000;",
        opacity: 0.6,
        '&.Mui-selected': {
            fontSize: 24,
            opacity: 1,
            fontFamily: "Yeon Sung",
            color: GoblinWarsColors.buttonFontColor,
            fontWeight: "bold",
            textShadow: "0px 5px 4px #191719,1px 1px 0px #181813, rgb(61, 59, 46) 3px 0px 0px, rgb(61, 59, 46) 2.83487px 0.981584px 0px, rgb(61, 59, 46) 2.35766px 1.85511px 0px, rgb(61, 59, 46) 1.62091px 2.52441px 0px, rgb(61, 59, 46) 0.705713px 2.91581px 0px, rgb(61, 59, 46) -0.287171px 2.98622px 0px, rgb(61, 59, 46) -1.24844px 2.72789px 0px, rgb(61, 59, 46) -2.07227px 2.16926px 0px, rgb(61, 59, 46) -2.66798px 1.37182px 0px, rgb(61, 59, 46) -2.96998px 0.42336px 0px, rgb(61, 59, 46) -2.94502px -0.571704px 0px, rgb(61, 59, 46) -2.59586px -1.50383px 0px, rgb(61, 59, 46) -1.96093px -2.27041px 0px, rgb(61, 59, 46) -1.11013px -2.78704px 0px, rgb(61, 59, 46) -0.137119px -2.99686px 0px, rgb(61, 59, 46) 0.850987px -2.87677px 0px, rgb(61, 59, 46) 1.74541px -2.43999px 0px, rgb(61, 59, 46) 2.44769px -1.73459px 0px, rgb(61, 59, 46) 2.88051px -0.838247px 0px;"
        }
    }),
  );

export default function MarketingTabs(param: EquipmentParam) {
  const [indexTab, setIndexTab] = useState<number>(0);
  const history = useHistory();

  const handleChange = (event : any, newValue : number) => {
    setIndexTab(newValue);
    param.setView(newValue);
  };

  return (
    <>
    <BrowserView>
        <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox, width: 250, background: "linear-gradient(180deg, rgba(99,145,83,1) 0%, rgba(43,52,33,1) 100%)" }}>
            <MarketingStyledTabs value={indexTab} onChange={handleChange} orientation="vertical" >
                <MarketingStyledTab label="Goblins" />
                <MarketingStyledTab label="Equipments"  />
                <MarketingStyledTab label="Boxes" />
                <MarketingStyledTab label="Import/Export NFT" />
            </MarketingStyledTabs>
        </Paper>
    </BrowserView>
    <MobileView>
        <Box sx={{ ...MainStyles.container, width: 350 }}>
            <MarketingStyledTabs value={indexTab} onChange={handleChange} variant="scrollable" scrollButtons allowScrollButtonsMobile >
                <MarketingStyledTab label="Goblins" />
                <MarketingStyledTab label="Equipments"  />
                <MarketingStyledTab label="Boxes" />
                <MarketingStyledTab label="Import/Export NFT" />
            </MarketingStyledTabs>
        </Box>
    </MobileView>
    </>
  )
}