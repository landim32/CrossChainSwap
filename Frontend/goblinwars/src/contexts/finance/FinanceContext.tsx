import React from 'react';
import IFinanceProvider from '../../dto/contexts/IFinanceProvider';

const FinanceContext = React.createContext<IFinanceProvider>(null);

export default FinanceContext;