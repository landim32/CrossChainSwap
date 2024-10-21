import React from 'react';
import IFuseProvider from '../../dto/contexts/IFuseProvider';


const FuseContext = React.createContext<IFuseProvider>(null);

export default FuseContext;