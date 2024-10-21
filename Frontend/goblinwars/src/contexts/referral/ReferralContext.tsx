import React from 'react';
import IReferralProvider from '../../dto/contexts/IReferralProvider';

const ReferralContext = React.createContext<IReferralProvider>(null);

export default ReferralContext;