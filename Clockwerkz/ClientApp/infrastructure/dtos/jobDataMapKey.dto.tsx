export enum JobDataMapInputType {
    Default = "Default",
    Dropdown = "Dropdown",
    Date = "Date"
}

export interface IDropdownValueDto {
    key: string;
    value: string;
}

export interface IJobDataMapKeyDto {
    label: string;
    name: string;
    type: JobDataMapInputType;
    dropdownValues: IDropdownValueDto[];
}