import { LinearProgress, linearProgressClasses, styled } from "@mui/material";
import { GoblinWarsColors } from "../dto/styles/GoblinWarsColors";

const GoblinProgress = styled(LinearProgress)(({ theme }) => ({
  height: 17,
  borderRadius: 9,
  [`&.${linearProgressClasses.colorPrimary}`]: {
    backgroundColor: "gray",
  },
  [`& .${linearProgressClasses.bar}`]: {
    borderRadius: 9,
    backgroundColor: GoblinWarsColors.greenLogo
  },
}));

const GoblinHealthGood = styled(LinearProgress)(({ theme }) => ({
  height: 18,
  borderRadius: 9,
  [`&.${linearProgressClasses.colorPrimary}`]: {
    backgroundColor: "gray",
  },
  [`& .${linearProgressClasses.bar}`]: {
    borderRadius: 9,
    backgroundColor: "#00923f"
  },
}));

const GoblinHealthMedium = styled(LinearProgress)(({ theme }) => ({
  height: 18,
  borderRadius: 9,
  [`&.${linearProgressClasses.colorPrimary}`]: {
    backgroundColor: "gray",
  },
  [`& .${linearProgressClasses.bar}`]: {
    borderRadius: 9,
    backgroundColor: "#f8c301"
  },
}));

const GoblinHealthLow = styled(LinearProgress)(({ theme }) => ({
  height: 18,
  borderRadius: 9,
  [`&.${linearProgressClasses.colorPrimary}`]: {
    backgroundColor: "gray",
  },
  [`& .${linearProgressClasses.bar}`]: {
    borderRadius: 9,
    backgroundColor: "#da251c"
  },
}));

export { GoblinProgress, GoblinHealthGood, GoblinHealthMedium, GoblinHealthLow }