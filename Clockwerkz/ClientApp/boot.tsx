import './site.css';
import 'jquery';
import 'bootstrap';
import 'reactstrap';
import * as React from 'react';
import * as ReactDOM from 'react-dom';
import * as LayoutModule from './layout';
import axios from 'axios';
import { BrowserRouter } from 'react-router-dom';

var layout = LayoutModule.layout;

function renderApp() {

    axios.interceptors.response.use(function (response) {
        // Do something with response data
        return response;
    }, handleReject);

    // This code starts up the React app when it runs in a browser. It sets up the routing
    // configuration and injects the app into a DOM element.
    const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href')!;
    ReactDOM.render(
        <BrowserRouter children={layout} basename={baseUrl} />,
        document.getElementById('react-app')
    );
}

function handleReject<T>(error: any): Promise<T> {

    if (error.response) {
        // The request was made and the server responded with a status code
        // that falls out of the range of 2xx
        console.log(error.response.data);
        console.log(error.response.status);
        console.log(error.response.headers);
    } else if (error.request) {
        // The request was made but no response was received
        // `error.request` is an instance of XMLHttpRequest in the browser and an instance of
        // http.ClientRequest in node.js
        console.log(error.request);
    } else {
        // Something happened in setting up the request that triggered an Error
        console.log('Error', error.message);
    }

    return Promise.reject<T>(error);
}

renderApp();

//Allow Hot Module Replacement
if (module.hot) {
    module.hot.accept('./layout', () => {
        layout = require<typeof LayoutModule>('./layout').layout;
        renderApp();
    });
}