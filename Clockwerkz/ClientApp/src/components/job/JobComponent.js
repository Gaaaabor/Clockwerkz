import React, { Component } from 'react';
import { Container, Row, Col } from 'reactstrap';

export class JobComponent extends Component {

    constructor(props) {
        super(props);
        this.state = {
            jobName: props.jobName
        };
    }

    render() {

        const containerStyle = {
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
                <Container style={containerStyle}>
                    <Row>
                        <Col>{this.state.jobName}</Col>
                    </Row>
                </Container>
                {this.props.children}
            </div>
        );
    }
}