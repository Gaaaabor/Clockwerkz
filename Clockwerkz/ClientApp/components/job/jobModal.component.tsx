import * as React from 'react';
import { Col, Button, Input, Label, Form, FormGroup, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';

export interface IJobModalModel {
    jobName: string;
    groupName: string;
    cronExpression: string;
    deviceSerial: string;
}

export interface IJobModalProps {
    cancelAction: React.MouseEventHandler<any>;
    createAction: (model: IJobModalModel) => void;
}

export interface IJobModalState {
    cancelAction: React.MouseEventHandler<any>;
    createAction: (model: IJobModalModel) => void;
    model: IJobModalModel;
}

const getInitialState = (props: IJobModalProps): IJobModalState => {
    return {
        cancelAction: props.cancelAction,
        createAction: props.createAction,
        model: {
            jobName: '',
            groupName: '',
            cronExpression: '',
            deviceSerial: ''
        }
    }
}

export class JobModal extends React.Component<IJobModalProps, IJobModalState> {
    state = getInitialState(this.props);

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

    render() {

        const cancel = this.state.cancelAction;
        const create = () => this.state.createAction(this.state.model);

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
                            <Label for="deviceSerial" sm={3}>Device serial</Label>
                            <Col sm={9}>
                                <Input id="deviceSerial" placeholder="Device serial" onChange={this.handleChange.bind(this)} />
                            </Col>
                        </FormGroup>                        
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