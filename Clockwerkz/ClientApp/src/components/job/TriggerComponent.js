import React, { Component } from 'react';
import { Container, Row, Col } from 'reactstrap';
import { Button } from 'reactstrap'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faPlus, faTrash } from '@fortawesome/free-solid-svg-icons'

export class TriggerComponent extends Component {

    constructor(props) {
        super(props);
        this.state = { trigger: props.trigger };
    }

    static getRowColor(triggerstate) {
        switch (triggerstate) {
            case "NORMAL":
                return "table-primary";
            case "PAUSED":
                return "table-secondary";
            case "COMPLETE":
                return "table-success";
            case "ERROR":
                return "table-danger";
            case "BLOCKED":
                return "table-warning";
            case "WAITING":
                return "table-primary";
            case "NONE":
                return "";
            default:
                return ""
        }
    };

    render() {

        const containerStyle = {
            width: '100%',
            verticalAlign: 'middle',
            layout: 'auto',
            border: '1px solid #454d55',
            backgroundColor: '#6c757d',
            color: 'white',
            fontWeight: '400',
            fontSize: '1rem'
        }

        return (
            <Row>
                <Col >{this.state.state}</Col>
                <Col >{this.state.type}</Col>
                <Col >{this.state.startTime}</Col>
                <Col >{this.state.endTime}</Col>
                <Col >{this.state.previousFireTime}</Col>
                <Col >{this.state.nextFireTime}</Col>
                <Col >
                    <FontAwesomeIcon xs="1" icon={faTrash} />
                </Col>
                <Col />
                <Col />
            </Row>
        );
    }
}
