import * as React from 'react';
import { Button, Col, Dropdown, DropdownItem, DropdownMenu, DropdownToggle, Form, FormGroup, Input, Label, Modal, ModalBody, ModalFooter, ModalHeader } from 'reactstrap';
import { IJobCreateDto } from '../../infrastructure/dtos/job.create.dto';
import { IJobDataMapKeyDto } from '../../infrastructure/dtos/jobDataMapKey.dto';
import { IJobTypeDto } from '../../infrastructure/dtos/jobType.dto';
import { JobMetadatasApi } from '../../infrastructure/jobMetadata.api';
import { JobDataMapInput } from './jobDataMapInput.component';

export interface IJobModalProps {
    cancelAction: React.MouseEventHandler<any>;
    createAction: (model: IJobCreateDto) => void;
}

export interface IJobModalState {
    cancelAction: React.MouseEventHandler<any>;
    createAction: (model: IJobCreateDto) => void;
    jobTypes: IJobTypeDto[];
    jobDataMapKeys: IJobDataMapKeyDto[];
    isDropdownOpen: boolean;
    model: IJobCreateDto;
}

const getInitialState = (props: IJobModalProps): IJobModalState => {
    return {
        cancelAction: props.cancelAction,
        createAction: props.createAction,
        jobTypes: [],
        jobDataMapKeys: [],
        isDropdownOpen: false,

        model: {
            jobName: '',
            groupName: '',
            cronExpression: '',
            jobDataMap: {}
        }
    }
}

export class JobModal extends React.Component<IJobModalProps, IJobModalState> {
    state = getInitialState(this.props);

    public componentDidMount() {
        this.loadJobTypes();
    }

    private loadJobTypes() {
        JobMetadatasApi.getJobTypes().then(response => {
            this.setState((prevState) => {
                return {
                    ...prevState,
                    jobTypes: response
                }
            })
        });
    }

    private loadJobDataMapProperties(dataMapGroup: string) {
        JobMetadatasApi.getJobDataMapKeys(dataMapGroup).then(response => {

            if (response !== undefined && 0 < response.length) {
                this.setState((prevState) => {
                    return {
                        ...prevState,
                        jobDataMapKeys: response
                    }
                })
            }
        });
    }

    private handleChange(event: React.ChangeEvent<HTMLInputElement>) {

        const prop = event.currentTarget.id;
        const value = event.currentTarget.value;

        this.setState((prevState) => {
            return {
                ...prevState,
                model: {
                    ...prevState.model,
                    [prop]: value
                }
            };
        });
    }

    private handleJobDataMapChange(prop: string, value: string) {

        this.setState((prevState) => {
            return {
                ...prevState,
                model: {
                    ...prevState.model,
                    jobDataMap: {
                        ...prevState.model.jobDataMap,
                        [prop]: value
                    }
                }
            };
        });
    }

    private handleToggle() {
        this.setState((prevState) => {
            return {
                ...prevState,
                isDropdownOpen: !prevState.isDropdownOpen
            };
        });
    }

    private handleDropDownClick(jobType: IJobTypeDto) {

        const prop = 'jobType';

        this.setState((prevState) => {
            return {
                ...prevState,
                model: {
                    ...prevState.model,
                    jobDataMap: {
                        ...prevState.model.jobDataMap,
                        [prop]: jobType.type
                    }
                }
            };
        });

        this.loadJobDataMapProperties(jobType.dataMapGroup);
    }

    private getJobTypeName(jobTypes: IJobTypeDto[], jobType: string): string {

        if (jobType === '' || jobType === undefined) {
            return 'Please select the jobs type';
        }

        var found = jobTypes.find(x => x.type === jobType);
        if (found === undefined) {
            return 'Please select the jobs type';
        }

        return found.name;
    }

    render() {

        const dropdownStyle: React.CSSProperties = {
            width: '100%'
        }

        const cancel = this.state.cancelAction;
        const create = () => this.state.createAction(this.state.model);
        const jobTypes = this.state.jobTypes;
        const isDropdownOpen = this.state.isDropdownOpen;
        const selectedJobTypeName = this.getJobTypeName(jobTypes, this.state.model.jobDataMap["jobType"]);
        const jobDataMapKeys = this.state.jobDataMapKeys;

        return (
            <Modal isOpen={true}>
                <ModalHeader>Create job</ModalHeader>
                <ModalBody>

                    <Form>
                        <FormGroup row>
                            <Label for="jobName" sm={3}>Job name</Label>
                            <Col sm={9}>
                                <Input id="jobName" placeholder="Job name" onChange={this.handleChange.bind(this)} />
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label for="groupName" sm={3}>Group name</Label>
                            <Col sm={9}>
                                <Input id="groupName" placeholder="Group name" onChange={this.handleChange.bind(this)} />
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label for="cronExpression" sm={3}>Cron</Label>
                            <Col sm={9}>
                                <Input id="cronExpression" placeholder="Cron expression" onChange={this.handleChange.bind(this)} />
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label for="jobType" sm={3}>JobType</Label>
                            <Col sm={9}>
                                <Dropdown style={dropdownStyle} isOpen={isDropdownOpen} toggle={this.handleToggle.bind(this)}>
                                    <DropdownToggle caret style={dropdownStyle} >
                                        {selectedJobTypeName}
                                    </DropdownToggle>
                                    <DropdownMenu style={dropdownStyle}>
                                        {jobTypes.map(x =>
                                            <DropdownItem style={dropdownStyle} onClick={this.handleDropDownClick.bind(this, x)} key={x.type}>{x.name}</DropdownItem>
                                        )}
                                    </DropdownMenu>
                                </Dropdown>
                            </Col>
                        </FormGroup>                        

                        {jobDataMapKeys.map(x =>
                            <JobDataMapInput key={x.name} jobDataMapKey={x} onChange={this.handleJobDataMapChange.bind(this)} />
                        )}

                    </Form>

                </ModalBody>
                <ModalFooter>
                    <Button color="secondary" onClick={cancel}>Cancel</Button>
                    <Button color="primary" onClick={create}>Create</Button>
                </ModalFooter>
            </Modal>
        );
    }
}