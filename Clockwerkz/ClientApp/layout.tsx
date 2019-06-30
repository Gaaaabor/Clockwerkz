import * as React from 'react';
import { Routes } from './components/routes';
import { Container } from 'reactstrap';
import { NavMenu } from './components/navMenu/navMenu';

export const layout =
    <div>
        <NavMenu />        
        <Container>
            <Routes />
        </Container>
    </div>;