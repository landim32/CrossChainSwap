import React, { useContext, useEffect, useState } from 'react';
import ContextBuilder from '../contexts/utils/contextBuilder';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Redirect,
} from "react-router-dom";
import { Home } from '../pages/Home';
import AuthProvider from '../contexts/auth/AuthProvider';
import GoblinProvider from '../contexts/goblin/GoblinProvider';
import { Start } from '../pages/Start';
import InicioContext from '../contexts/inicio/InicioContext';
import { GoblinPage } from '../pages/Goblin';
import GoblinUserProvider from '../contexts/goblinUser/GoblinUserProvider';
import { BreedList } from '../pages/BreedList';
import GoblinBreedProvider from '../contexts/goblinBreed/GoblinBreedProvider';
import { Breed } from '../pages/Breed';
import { Quests } from '../pages/Quests';
import { Inventory } from '../pages/Inventory';
import ItemProvider from '../contexts/item/ItemProvider';
import { DndProvider } from 'react-dnd';
import { HTML5Backend } from 'react-dnd-html5-backend';
import QuestProvider from '../contexts/quest/QuestProvider';
import { QuestDetail } from '../pages/Quests/QuestDetail';
import MiningProvider from '../contexts/mining/MiningProvider';
import { Mining } from '../pages/Mining';
import { BoxSeller } from '../pages/BoxSeller';
import { BoxOpen } from '../pages/BoxOpen';
import DollarProvider from '../contexts/payment/DollarProvider';
import GoboxProvider from '../contexts/payment/GoboxProvider';
import AuctionProvider from '../contexts/auction/AuctionProvider';
import ReferralProvider from '../contexts/referral/ReferralProvider';
import { MiningRank } from '../pages/Mining/ranking';
import { GLog } from '../pages/GLog';
import GLogProvider from '../contexts/glog/GLogProvider';
import { Finance } from '../pages/Finance';
import FinanceProvider from '../contexts/finance/FinanceProvider';
import FuseProvider from '../contexts/Fusion/FuseProvider';
import { Fusion } from '../pages/Fusion';
import { MiningReward } from '../pages/Mining/reward';
import useInterval from '@use-it/interval';
import { Button, Snackbar } from '@mui/material';
import { MarketplaceGoblin } from '../pages/Marketplace/goblin';
import { MarketplaceGobox } from '../pages/Marketplace/gobox';
import GoblinNftProvider from '../contexts/goblinNft/GoblinNftProvider';
import JobProvider from '../contexts/jobs/JobProvider';
import { Jobs } from '../pages/Jobs';
import { JobDetail } from '../pages/Jobs/JobDetail';
import GoldFinanceProvider from '../contexts/goldFinance/GoldFinanceProvider';
import { GoldFinance } from '../pages/GoldFinance';
import { MarketplaceEquipment } from '../pages/Marketplace/equipment';
import { Equipment } from '../pages/Inventory/equipment';
import { GoblinNft } from '../pages/Marketplace/nft';
import MaterialMarketProvider from '../contexts/materialMarket/MaterialMarketProvider';
import { Marketplace } from '../pages/Marketplace';

export function MainRoutes() {
  const ContextContainer = ContextBuilder([AuthProvider, GoblinProvider, GoblinUserProvider, 
    GoblinBreedProvider, ItemProvider, QuestProvider, JobProvider, MiningProvider, DollarProvider,
    GoboxProvider, AuctionProvider, ReferralProvider, GLogProvider, FinanceProvider, FuseProvider, GoblinNftProvider,
    GoldFinanceProvider, MaterialMarketProvider
  ]);
  const [versionError, setVersionError] = useState(false);
  const inicioContext = useContext(InicioContext); 

  useEffect(() => {
    //inicioContext.checkNetwork();
  }, []);

  /*
  useInterval(() => {
    inicioContext.checkNetwork();
    inicioContext.checkVersion().then((ret) => {
      if(!ret.sucesso)
        setVersionError(true);
    });
  }, 60000);
  */

  let PrivateRoute : React.FC<{ path: string} >  = ({ children, ...rest }) => {
    let sessionResult = inicioContext.checkSession();
    return (
      <Route
        {...rest}
        render={({ location }) =>
          sessionResult.sucesso ? (
            children
          ) : (
            <Redirect
              to={{
                pathname: "/login",
                state: { from: location }
              }}
            />
          )
        }
      />
    );
  }

  return(
    <ContextContainer>
      <DndProvider backend={HTML5Backend}>
        <Router>
          <div>
            <Switch>
              <Route exact path="/">
                <Start />
              </Route>
              <Route exact path="/login">
                <Start />
              </Route>
              <PrivateRoute path="/home">
                <Home />
              </PrivateRoute>
              <PrivateRoute path="/horde">
                <Home />
              </PrivateRoute>
              <Route  path="/goblin">
                <GoblinPage />
              </Route>
              <PrivateRoute path="/breedList">
                <BreedList />
              </PrivateRoute>
              <PrivateRoute path="/breed">
                <Breed />
              </PrivateRoute>
              <PrivateRoute path="/marketplace">
                <Marketplace />
              </PrivateRoute>
              <PrivateRoute path="/goldmarket">
                <GoldFinance />
              </PrivateRoute>
              <PrivateRoute path="/quests">
                <Quests />
              </PrivateRoute>
              <PrivateRoute path="/questdetail">
                <QuestDetail />
              </PrivateRoute>
              <PrivateRoute path="/mining">
                <Mining />
              </PrivateRoute>
              <PrivateRoute path="/miningrank">
                <MiningRank />
              </PrivateRoute>
              <PrivateRoute path="/miningclaim">
                <MiningReward />
              </PrivateRoute>
              <PrivateRoute path="/jobs">
                <Jobs />
              </PrivateRoute>
              <PrivateRoute path="/jobdetails">
                <JobDetail />
              </PrivateRoute>
              <PrivateRoute path="/inventory">
                <Inventory />
              </PrivateRoute>
              <PrivateRoute path="/equipment">
                <Equipment />
              </PrivateRoute>
              <PrivateRoute path="/logs">
                <GLog />
              </PrivateRoute>
              <Route path="/buy-gobox">
                <BoxSeller />
              </Route>
              <PrivateRoute path="/open-gobox">
                <BoxOpen />
              </PrivateRoute>
              <PrivateRoute path="/finance">
                <Finance />
              </PrivateRoute>
              <PrivateRoute path="/fusion">
                <Fusion />
              </PrivateRoute>
            </Switch>
          </div>
        </Router>
        <Snackbar
          anchorOrigin={{ "vertical": "bottom", "horizontal": "center" }}
          open={versionError}
          onClose={() => (setVersionError(false))}
          message="A new version of the app has been release"
          key={"versionError"}
          action={(
            <>
              <Button color="primary" size="small" onClick={() => ( window.location.reload() )}>
                Reload
              </Button>
            </>
          )}
        />
      </DndProvider>
    </ContextContainer>
)};