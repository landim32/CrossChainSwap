import React from 'react';
import IGoblinProvider from '../../dto/contexts/IGoblinProvider';


const GoblinContext = React.createContext<IGoblinProvider>(null);

export default GoblinContext;