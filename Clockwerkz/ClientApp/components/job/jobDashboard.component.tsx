import { faCalendarAlt, faCalendarCheck, faCalendarMinus, faCalendarPlus, faMicrochip, faTrafficLight } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import * as React from 'react';
import { Button, Col, Container, Input, Row, Spinner } from 'reactstrap';
import { IJobCreateDto } from '../../infrastructure/dtos/job.create.dto';
import { IJobDto } from '../../infrastructure/dtos/job.dto';
import { JobsApi } from '../../infrastructure/job.api';
import { Job } from './job.component';
import { JobGroup } from './jobGroup.component';
import { JobModal } from './jobModal.component';
import { JobTrigger } from './jobTrigger.component';

interface IJobDashboardProps {

}

interface IJobDashboardState {
    jobs: IJobDto[];
    isLoading: boolean;
    filter: string;
    creationMode: boolean;
    reloadGrid: boolean;
}

interface IJobGroupDto {
    groupName: string;
    jobs: IJobDto[];
}

const getInitialState = (props: IJobDashboardProps): IJobDashboardState => {
    return {
        jobs: [],
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
        JobsApi.getJobs().then(response => {
            this.setState((prevState) => {
                return {
                    ...prevState,
                    jobs: response,
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

    private groupJobs(jobs: IJobDto[]) {

        let groupedJobs: IJobGroupDto[] = [];

        for (var i = 0; i < jobs.length; i++) {

            var job = jobs[i];

            var found = groupedJobs.find(x => x.groupName === job.jobGroup);
            if (found === undefined) {
                groupedJobs.push({
                    groupName: job.jobGroup,
                    jobs: [job]
                });
            }
            else {
                found.jobs.push(job);
            }
        }

        return groupedJobs;
    }

    private filterJobs(): IJobDto[] {

        const jobs = this.state.jobs;

        if (this.state.filter === '') {
            return jobs;
        }

        const filter = this.state.filter.toLowerCase();
        let filtered = jobs.filter(x => x.name.toLowerCase().includes(filter));

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

    private create(model: IJobCreateDto) {

        this.setState((prevState) => { return { ...prevState, isLoading: true } });

        JobsApi.createJob(model)
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
            borderRight: '1px black solid',
            minWidth: "10px",
            maxWidth: "25px",
            padding: "0px"
        }

        if (this.state.reloadGrid) {
            this.loadJobs();
        }

        const spinner = this.state.isLoading ? (<Spinner color="primary" />) : null;        
        const groupedJobs = this.groupJobs(this.filterJobs());
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
                        <Col style={iconColumnStyle}>
                            <FontAwesomeIcon icon={faTrafficLight} />
                        </Col>
                        <Col style={iconColumnStyle}>
                            <FontAwesomeIcon icon={faMicrochip} />
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
                        <Col style={iconColumnStyle} />
                        <Col style={iconColumnStyle} />
                    </Row>

                    {groupedJobs.map(jobGroup =>
                        <JobGroup key={jobGroup.groupName} groupName={jobGroup.groupName}>
                            {jobGroup.jobs.map(job =>
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