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

        const groupStyle = {
            width: '100%',
            verticalAlign: 'middle',
            layout: 'auto',
            border: '1px solid #454d55',
            backgroundColor: '#343a40',
            color: 'white',
            fontWeight: '400',
            fontSize: '1rem'
        }

        const jobStyle = {
            width: '100%',
            verticalAlign: 'middle',
            layout: 'auto',
            border: '1px solid #454d55',
            backgroundColor: '#343a40',
            color: 'white',
            fontWeight: '400',
            fontSize: '1rem'
        }

        return (
            <div>
                <Container>
                    <Row style={rootStyle}>
                        <Col>State</Col>
                        <Col>Type</Col>
                        <Col>Start</Col>
                        <Col>End</Col>
                        <Col>1 fire</Col>
                        <Col>2 fire</Col>
                    </Row>
                    {this.state.jobPreviews.map(x =>
                        <Row key="{x.groupName}" style={groupStyle}>
                            <Col>{x.groupName}</Col>
                        </Row>
                        
                    )}
                </Container>

            </div>
        );
    }
}
//{
//    job.triggers.map(trigger =>
//        <TriggerComponent triggers={trigger} />
//    )
//}