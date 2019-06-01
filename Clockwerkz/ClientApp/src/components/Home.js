import React, { Component } from 'react';
import { JobPreviewComponent } from './job/JobPreviewComponent';

export class Home extends Component {

    render() {

        return (
            <div>
                <h1>Hello, world!</h1>
                <JobPreviewComponent />                
            </div>
        );
    }
}
