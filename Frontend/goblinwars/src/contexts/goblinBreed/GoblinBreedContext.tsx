import React from 'react';
import IGoblinBreedProvider from '../../dto/contexts/IGoblinBreedProvider';


const GoblinBreedContext = React.createContext<IGoblinBreedProvider>(null);

export default GoblinBreedContext;