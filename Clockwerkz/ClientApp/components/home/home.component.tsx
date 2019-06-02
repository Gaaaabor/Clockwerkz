import * as React from 'react';
import { JobPreview } from '../job/jobPreview.component';

export class Home extends React.Component<{}, {}> {

    render() {

        return (
            <div>
                <h1>Hello, world!</h1>
                <JobPreview />
            </div>
        );
    }
}
