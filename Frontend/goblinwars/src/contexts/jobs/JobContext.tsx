import React from 'react';
import { IJobProvider } from '../../dto/contexts/IJobProvider';


const JobContext = React.createContext<IJobProvider>(null);

export default JobContext;