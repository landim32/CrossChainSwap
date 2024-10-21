import React from 'react';
import IGoblinUserProvider from '../../dto/contexts/IGoblinUserProvider';


const GoblinUserContext = React.createContext<IGoblinUserProvider>(null);

export default GoblinUserContext;