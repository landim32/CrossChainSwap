import { Stack, Box } from "@mui/material";
import { useState } from "react";
import { BrowserView, MobileView } from "react-device-detect";
import { GwViewPort } from "../../components/GwViewPort";
import MarketingTabs from "../../components/MarketingTabs";
import { MainStyles } from "../../utils/style";
import { MarketplaceEquipment } from "./equipment";
import { MarketplaceGoblin } from "./goblin";
import { MarketplaceGobox } from "./gobox";
import { GoblinNft } from "./nft";

export function Marketplace() {
    const [view, setView] = useState<number>(0);

    return (
        <GwViewPort>
            <Box sx={{ width: 1 }}>
                <BrowserView>
                    <Stack sx={{ alignContent: "flex-start", alignItems: "flex-start", width: "90vw"  }} direction={"row"} spacing={1.5} >
                        <MarketingTabs setView={setView} />
                        <Box sx={{ width: "100%" }}>
                            {
                                view == 0 &&
                                <MarketplaceGoblin />
                            }
                            {
                                view == 1 &&
                                <MarketplaceEquipment />
                            }
                            {
                                view == 2 &&
                                <MarketplaceGobox />
                            }
                            {
                                view == 3 &&
                                <GoblinNft />
                            }
                        </Box>
                    </Stack>
                </BrowserView>
                <MobileView>
                    <Stack sx={{ ...MainStyles.container, width: 1 }} spacing={1} >
                        <MarketingTabs setView={setView} />
                        <Box sx={{ width: "100%" }}>
                            {
                                view == 0 &&
                                <MarketplaceGoblin />
                            }
                            {
                                view == 1 &&
                                <MarketplaceEquipment />
                            }
                            {
                                view == 2 &&
                                <MarketplaceGobox />
                            }
                            {
                                view == 3 &&
                                <GoblinNft />
                            }
                        </Box>
                    </Stack>
                </MobileView>
            </Box>
        </GwViewPort>
    )
}