export interface IJobTriggerDto {
    name: string;
    jobGroup: string;
    state: string;
    type: string;
    startTime: number;
    endTime?: number;
    previousFireTime?: number;
    nextFireTime?: number;
}