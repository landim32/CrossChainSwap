import React from 'react';
import IAuctionProvider from '../../dto/contexts/IAuctionProvider';

const AuctionContext = React.createContext<IAuctionProvider>(null);

export default AuctionContext;