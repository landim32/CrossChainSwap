import React from 'react';
import IGoboxProvider from '../../dto/contexts/IGoboxProvider';

const GoboxContext = React.createContext<IGoboxProvider>(null);

export default GoboxContext;