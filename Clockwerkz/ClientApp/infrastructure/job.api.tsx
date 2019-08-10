import * as Axios from 'axios';
import { IJobCreateDto } from './dtos/job.create.dto';
import { IJobDto } from './dtos/job.dto';
import { jobsPath } from './path.provider';

const getJobs = (): Promise<IJobDto[]> => {
    return Axios.default.get<IJobDto[]>(`${jobsPath}`).then(response => response.data);
};

const createJob = (dto: IJobCreateDto): Promise<any> => {
    return Axios.default.post(`${jobsPath}`, dto).then(response => response.data);
};

const deleteJob = (jobId: string) => {    
};

export const JobsApi = {
    getJobs,
    createJob,
    deleteJob
};