import * as React from 'react';
import { Row, Col } from 'reactstrap';

interface JobProps {
    jobName: string;
}

interface JobState {
    jobName: string;
}

export class Job extends React.Component<JobProps, JobState> {

    constructor(props: JobProps) {
        super(props);
        this.state = {
            jobName: props.jobName
        };
    }

    render() {

        const jobStyle: React.CSSProperties = {
            verticalAlign: 'middle',
            border: '1px solid #454d55',
            backgroundColor: '#343a40',
            color: 'white',
            fontWeight: 400,
            fontSize: '1rem',
            minHeight: '30px'
        }

        const firstColumn: React.CSSProperties = {
            maxWidth: 30,
            backgroundColor: '#ffffff',
            borderRight: '1px solid #454d55'
        }

        return (
            <div>
                <Row style={jobStyle}>
                    <Col style={firstColumn}>D</Col>
                    <Col>{this.state.jobName}</Col>
                </Row>
                {this.props.children}
            </div>
        );
    }
}