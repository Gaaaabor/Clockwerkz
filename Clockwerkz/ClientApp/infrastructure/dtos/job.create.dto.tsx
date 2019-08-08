import { IJobDataMapDto } from './jobDataMap.dto';

export interface IJobCreateDto {
    jobName: string;
    groupName: string;
    cronExpression: string;
    jobDataMap: IJobDataMapDto
}