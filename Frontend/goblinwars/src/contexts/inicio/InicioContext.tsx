import React from 'react';
import IInicioProvider from '../../dto/contexts/IInicioProvider';


const InicioContext = React.createContext<IInicioProvider>(null);

export default InicioContext;