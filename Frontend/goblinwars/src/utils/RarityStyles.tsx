import Particles, { IShapeValues, RecursivePartial, SingleOrMultiple } from "react-tsparticles";
import { RarityEnum } from "../dto/enum/RarityEnum";
import ShineLegendary from "../assets/images/goblin/shiningLegendary.png";
import ShineEpic from "../assets/images/goblin/shiningEpic.png";
import ShineRare from "../assets/images/goblin/shiningRare.png";
import ShineUncommon from "../assets/images/goblin/shiningUncommon.png";

const commonColor = "#a9a9a9";
const uncommonColor = "#1EFF0C";
const rareColor = "#0070FF";
const epicColor = "#A335EE";
const legendaryColor = "#FF8000";

const getRarityColor = (rarity: RarityEnum) => {
  switch(rarity) {
    case RarityEnum.Common:
      return commonColor;
    case RarityEnum.Uncommon:
      return uncommonColor;
    case RarityEnum.Rare:
      return rareColor;
    case RarityEnum.Epic:
      return epicColor;
    case RarityEnum.Legendary:
      return legendaryColor;
  }
};

const getRarityName = (rarity: RarityEnum) => {
  switch(rarity) {
    case RarityEnum.Common:
      return "COMMON";
    case RarityEnum.Uncommon:
      return "UNCOMMON";
    case RarityEnum.Rare:
      return "RARE";
    case RarityEnum.Epic:
      return "EPIC";
    case RarityEnum.Legendary:
      return "LEGENDARY";
  }
}

const getBaseEffect = (height: number, width: number, color: string, imageShine: string, bubbleCount: number, lineDistance: number, id: string) => {
  return <Particles
    id={id}
    width={(width - 5) + "px"}
    height={(height - 5) + "px"}
    options={{
      fullScreen: {
        enable: false
      },
      fpsLimit: 60,
      particles: {
        number: {
          value: bubbleCount,
          density: {
            enable: false
          }
        },
        color: {
          value: color
        },
        opacity: {
          value: 1,
          random: true,
          anim: { enable: true, speed: 1, opacity_min: 0.3, sync: false }
        },
        size: {
          value: 6,
          animation: {
              enable: true,
              speed: 1,
              minimumValue: 2,
              sync: false
          }
        },
        move: {
          enable: true,
          direction: "none",
          speed: 0.1,
          outMode: "bounce"
        },
        line_linked: {
          enable: true,
          distance: lineDistance,
          color: color,
          opacity: 0.8,
          width: 1,
          shadow: {
            blur: 12,
            color: color,
            enable: true
          }
        },
        shape: {
          options: {
            image: {
              height: 32,
              src: imageShine,
              width: 32
            }
          },
          type: "image"
        },
      },
      detectRetina: true,
      
    }}
  />
}

const getGoblinMiningEffect = (height: number, width: number, color: string, imageShine: string, bubbleCount: number, lineDistance: number, id: string) => {
  return <Particles
    id={id}
    width={(width - 5) + "px"}
    height={(height - 5) + "px"}
    options={{
      fullScreen: {
        enable: false
      },
      fpsLimit: 60,
      particles: {
        number: {
          value: bubbleCount,
          density: {
            enable: false
          }
        },
        color: {
          value: color
        },
        opacity: {
          value: 1,
          random: true,
          anim: { enable: true, speed: 1, opacity_min: 0.3, sync: false }
        },
        size: {
          value: 6,
          animation: {
              enable: true,
              speed: 1,
              minimumValue: 2,
              sync: false
          }
        },
        move: {
          enable: true,
          direction: "top",
          speed: 0.1,
          outMode: "out"
        },
        line_linked: {
          enable: true,
          distance: lineDistance,
          color: color,
          opacity: 0.8,
          width: 1,
          shadow: {
            blur: 12,
            color: color,
            enable: true
          }
        },
        shape: {
          options: {
            image: {
              height: 32,
              src: imageShine,
              width: 32
            }
          },
          type: "image"
        },
      },
      detectRetina: true,
      
    }}
  />
}

const getCardEffect = (height: number, width: number, rarity: RarityEnum, id: string) => {
  switch(rarity) {
    case RarityEnum.Common:
      return <></>;
    case RarityEnum.Uncommon:
      return getBaseEffect(height, width, uncommonColor, ShineUncommon, 40, 15, id);
    case RarityEnum.Rare:
      return getBaseEffect(height, width, rareColor, ShineRare, 80, 15, id);
    case RarityEnum.Epic:
      return getBaseEffect(height, width, epicColor, ShineEpic, 120, 15, id);
    case RarityEnum.Legendary:
      return getBaseEffect(height, width, legendaryColor, ShineLegendary, 250, 15, id);
  }
}

const getMiningEffect = (height: number, width: number, rarity: RarityEnum, id: string) => {
  switch(rarity) {
    case RarityEnum.Common:
      return <></>;
    case RarityEnum.Uncommon:
      return getGoblinMiningEffect(height, width, uncommonColor, ShineUncommon, 10, 2, id);
    case RarityEnum.Rare:
      return getGoblinMiningEffect(height, width, rareColor, ShineRare, 20, 2, id);
    case RarityEnum.Epic:
      return getGoblinMiningEffect(height, width, epicColor, ShineEpic, 40, 2, id);
    case RarityEnum.Legendary:
      return getGoblinMiningEffect(height, width, legendaryColor, ShineLegendary, 80, 2, id);
  }
}

const RarityStyles = {
  getRarityColor,
  getRarityName,
  getCardEffect,
  getMiningEffect,
};

export { RarityStyles }