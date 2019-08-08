import { IJobTriggerDto } from './jobTrigger.dto';

export interface IJobDto {
    name: string;
    jobGroup: string;
    triggers: IJobTriggerDto[];
}