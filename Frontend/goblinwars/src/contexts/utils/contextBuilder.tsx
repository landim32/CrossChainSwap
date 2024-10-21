import React from 'react';

const ContextBuilder = (providers: ((props: any) => JSX.Element)[]) => {
  try{

    return providers.reduce((Acc, Current): React.FunctionComponent => {
      return props => <Current><Acc {...props} /></Current>
    });
    
  } catch (e) {
    throw e;
  }
}

export default ContextBuilder;