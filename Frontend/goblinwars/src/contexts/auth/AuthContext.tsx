import React from 'react';
import IAuthProvider from '../../dto/contexts/IAuthProvider';


const AuthContext = React.createContext<IAuthProvider>(null);

export default AuthContext;