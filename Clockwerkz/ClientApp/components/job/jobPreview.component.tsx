import * as React from 'react';
import { Container, Row, Col } from 'reactstrap';
import { JobGroup } from './jobGroup.component';
import { Job } from './job.component';
import { JobTrigger } from './jobTrigger.component';
import * as Axios from 'axios';

interface JobPreviewProps {

}

interface JobPreviewState {
    jobPreviews: JobPreviewDto[];
    loading: boolean;
}

interface JobPreviewDto {
    groupName: string;
    jobs: JobDto[];
}

interface JobDto {
    name: string;
    triggers: JobTriggerDto[];
}

export interface JobTriggerDto {
    id: string;
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

        this.state = { jobPreviews: [], loading: true };

        Axios.default.get<JobPreviewDto[]>('api/Jobs/Preview')
            .then(response => {
                this.setState({ jobPreviews: response.data, loading: false })
            });
    }

    render() {

        const rootStyle: React.CSSProperties = {
            width: '100%',
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
            borderRight: '1px black solid'
        }

        return (
            <div>
                <Container>
                    <Row style={rootStyle}>
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