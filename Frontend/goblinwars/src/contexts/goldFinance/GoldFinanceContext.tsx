import React from 'react';
import { IGoldFinanceProvider } from '../../dto/contexts/IGoldFinanceProvider';


const GoldFinanceContext = React.createContext<IGoldFinanceProvider>(null);

export default GoldFinanceContext;