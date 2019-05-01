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
            case "ACQUIRED":
                return "table-secondary";
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

        return (
            <div>
                {this.state.triggers.map(trigger =>
                    <Row key={trigger.id} style={triggerStyle} className={this.getRowColor(trigger.state)}>
                        <Col >{trigger.state}</Col>
                        <Col >{trigger.type}</Col>
                        <Col >{trigger.startTime}</Col>
                        <Col >{trigger.endTime}</Col>
                        <Col >{trigger.previousFireTime}</Col>
                        <Col >{trigger.nextFireTime}</Col>
                        <Col >
                            <FontAwesomeIcon xs="1" icon={faTrash} />
                        </Col>
                    </Row>
                )}
            </div>
        );
    }
}
