import React from 'react';
import ISwapProvider from '../../DTO/Contexts/ISwapProvider';

const SwapContext = React.createContext<ISwapProvider>(null);

export default SwapContext;