import CaveEars from "../assets/images/genes/cave-ears.png";
import CaveEyes from "../assets/images/genes/cave-eyes.png";
import CaveHair from "../assets/images/genes/cave-hair.png";
import CaveMouth from "../assets/images/genes/cave-mouth.png";
import CaveRace from "../assets/images/genes/cave-race.png";
import CaveSkin from "../assets/images/genes/cave-skin.png";

import DarkEars from "../assets/images/genes/dark-ears.png";
import DarkEyes from "../assets/images/genes/dark-eyes.png";
import DarkHair from "../assets/images/genes/dark-hair.png";
import DarkMouth from "../assets/images/genes/dark-mouth.png";
import DarkRace from "../assets/images/genes/dark-race.png";
import DarkSkin from "../assets/images/genes/dark-skin.png";

import DesertEars from "../assets/images/genes/desert-ears.png";
import DesertEyes from "../assets/images/genes/desert-eyes.png";
import DesertHair from "../assets/images/genes/desert-hair.png";
import DesertMouth from "../assets/images/genes/desert-mouth.png";
import DesertRace from "../assets/images/genes/desert-race.png";
import DesertSkin from "../assets/images/genes/desert-skin.png";

import ForestEars from "../assets/images/genes/forest-ears.png";
import ForestEyes from "../assets/images/genes/forest-eyes.png";
import ForestHair from "../assets/images/genes/forest-hair.png";
import ForestMouth from "../assets/images/genes/forest-mouth.png";
import ForestRace from "../assets/images/genes/forest-race.png";
import ForestSkin from "../assets/images/genes/forest-skin.png";

import MountainEars from "../assets/images/genes/mountain-ears.png";
import MountainEyes from "../assets/images/genes/mountain-eyes.png";
import MountainHair from "../assets/images/genes/mountain-hair.png";
import MountainMouth from "../assets/images/genes/mountain-mouth.png";
import MountainRace from "../assets/images/genes/mountain-race.png";
import MountainSkin from "../assets/images/genes/mountain-skin.png";

import SeaEars from "../assets/images/genes/sea-ears.png";
import SeaEyes from "../assets/images/genes/sea-eyes.png";
import SeaHair from "../assets/images/genes/sea-hair.png";
import SeaMouth from "../assets/images/genes/sea-mouth.png";
import SeaRace from "../assets/images/genes/sea-race.png";
import SeaSkin from "../assets/images/genes/sea-skin.png";

import { GoblinRace } from "../dto/enum/GoblinRace";

const RaceImages = {
  getRaceEars: (race: GoblinRace) : string => {
    switch(race) {
      case(GoblinRace.CAVE):
        return CaveEars;
      case(GoblinRace.DARK):
        return DarkEars;
      case(GoblinRace.DESERT):
        return DesertEars;
      case(GoblinRace.FOREST):
        return ForestEars;
      case(GoblinRace.MOUNTAIN):
        return MountainEars;
      case(GoblinRace.SEA):
        return SeaEars;
    }
    return "";
  },
  getRaceEyes: (race: GoblinRace) : string => {
    switch(race) {
      case(GoblinRace.CAVE):
        return CaveEyes;
      case(GoblinRace.DARK):
        return DarkEyes;
      case(GoblinRace.DESERT):
        return DesertEyes;
      case(GoblinRace.FOREST):
        return ForestEyes;
      case(GoblinRace.MOUNTAIN):
        return MountainEyes;
      case(GoblinRace.SEA):
        return SeaEyes;
    }
    return "";
  },
  getRaceHair: (race: GoblinRace) : string => {
    switch(race) {
      case(GoblinRace.CAVE):
        return CaveHair;
      case(GoblinRace.DARK):
        return DarkHair;
      case(GoblinRace.DESERT):
        return DesertHair;
      case(GoblinRace.FOREST):
        return ForestHair;
      case(GoblinRace.MOUNTAIN):
        return MountainHair;
      case(GoblinRace.SEA):
        return SeaHair;
    }
    return "";
  },
  getRaceMouth: (race: GoblinRace) : string => {
    switch(race) {
      case(GoblinRace.CAVE):
        return CaveMouth;
      case(GoblinRace.DARK):
        return DarkMouth;
      case(GoblinRace.DESERT):
        return DesertMouth;
      case(GoblinRace.FOREST):
        return ForestMouth;
      case(GoblinRace.MOUNTAIN):
        return MountainMouth;
      case(GoblinRace.SEA):
        return SeaMouth;
    }
    return "";
  },
  getRaceIcon: (race: GoblinRace) : string => {
    switch(race) {
      case(GoblinRace.CAVE):
        return CaveRace;
      case(GoblinRace.DARK):
        return DarkRace;
      case(GoblinRace.DESERT):
        return DesertRace;
      case(GoblinRace.FOREST):
        return ForestRace;
      case(GoblinRace.MOUNTAIN):
        return MountainRace;
      case(GoblinRace.SEA):
        return SeaRace;
    }
    return "";
  },
  getRaceSkin: (race: GoblinRace) : string => {
    switch(race) {
      case(GoblinRace.CAVE):
        return CaveSkin;
      case(GoblinRace.DARK):
        return DarkSkin;
      case(GoblinRace.DESERT):
        return DesertSkin;
      case(GoblinRace.FOREST):
        return ForestSkin;
      case(GoblinRace.MOUNTAIN):
        return MountainSkin;
      case(GoblinRace.SEA):
        return SeaSkin;
    }
    return "";
  }
}

export { RaceImages }

