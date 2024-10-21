import React from 'react';
import IGoblinNftProvider from '../../dto/contexts/IGoblinNftProvider';

const GoblinNftContext = React.createContext<IGoblinNftProvider>(null);
//alert(JSON.stringify(GoblinNftContext));

export default GoblinNftContext;