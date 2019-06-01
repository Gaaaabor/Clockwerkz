import { Redirect } from 'react-router-dom'
import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { library } from '@fortawesome/fontawesome-svg-core'
import { faStroopwafel } from '@fortawesome/free-solid-svg-icons'

library.add(faStroopwafel)

export default class App extends Component {
    static displayName = App.name;

    constructor(props) {
        super(props);

        this.state = {
            firstLoad: true,
            isAuthenticated: false
        };
    }

    authenticate() {
        fetch('/Account/IsAuthenticated')
            .then(response => response.json())
            .then(data => {
                this.setState({ firstLoad: false, isAuthenticated: data });
            });
    }

    render() {

        if (this.state.firstLoad) {
            this.authenticate();
            return (<label>Loading...</label>);
        }

        if (!this.state.isAuthenticated) {
            return <Redirect to='/Account/Login' />
        }

        return (
            <Layout>
                <Route exact path='/' component={Home} />
            </Layout>
        );
    }
}
