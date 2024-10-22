import './App.css';
import { Routes, Route, Outlet, Link } from "react-router-dom";
import Menu from "./Components/Menu";
import SwapForm from './Pages/SwapForm';
import ContextBuilder from './Contexts/Utils/ContextBuilder';
import AuthProvider from './Contexts/Auth/AuthProvider';
import SwapProvider from './Contexts/Swap/SwapProvider';

function MySwaps() {
  return (
    <div>
      <h2>My Swaps</h2>
    </div>
  );
}

function AllSwaps() {
  return (
    <div>
      <h2>All Swaps</h2>
    </div>
  );
}

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
          <Route path="my-swaps" element={<MySwaps />} />
          <Route path="all-swaps" element={<AllSwaps />} />
          <Route path="*" element={<Error404 />} />
        </Route>
      </Routes>
    </ContextContainer>
  );
}

export default App;
