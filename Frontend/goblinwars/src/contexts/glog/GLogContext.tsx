import React from 'react';
import IGLogProvider from '../../dto/contexts/IGLogProvider';

const GLogContext = React.createContext<IGLogProvider>(null);

export default GLogContext;