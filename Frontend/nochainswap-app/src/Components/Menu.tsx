import React, { useContext, useEffect, useState } from 'react';
import Container from 'react-bootstrap/Container';
import Button from 'react-bootstrap/esm/Button';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import { Link } from 'react-router-dom';
import AuthContext from '../Contexts/Auth/AuthContext';
import NavDropdown from 'react-bootstrap/NavDropdown';

export default function Menu() {
  const authContext = useContext(AuthContext);
  useEffect(() => {
    authContext.loadUserSession();
  }, []);
  return (
    <Navbar expand="lg" className="bg-body-tertiary mb-3">
      <Container>
        <Navbar.Brand href="#home">NoChain Swap</Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="me-auto">
            <Link className='nav-link' to="/">Swap</Link>
            <Link className='nav-link' to="/my-swaps">My Swaps</Link>
            <Link className='nav-link' to="/all-swaps">All Swaps</Link>
          </Nav>
        </Navbar.Collapse>
        <Navbar.Collapse>
          <Nav className="ms-auto justify-content-end">
            <Nav.Link href='https://leather.io/install' target='_blank'>Install Leather</Nav.Link>
            {
              authContext.sessionInfo ?
                <NavDropdown title={authContext.sessionInfo.name} id="basic-nav-dropdown">
                  <NavDropdown.Item onClick={async () => {
                    await authContext.logout();
                  }}>Logout</NavDropdown.Item>
                </NavDropdown>
                :
                <Nav.Item><Button variant="danger" onClick={async () => {
                  let handleCallback = () => {
                    authContext.loadUserSession();
                  }
                  authContext.login(handleCallback);
                }}>Connect</Button></Nav.Item>
            }
          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
}
