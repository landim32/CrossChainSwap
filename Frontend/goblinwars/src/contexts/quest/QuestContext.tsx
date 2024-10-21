import React from 'react';
import IItemProvider from '../../dto/contexts/IItemProvider';
import { IQuestProvider } from '../../dto/contexts/IQuestProvider';


const QuestContext = React.createContext<IQuestProvider>(null);

export default QuestContext;