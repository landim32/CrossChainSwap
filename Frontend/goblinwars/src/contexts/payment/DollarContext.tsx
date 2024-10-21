import React from 'react';
import IDollarProvider from '../../dto/contexts/IDollarProvider';


const DollarContext = React.createContext<IDollarProvider>(null);

export default DollarContext;