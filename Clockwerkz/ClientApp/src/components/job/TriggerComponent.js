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
                return "btn-secondary";
            case "ACQUIRED":
                return "btn-info";
            case "EXECUTING":
                return "btn-info";
            case "COMPLETE":
                return "btn-success";
            case "PAUSED":
                return "btn-warning";
            case "BLOCKED":
                return "btn-warning";
            case "PAUSEDANDBLOCKED":
                return "btn-warning";
            case "ERROR":
                return "btn-danger";
            default:
                return "btn-primary"
        }
    };

    parseDateTimeOffset(value) {

        if (!value) {
            return null;
        }

        //The mindate is 1970-01-01
        const minDate = 621355968000000000;
        return new Date((value - minDate) / 10000).toLocaleString("hu-hu");
    }

    render() {

        const triggerStyle = {
            width: '100%',
            verticalAlign: 'middle',
            layout: 'auto',
            fontWeight: '400',
            fontSize: '1rem',
            textAlign: 'center'
        }

        const dateStyle = {
            borderRight: '1px black solid',
            fontSize: '0.8rem'            
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
                        <Col style={dateStyle}>{this.parseDateTimeOffset(trigger.startTime)}</Col>
                        <Col style={dateStyle}>{this.parseDateTimeOffset(trigger.endTime)}</Col>
                        <Col style={dateStyle}>{this.parseDateTimeOffset(trigger.previousFireTime)}</Col>
                        <Col style={dateStyle}>{this.parseDateTimeOffset(trigger.nextFireTime)}</Col>
                        <Col >
                            <FontAwesomeIcon xs="1" icon={faTrash} />
                        </Col>
                    </Row>
                )}
            </div>
        );
    }
}
