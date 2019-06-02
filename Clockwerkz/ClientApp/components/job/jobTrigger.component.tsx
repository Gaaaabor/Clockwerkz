import * as React from 'react';
import { Row, Col } from 'reactstrap';
//import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
//import { faTrash } from '@fortawesome/free-solid-svg-icons';
import { JobTriggerDto } from './jobPreview.component';

//<FontAwesomeIcon size="1" icon={faTrash} />

interface JobTriggerProps {
    triggers: any[];
}

interface JobTriggerState {
    triggers: JobTriggerDto[];
}

export class JobTrigger extends React.Component<JobTriggerProps, JobTriggerState> {

    constructor(props: JobTriggerProps) {
        super(props);
        this.state = { triggers: props.triggers };
    }

    getRowColor(triggerstate: string) {

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

    parseDateTimeOffset(value?: number) {

        if (!value) {
            return null;
        }

        //The mindate is 1970-01-01
        const minDate: number = 621355968000000000;
        return new Date((value - minDate) / 10000).toLocaleString("hu-hu");
    }

    render() {

        const triggerStyle: React.CSSProperties = {
            width: '100%',
            verticalAlign: 'middle',
            tableLayout: 'auto',
            fontWeight: 400,
            fontSize: '1rem',
            textAlign: 'center'
        }

        const dateStyle: React.CSSProperties = {
            borderRight: '1px black solid',
            fontSize: '0.8rem'
        }

        const columnStyle: React.CSSProperties = {
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
                            Trashbin
                        </Col>
                    </Row>
                )}
            </div>
        );
    }
}
