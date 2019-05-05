import React, { Component } from 'react';
import { Container, Row, Col } from 'reactstrap';
import { GroupComponent } from './GroupComponent';
import { JobComponent } from './JobComponent';
import { TriggerComponent } from './TriggerComponent';

export class JobPreviewComponent extends Component {

    constructor(props) {
        super(props);

        this.state = { jobPreviews: [], loading: true };

        fetch('api/Jobs/Preview')
            .then(response => response.json())
            .then(data => {
                this.setState({ jobPreviews: data, loading: false });
            });
    }

    render() {

        const rootStyle = {
            width: '100%',
            verticalAlign: 'middle',
            layout: 'auto',
            border: '1px solid #454d55',
            backgroundColor: '#6c757d',
            color: 'white',
            fontWeight: '400',
            fontSize: '1rem'
        }

        const columnStyle = {
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
                        <Col style={columnStyle}>1 fire</Col>
                        <Col style={columnStyle}>2 fire</Col>
                        <Col>3 fire</Col>
                    </Row>
                    {this.state.jobPreviews.map(x =>
                        <GroupComponent key={x.groupName} groupName={x.groupName}>
                            {x.jobs.map(job =>
                                <JobComponent key={job.name} jobName={job.name}>
                                    <TriggerComponent triggers={job.triggers} />
                                </JobComponent>
                            )}
                        </GroupComponent>
                    )}
                </Container>

            </div>
        );
    }
}