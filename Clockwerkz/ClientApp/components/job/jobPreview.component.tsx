import * as React from 'react';
import { Container, Row, Col, Button, Input } from 'reactstrap';
import { JobGroup } from './jobGroup.component';
import { Job } from './job.component';
import { JobTrigger } from './jobTrigger.component';
import * as Axios from 'axios';

interface IJobPreviewProps {

}

interface IJobPreviewState {
    jobPreviews: IJobPreviewDto[];
    loading: boolean;
}

interface IJobPreviewDto {
    groupName: string;
    jobs: IJobDto[];
}

interface IJobDto {
    name: string;
    triggers: IJobTriggerDto[];
}

export interface IJobTriggerDto {
    id: string;
    state: string;
    type: string;
    startTime: number;
    endTime?: number;
    previousFireTime?: number;
    nextFireTime?: number;
}

export class JobPreview extends React.Component<IJobPreviewProps, IJobPreviewState> {

    constructor(props: IJobPreviewProps) {
        super(props);

        this.state = { jobPreviews: [], loading: true };

        Axios.default.get<IJobPreviewDto[]>('api/Jobs/Preview')
            .then(response => {
                this.setState({ jobPreviews: response.data, loading: false })
            });
    }

    render() {

        const buttonStyle: React.CSSProperties = {
            width: 100,
            marginBottom: 10,
            borderRadius: 0
        }

        const filterStyle: React.CSSProperties = {
            marginBottom: 10,
            borderRadius: 0
        };

        const rowStyle: React.CSSProperties = {
            verticalAlign: 'middle',
            tableLayout: 'auto',
            border: '1px solid #454d55',
            backgroundColor: '#6c757d',
            color: 'white',
            fontWeight: 400,
            fontSize: '1rem',
            textAlign: 'center'            
        }

        const columnStyle: React.CSSProperties = {
            borderRight: '1px black solid',
            minHeight: '30px'
        }

        return (
            <div>
                <Container>

                    <Row>
                        <Button style={buttonStyle} className="box-shadow ">New job</Button>
                    </Row>

                    <Row >
                        <Input style={filterStyle} className="box-shadow bg-white" type="text" />
                    </Row>

                    <Row style={rowStyle}>
                        <Col style={columnStyle}>State</Col>
                        <Col style={columnStyle}>Type</Col>
                        <Col style={columnStyle}>Start</Col>
                        <Col style={columnStyle}>End</Col>
                        <Col style={columnStyle}>Last fire</Col>
                        <Col style={columnStyle}>Next fire</Col>
                        <Col>Buttons</Col>
                    </Row>
                    {this.state.jobPreviews.map(x =>
                        <JobGroup key={x.groupName} groupName={x.groupName}>
                            {x.jobs.map(job =>
                                <Job key={job.name} jobName={job.name}>
                                    <JobTrigger triggers={job.triggers} />
                                </Job>
                            )}
                        </JobGroup>
                    )}
                </Container>

            </div>
        );
    }
}