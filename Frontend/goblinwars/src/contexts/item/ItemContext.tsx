import React from 'react';
import IItemProvider from '../../dto/contexts/IItemProvider';


const ItemContext = React.createContext<IItemProvider>(null);

export default ItemContext;