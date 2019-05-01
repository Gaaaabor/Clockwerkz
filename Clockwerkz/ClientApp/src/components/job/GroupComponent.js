import React, { Component } from 'react';
import { Row, Col } from 'reactstrap';

export class GroupComponent extends Component {

    constructor(props) {
        super(props);
        this.state = {
            groupName: props.groupName,
        };

    }

    render() {

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

        return (
            <div>
                <Row style={groupStyle}>
                    <Col xs="auto">{this.state.groupName}</Col>
                </Row>
                {this.props.children}
            </div>
        );
    }
}
