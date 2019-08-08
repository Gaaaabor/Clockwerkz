import { faBolt, faEdit, faLightbulb, faPause, faPlay, faSync, faTrash, IconDefinition } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import * as React from 'react';
import { Button, Col, Row } from 'reactstrap';
import { IJobTriggerDto } from '../../infrastructure/dtos/jobTrigger.dto';
import { TriggersApi } from '../../infrastructure/trigger.api';

interface IJobTriggerProps {    
    triggers: IJobTriggerDto[];
}

interface IJobTriggerState {    
    triggers: IJobTriggerDto[];
}

export class JobTrigger extends React.Component<IJobTriggerProps, IJobTriggerState> {

    constructor(props: IJobTriggerProps) {
        super(props);
        this.state = {            
            triggers: props.triggers
        };
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

    private getTypeIcon(triggerType: string): JSX.Element {

        var icon: IconDefinition = faLightbulb;

        switch (triggerType) {

            case "SIMPLE":
                icon = faBolt;
                break;

            default:
                icon = faSync;
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

    private editTrigger(name: string, groupName: string) {
        console.log("Edit");
    }

    private deleteTrigger(name: string, groupName: string) {
        TriggersApi.deleteTrigger({
            name: name,
            groupName: groupName
        });
    }

    public render(): JSX.Element {

        const triggerStyle: React.CSSProperties = {
            verticalAlign: 'middle',
            fontWeight: 400,
            fontSize: '1rem',
            textAlign: 'center',
            borderBottom: '1px black solid',
            lineHeight: "34px"
        }

        const iconColumnStyle: React.CSSProperties = {
            borderRight: '1px black solid',
            maxWidth: "50px",
            padding: "0px"
        }

        const dateColumnStyle: React.CSSProperties = {
            borderRight: '1px black solid'
        }

        const buttonColumnStyle: React.CSSProperties = {
            borderRight: '1px black solid',
            maxWidth: "50px",
            padding: "0px",
        }        

        return (
            <div>
                {this.state.triggers.map(trigger =>
                    <Row key={trigger.name} style={triggerStyle} className={this.getRowColor(trigger.state)}>

                        <Col style={iconColumnStyle}>{this.getStateIcon(trigger.state)}</Col>
                        <Col style={iconColumnStyle}>{this.getTypeIcon(trigger.type)}</Col>

                        <Col style={dateColumnStyle}>{this.parseDateTimeOffset(trigger.startTime)}</Col>
                        <Col style={dateColumnStyle}>{this.parseDateTimeOffset(trigger.endTime)}</Col>
                        <Col style={dateColumnStyle}>{this.parseDateTimeOffset(trigger.previousFireTime)}</Col>
                        <Col style={dateColumnStyle}>{this.parseDateTimeOffset(trigger.nextFireTime)}</Col>

                        <Col style={buttonColumnStyle} onClick={() => this.editTrigger(trigger.name, trigger.jobGroup)}>
                            <Button>
                                <FontAwesomeIcon icon={faEdit} />
                            </Button>
                        </Col>
                        <Col style={buttonColumnStyle} onClick={() => this.deleteTrigger(trigger.name, trigger.jobGroup)}>
                            <Button>
                                <FontAwesomeIcon icon={faTrash} />
                            </Button>
                        </Col>

                    </Row>
                )}
            </div>
        );
    }
}
