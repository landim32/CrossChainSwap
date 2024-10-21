import { BodyPartEnum } from "../dto/enum/BodyPartEnum";

const GetPartName = (part: BodyPartEnum) => {
  switch(part) {
    case BodyPartEnum.Head:
      return "Helmet";
    case BodyPartEnum.Chest:
      return "Chest";
    case BodyPartEnum.Gloves:
      return "Gloves";
    case BodyPartEnum.Foot:
      return "Boots";
    case BodyPartEnum.LHand:
      return "Left Hand";
    case BodyPartEnum.RHand:
    return "Right Hand";
  }
}

export { GetPartName }