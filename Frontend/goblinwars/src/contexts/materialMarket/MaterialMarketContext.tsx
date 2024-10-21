import React from 'react';
import { IMaterialMarketProvider } from '../../dto/contexts/IMaterialMarketProvider';


const MaterialMarketContext = React.createContext<IMaterialMarketProvider>(null);

export default MaterialMarketContext;