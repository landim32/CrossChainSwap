import React from 'react';
import IMiningProvider from '../../dto/contexts/IMiningProvider';


const MiningContext = React.createContext<IMiningProvider>(null);

export default MiningContext;