import * as React from 'react';
import { Route, Switch } from 'react-router-dom';
import { Dashboard } from './dashboard/dashboard.component';

const contentStyle: React.CSSProperties = {
    margin: '10px'
}

export class Routes extends React.Component
{
    public render(): JSX.Element {

        return (
            <div style={contentStyle}>
                <Switch>                    
                    <Route exact path='/' component={Dashboard} />
                </Switch>
            </div>);
    }
}