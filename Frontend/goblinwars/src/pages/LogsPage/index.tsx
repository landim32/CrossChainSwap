import { Stack } from "@mui/material";
import { DevPages } from "../../components/DevPage";
import { GwViewPort } from "../../components/GwViewPort";
import { Header } from "../../components/Header";
import { MainStyles } from "../../utils/style";

export function Logs() {
    return (
        <GwViewPort>
            <DevPages text={
                        <div>
                            <p>
                                Any action performed in the game can be followed here.
                                For more information access our whitepaper on <a target={"_blank"} 
                                href={"https://whitepaper.goblinwars.io/roadmap"}
                                style={{ color: "#46839e" }}>roadmap</a> area.
                            </p>
                        </div>
            } 
             title={"Logs - Coming soon"} />
        </GwViewPort>
    )
}