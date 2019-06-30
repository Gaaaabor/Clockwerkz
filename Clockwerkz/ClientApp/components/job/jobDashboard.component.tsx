import * as React from 'react';
import { Container, Row, Col, Button, Input, Label, Form, FormGroup, FormText, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';
import { JobGroup } from './jobGroup.component';
import { Job } from './job.component';
import { JobTrigger } from './jobTrigger.component';
import { JobModal, IJobModalModel } from './jobModal.component';
import * as Axios from 'axios';

interface IJobDashboardProps {

}

interface IJobDashboardState {
    jobPreviews: IJobPreviewDto[];
    loading: boolean;
    filter: string;
    creationMode: boolean;
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

const getInitialState = (props: IJobDashboardProps): IJobDashboardState => {
    return {
        jobPreviews: [],
        loading: false,
        filter: '',
        creationMode: false
    }
}

export class JobDashboard extends React.Component<IJobDashboardProps, IJobDashboardState> {
    state = getInitialState(this.props);

    public componentDidMount() {

        this.setState({ loading: true });

        Axios.default.get<IJobPreviewDto[]>('api/Jobs/Preview')
            .then(response => {
                this.setState((prevState, props) => {
                    return {
                        jobPreviews: response.data,
                        loading: false,
                        filter: prevState.filter
                    }
                })
            });
    }

    private handleFilterChange(e: React.ChangeEvent<HTMLInputElement>) {

        const filter = e.currentTarget.value;

        this.setState((prevState, props) => {
            return {
                jobPreviews: prevState.jobPreviews,
                loading: prevState.loading,
                filter: filter
            }
        });
    }

    private getFilteredJobs(): IJobPreviewDto[] {

        const jobPreviews = this.state.jobPreviews;

        if (this.state.filter === '') {
            return jobPreviews;
        }

        const filter = this.state.filter.toLowerCase();
        let filtered: IJobPreviewDto[] = [];

        jobPreviews.forEach(x => {

            let jobs = x.jobs.filter(j => j.name.toLowerCase().includes(filter));
            if (0 < jobs.length) {

                filtered.push({
                    groupName: x.groupName,
                    jobs: jobs
                });
            }
        });

        return filtered;
    }

    private getCreationModal(): JSX.Element | null {

        if (!this.state.creationMode) {
            return null;
        }

        return <JobModal cancelAction={this.cancel.bind(this)} createAction={this.create.bind(this)} />
    }

    private newJob() {
        this.setState((prevState, props) => {
            return {
                creationMode: !prevState.creationMode
            }
        });
    }

    private create(model: IJobModalModel) {        



        this.setState((prevState, props) => {
            return {
                creationMode: false
            }
        });
    }

    private cancel() {
        this.setState((prevState, props) => {
            return {
                creationMode: false
            }
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

        const stateColumnStyle: React.CSSProperties = {
            borderRight: '1px black solid',
            minHeight: '30px',
            maxWidth: '30px'
        }

        const filteredJobs = this.getFilteredJobs();
        const creationModal = this.getCreationModal();

        return (
            <div>
                <Container>

                    <Row>
                        <Button style={buttonStyle} onClick={this.newJob.bind(this)} className="box-shadow ">New job</Button>
                    </Row>

                    {creationModal}

                    <Row>
                        <Input style={filterStyle} onChange={this.handleFilterChange.bind(this)} className="box-shadow bg-white" type="text" />
                    </Row>

                    <Row style={rowStyle}>
                        <Col style={stateColumnStyle}></Col>
                        <Col style={columnStyle}>Type</Col>
                        <Col style={columnStyle}>Start</Col>
                        <Col style={columnStyle}>End</Col>
                        <Col style={columnStyle}>Last fire</Col>
                        <Col style={columnStyle}>Next fire</Col>
                        <Col>Buttons</Col>
                    </Row>
                    {filteredJobs.map(x =>
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