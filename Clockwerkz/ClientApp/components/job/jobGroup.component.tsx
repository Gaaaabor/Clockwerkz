import * as React from 'react';
import { Row, Col } from 'reactstrap';
import { JobsApi } from '../../infrastructure/job.api';

interface JobGroupProps {
    groupName: string
}

interface JobGroupState {
    groupName: string
}

export class JobGroup extends React.Component<JobGroupProps, JobGroupState> {

    constructor(props: JobGroupProps) {
        super(props);
        this.state = {
            groupName: props.groupName,
        };

    }

    render() {

        const groupStyle: React.CSSProperties = {
            verticalAlign: 'middle',
            tableLayout: 'auto',
            borderBottom: '1px solid #454d55',
            backgroundColor: '#343a40',
            color: 'white',
            fontWeight: 400,
            fontSize: '1rem'
        }

        const groupNameColumnStyle: React.CSSProperties = {
            paddingTop: "5px",
            paddingBottom: "5px"
        }

        return (
            <div>
                <Row style={groupStyle}>
                    <Col style={groupNameColumnStyle}>{this.state.groupName}</Col>
                </Row>
                {this.props.children}
            </div>
        );
    }
}
