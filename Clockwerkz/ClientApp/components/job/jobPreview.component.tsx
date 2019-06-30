import * as React from 'react';
import { Card } from 'reactstrap';

interface JobPreviewProps {
    groupName: string,
    jobName: string,
    state: string;
    type: string;
    startTime: number;
    endTime?: number;
    previousFireTime?: number;
    nextFireTime?: number;
}

interface JobPreviewState {
    groupName: string,
    jobName: string,
    state: string;
    type: string;
    startTime: number;
    endTime?: number;
    previousFireTime?: number;
    nextFireTime?: number;
}

export class JobPreview extends React.Component<JobPreviewProps, JobPreviewState> {

    constructor(props: JobPreviewProps) {
        super(props);
        this.state = {
            groupName: props.groupName,
            jobName: props.jobName,
            state: props.state,
            type: props.type,
            startTime: props.startTime,
            endTime: props.endTime,
            previousFireTime: props.previousFireTime,
            nextFireTime: props.nextFireTime
        };

    }

    render() {

        return (
            <div>

                <Card>
                {this.state.groupName},
                {this.state.jobName},
                {this.state.state},
                {this.state.type},
                {this.state.startTime},
                {this.state.endTime},
                {this.state.previousFireTime},
                {this.state.nextFireTime}
                </Card>
            </div>
        );
    }
}
