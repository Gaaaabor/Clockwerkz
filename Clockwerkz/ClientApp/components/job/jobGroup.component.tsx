import * as React from 'react';
import { Row, Col } from 'reactstrap';

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
            width: '100%',
            verticalAlign: 'middle',
            tableLayout: 'auto',
            border: '1px solid #454d55',
            backgroundColor: '#343a40',
            color: 'white',
            fontWeight: 400,
            fontSize: '1rem'
        }

        return (
            <div>
                <Row style={groupStyle}>
                    <Col>{this.state.groupName}</Col>
                </Row>
                {this.props.children}
            </div>
        );
    }
}
