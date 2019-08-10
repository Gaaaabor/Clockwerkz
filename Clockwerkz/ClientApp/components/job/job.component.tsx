import { faEdit, faTrash } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import * as React from 'react';
import { Button, Col, Row } from 'reactstrap';
import { JobsApi } from '../../infrastructure/job.api';

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
            fontSize: '1rem'
        }

        const emptyColumnStyle: React.CSSProperties = {
            maxWidth: "50px",
        }

        const jobNameColumnStyle: React.CSSProperties = {
            paddingTop: "5px",
            paddingBottom: "5px"
        }

        return (
            <div>
                <Row style={jobStyle}>
                    <Col style={emptyColumnStyle}></Col>
                    <Col style={jobNameColumnStyle}>{this.state.jobName}</Col>
                </Row>
                {this.props.children}
            </div >
        );
    }
}