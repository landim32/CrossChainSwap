import GobiBusiness from '../impl/GobiBusiness';
import IGobiBusiness from '../interfaces/IGobiBusiness';

const gobiBusinessImpl: IGobiBusiness = GobiBusiness;

const GobiFactory = {
  GobiBusiness: gobiBusinessImpl
};

export default GobiFactory;
