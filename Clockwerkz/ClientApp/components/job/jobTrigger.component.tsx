import * as React from 'react';
import { Row, Col } from 'reactstrap';
import { IJobTriggerDto } from './jobPreview.component';

import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faLightbulb, faPause, faPlay, faCog, faEdit, faTrash, faExclamation, IconDefinition } from '@fortawesome/free-solid-svg-icons';

interface IJobTriggerProps {
    triggers: IJobTriggerDto[];
}

interface IJobTriggerState {
    triggers: IJobTriggerDto[];
}

export class JobTrigger extends React.Component<IJobTriggerProps, IJobTriggerState> {

    constructor(props: IJobTriggerProps) {
        super(props);
        this.state = { triggers: props.triggers };
    }

    private getRowColor(triggerstate: string): string {

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

    private getStateIcon(triggerState: string): JSX.Element {

        var icon: IconDefinition = faLightbulb;

        switch (triggerState) {

            case "WAITING":
                icon = faPause;
                break;
            case "ACQUIRED":

                break;
            case "EXECUTING":
                icon = faPlay;
                break;
            case "COMPLETE":

                break;
            case "PAUSED":

                break;
            case "BLOCKED":

                break;
            case "PAUSEDANDBLOCKED":

                break;
            case "ERROR":

                break;
            default:
                icon = faLightbulb;
                break;
        }

        return <FontAwesomeIcon icon={icon} />
    }

    private parseDateTimeOffset(value?: number): string {

        if (!value) {
            return "";
        }

        //The mindate is 1970-01-01
        const minDate: number = 621355968000000000;
        return new Date((value - minDate) / 10000).toLocaleString("hu-hu");        
    }

    public render(): JSX.Element {

        const triggerStyle: React.CSSProperties = {
            verticalAlign: 'middle',
            fontWeight: 400,
            fontSize: '1rem',
            textAlign: 'center'
        }

        const columnStyle: React.CSSProperties = {
            borderRight: '1px black solid',
            minHeight: '30px'
        }

        const stateColumnStyle: React.CSSProperties = {
            borderRight: '1px black solid',
            width: '30px'
        }

        const dateStyle: React.CSSProperties = {
            borderRight: '1px black solid',
            minHeight: '30px'
        }

        const iconStyle: React.CSSProperties = {
            marginLeft: 10,
            marginRight: 10
        }

        return (
            <div>
                {this.state.triggers.map(trigger =>
                    <Row key={trigger.id} style={triggerStyle} className={this.getRowColor(trigger.state)}>
                        <Col style={stateColumnStyle}>{this.getStateIcon(trigger.state)}</Col>
                        <Col style={columnStyle}>{trigger.type}</Col>
                        <Col style={dateStyle}>{this.parseDateTimeOffset(trigger.startTime)}</Col>
                        <Col style={dateStyle}>{this.parseDateTimeOffset(trigger.endTime)}</Col>
                        <Col style={dateStyle}>{this.parseDateTimeOffset(trigger.previousFireTime)}</Col>
                        <Col style={dateStyle}>{this.parseDateTimeOffset(trigger.nextFireTime)}</Col>
                        <Col >
                            <FontAwesomeIcon icon={faEdit} style={iconStyle} />
                            <FontAwesomeIcon icon={faTrash} style={iconStyle} />
                        </Col>
                    </Row>
                )}
            </div>
        );
    }
}
