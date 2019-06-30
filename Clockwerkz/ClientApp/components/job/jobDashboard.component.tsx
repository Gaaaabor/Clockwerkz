import * as React from 'react';
import { Container, Row, Col, Button, Input, Label, Form, FormGroup, FormText, Modal, ModalHeader, ModalBody, ModalFooter, Spinner } from 'reactstrap';
import { JobGroup } from './jobGroup.component';
import { Job } from './job.component';
import { JobTrigger } from './jobTrigger.component';
import { JobModal, IJobModalModel } from './jobModal.component';
import * as Axios from 'axios';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faTrafficLight, faMicrochip, faCalendarPlus, faCalendarMinus, faCalendarCheck, faCalendarAlt, IconDefinition } from '@fortawesome/free-solid-svg-icons';

interface IJobDashboardProps {

}

interface IJobDashboardState {
    jobPreviews: IJobPreviewDto[];
    isLoading: boolean;
    filter: string;
    creationMode: boolean;
    reloadGrid: boolean;
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
        isLoading: false,
        filter: '',
        creationMode: false,
        reloadGrid: false
    }
}

export class JobDashboard extends React.Component<IJobDashboardProps, IJobDashboardState> {
    state = getInitialState(this.props);

    public componentDidMount() {

        this.setState({ isLoading: true });
        this.loadJobs();
    }

    private loadJobs() {
        Axios.default.get<IJobPreviewDto[]>('api/Jobs/Preview')
            .then(response => {
                this.setState((prevState) => {
                    return {
                        ...prevState,
                        jobPreviews: response.data,
                        isLoading: false,
                        reloadGrid: false
                    }
                })
            });
    }

    private handleFilterChange(e: React.ChangeEvent<HTMLInputElement>) {

        const filter = e.currentTarget.value;

        this.setState((prevState) => {
            return {
                ...prevState,
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
        this.setState((prevState) => {
            return {
                ...prevState,
                creationMode: !prevState.creationMode
            }
        });
    }

    private create(model: IJobModalModel) {

        this.setState((prevState) => { return { ...prevState, isLoading: true } });

        Axios.default.post('api/Jobs/Schedule', model)
            .then(response => {
                this.setState((prevState) => { return { ...prevState, isLoading: false, reloadGrid: true } })
            });

        this.setState((prevState) => {
            return {
                ...prevState,
                creationMode: false
            }
        });
    }

    private cancel() {
        this.setState((prevState) => {
            return {
                ...prevState,
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

        const iconColumnStyle: React.CSSProperties = {
            borderRight: '1px black solid'
        }

        if (this.state.reloadGrid) {
            this.loadJobs();
        }

        const spinner = this.state.isLoading ? (<Spinner color="primary" />) : null;
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

                    {spinner}
                    <Row style={rowStyle}>
                        <Col sm={1} style={iconColumnStyle}>
                            <FontAwesomeIcon icon={faTrafficLight} />
                            <br />
                            Status
                        </Col>
                        <Col sm={1} style={iconColumnStyle}>
                            <FontAwesomeIcon icon={faMicrochip} />
                            <br />
                            Type
                        </Col>
                        <Col style={columnStyle}>
                            <FontAwesomeIcon icon={faCalendarPlus} />
                            <br />
                            Start
                        </Col>
                        <Col style={columnStyle}>
                            <FontAwesomeIcon icon={faCalendarMinus} />
                            <br />
                            End
                        </Col>
                        <Col style={columnStyle}>
                            <FontAwesomeIcon icon={faCalendarCheck} />
                            <br />
                            Last fire
                        </Col>
                        <Col style={columnStyle}>
                            <FontAwesomeIcon icon={faCalendarAlt} />
                            <br />
                            Next fire
                        </Col>
                        <Col style={columnStyle}></Col>                        
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