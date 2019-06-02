import * as React from 'react';
import { JobPreview } from '../job/jobPreview.component';

export class Dashboard extends React.Component<{}, {}> {

    render() {

        return (
            <div>
                <h1>Hello, world!</h1>
                <JobPreview />
            </div>
        );
    }
}
