import * as React from 'react';
import { JobDashboard } from '../job/jobDashboard.component';

export class Dashboard extends React.Component<{}, {}> {

    render() {

        return (
            <div>
                <h1>Hello, world!</h1>
                <JobDashboard />
            </div>
        );
    }
}
