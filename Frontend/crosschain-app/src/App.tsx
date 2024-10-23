import './App.css';
import { Routes, Route, Outlet, Link } from "react-router-dom";
import Menu from "./Components/Menu";
import SwapForm from './Pages/SwapForm';
import ContextBuilder from './Contexts/Utils/ContextBuilder';
import AuthProvider from './Contexts/Auth/AuthProvider';
import SwapProvider from './Contexts/Swap/SwapProvider';
import ListTxPage from './Pages/ListTxPage';

function Error404() {
  return (
    <div>
      <h2>Error 404</h2>
    </div>
  );
}

function Layout() {
  return (
    <div>
      <Menu />
      <Outlet />
    </div>
  );
}

function App() {
  const ContextContainer = ContextBuilder([AuthProvider, SwapProvider]);

  return (
    <ContextContainer>
      <Routes>
        <Route path="/" element={<Layout />}>
          <Route index element={<SwapForm />} />
          <Route path="my-swaps" element={<ListTxPage />} />
          <Route path="all-swaps" element={<ListTxPage />} />
          <Route path="*" element={<Error404 />} />
        </Route>
      </Routes>
    </ContextContainer>
  );
}

export default App;
