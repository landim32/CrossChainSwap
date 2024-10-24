import React from 'react';
import ITxProvider from '../../DTO/Contexts/ITxProvider';

const TxContext = React.createContext<ITxProvider>(null);

export default TxContext;