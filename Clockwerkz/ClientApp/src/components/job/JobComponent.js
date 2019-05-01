import React, { Component } from 'react';
import { Row, Col } from 'reactstrap';

export class JobComponent extends Component {

    constructor(props) {
        super(props);
        this.state = {
            jobName: props.jobName
        };
    }

    render() {

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
                <Row style={jobStyle}>
                    <Col>{this.state.jobName}</Col>
                </Row>
                {this.props.children}
            </div>
        );
    }
}