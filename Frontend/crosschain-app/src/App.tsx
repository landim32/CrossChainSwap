import './App.css';
import { Routes, Route, Outlet, Link } from "react-router-dom";
import Menu from "./Components/Menu";
import SwapForm from './Pages/SwapForm';
import ContextBuilder from './Contexts/Utils/ContextBuilder';
import AuthProvider from './Contexts/Auth/AuthProvider';
import { useContext, useEffect } from 'react';
import AuthContext from './Contexts/Auth/AuthContext';

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
      {/* A "layout route" is a good place to put markup you want to
          share across all the pages on your site, like navigation. */}
      <Menu />

      <hr />

      {/* An <Outlet> renders whatever child route is currently active,
          so you can think about this <Outlet> as a placeholder for
          the child routes we defined above. */}
      <Outlet />
    </div>
  );
}

function App() {
  const ContextContainer = ContextBuilder([AuthProvider]);

  /*
  const authContext = useContext(AuthContext);
  useEffect(() => {
    authContext.loadUserSession();
  }, []);
  */

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
