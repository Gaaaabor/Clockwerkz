import React, { Component } from 'react';
import { Row, Col } from 'reactstrap';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faTrash } from '@fortawesome/free-solid-svg-icons'

export class TriggerComponent extends Component {

    constructor(props) {
        super(props);
        this.state = { triggers: props.triggers };
    }

    getRowColor(triggerstate) {

        switch (triggerstate) {

            case "WAITING":
                return "table-secondary";
            case "ACQUIRED":
                return "table-info";
            case "EXECUTING":
                return "table-info";
            case "COMPLETE":
                return "table-success";
            case "PAUSED":
                return "table-warning";
            case "BLOCKED":
                return "table-warning";
            case "PAUSEDANDBLOCKED":
                return "table-warning";
            case "ERROR":
                return "table-danger";
            default:
                return "table-primary"
        }
    };

    render() {

        const triggerStyle = {
            width: '100%',
            verticalAlign: 'middle',
            layout: 'auto',
            fontWeight: '400',
            fontSize: '1rem'
        }

        const columnStyle = {
            borderRight: '1px black solid'
        }

        return (
            <div>
                {this.state.triggers.map(trigger =>
                    <Row key={trigger.id} style={triggerStyle} className={this.getRowColor(trigger.state)}>
                        <Col style={columnStyle}>{trigger.state}</Col>
                        <Col style={columnStyle}>{trigger.type}</Col>
                        <Col style={columnStyle}>{trigger.startTime}</Col>
                        <Col style={columnStyle}>{trigger.endTime}</Col>
                        <Col style={columnStyle}>{trigger.previousFireTime}</Col>
                        <Col style={columnStyle}>{trigger.nextFireTime}</Col>
                        <Col >
                            <FontAwesomeIcon xs="1" icon={faTrash} />
                        </Col>
                    </Row>
                )}
            </div>
        );
    }
}
