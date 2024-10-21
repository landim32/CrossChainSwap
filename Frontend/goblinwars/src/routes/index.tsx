
import InicioProvider from '../contexts/inicio/InicioProvider';
import ContextBuilder from '../contexts/utils/contextBuilder';
import RoutesSwitch from './routes';

export function Routes() {
  const ContextContainer = ContextBuilder([InicioProvider]);
  return (
    <ContextContainer>
      <RoutesSwitch />
    </ContextContainer>
  );
};
