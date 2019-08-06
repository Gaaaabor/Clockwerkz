import * as React from 'react';
import { Col, Input, Label, FormGroup, Dropdown, DropdownItem, DropdownToggle, DropdownMenu } from 'reactstrap';

export interface IJobDataMapKey {
    label: string;
    name: string;
    type: JobDataMapInputType;
    dropdownValues: IDropdownValue[];
}

export interface IDropdownValue {
    key: string;
    value: string;
}

export enum JobDataMapInputType {
    Default = "Default",
    Dropdown = "Dropdown",
    Date = "Date"
}

interface IJobDataMapInputProps {
    jobDataMapKey: IJobDataMapKey;
    onChange: (prop: string, value: string) => void;
}

interface IJobDataMapInputState {
    label: string;
    propertyName: string;
    type: JobDataMapInputType;
    inputValue: string;
    dropdownValues: IDropdownValue[];
    isDropdownOpen: boolean;
    onChange: (prop: string, value: string) => void;
}

export class JobDataMapInput extends React.Component<IJobDataMapInputProps, IJobDataMapInputState> {

    constructor(props: IJobDataMapInputProps) {
        super(props);

        this.state = {
            label: props.jobDataMapKey.label,
            propertyName: props.jobDataMapKey.name,
            type: props.jobDataMapKey.type,
            inputValue: "",
            dropdownValues: props.jobDataMapKey.dropdownValues,
            isDropdownOpen: false,
            onChange: props.onChange
        };
    }

    private handleChange(event: React.ChangeEvent<HTMLInputElement>) {

        const onChange = this.state.onChange;
        const prop = event.currentTarget.id;
        const value = event.currentTarget.value;

        this.setState((prevState) => {
            return {
                ...prevState,
                inputValue: value
            };
        });

        onChange(prop, value);
    }

    private handleToggle() {
        this.setState((prevState) => {
            return {
                ...prevState,
                isDropdownOpen: !prevState.isDropdownOpen
            };
        });
    }

    private handleDropDownClick(prop: string, value: string) {

        const onChange = this.state.onChange;

        this.setState((prevState) => {
            return {
                ...prevState,
                inputValue: value
            };
        });

        onChange(prop, value);
    }

    private getSelectedItemDisplayName(dropdownValues: IDropdownValue[], dropdownValue: string): string {

        if (dropdownValue === '' || dropdownValue === undefined) {
            return 'Please select a value';
        }

        var found = dropdownValues.find(x => x.value === dropdownValue);
        if (found === undefined) {
            return 'Please select a value';
        }

        return found.key;
    }

    private getInput(label: string, propertyName: string, type: JobDataMapInputType): JSX.Element {

        switch (type) {

            case JobDataMapInputType.Dropdown:

                console.log("getInput " + type);

                const dropdownStyle: React.CSSProperties = {
                    width: '100%'
                }

                const isDropdownOpen = this.state.isDropdownOpen;
                const dropdownValues = this.state.dropdownValues;
                const inputValue = this.state.inputValue;

                const selectedItemDisplayName = this.getSelectedItemDisplayName(dropdownValues, inputValue);

                return (
                    <Dropdown style={dropdownStyle} isOpen={isDropdownOpen} toggle={this.handleToggle.bind(this)}>
                        <DropdownToggle caret style={dropdownStyle} >
                            {selectedItemDisplayName}
                        </DropdownToggle>
                        <DropdownMenu style={dropdownStyle}>
                            {dropdownValues.map(x =>
                                <DropdownItem style={dropdownStyle} onClick={this.handleDropDownClick.bind(this, propertyName, x.value)} key={x.value}>{x.key}</DropdownItem>
                            )}
                        </DropdownMenu>
                    </Dropdown>
                )

            case JobDataMapInputType.Date:
                return <Input id={propertyName} type="datetime" placeholder={label} onChange={this.handleChange.bind(this)} />
            default:
                return <Input id={propertyName} placeholder={label} onChange={this.handleChange.bind(this)} />
        }
    };

    public render(): JSX.Element {

        const label = this.state.label;
        const propertyName = this.state.propertyName;
        const type = this.state.type;

        const input = this.getInput(label, propertyName, type);

        return (
            <div>
                <FormGroup row>
                    <Label for={propertyName} sm={3}>{label}</Label>
                    <Col sm={9}>
                        {input}
                    </Col>
                </FormGroup>
            </div>
        );
    }
}
