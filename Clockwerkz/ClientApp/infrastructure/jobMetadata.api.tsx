import * as Axios from 'axios';
import { IJobDataMapKeyDto } from '../infrastructure/dtos/jobDataMapKey.dto';
import { IJobTypeDto } from './dtos/jobType.dto';
import { jobMetadatasPath } from './path.provider';


const getJobTypes = (): Promise<IJobTypeDto[]> => {
    return Axios.default.get<IJobTypeDto[]>(`${jobMetadatasPath}/jobtypes`).then(response => response.data);
};

const getJobDataMapKeys = (dataMapGroup: string): Promise<IJobDataMapKeyDto[]> => {
    return Axios.default.get<IJobDataMapKeyDto[]>(`${jobMetadatasPath}/jobdatamapkeys/${dataMapGroup}`).then(response => response.data);
};

export const JobMetadatasApi = {
    getJobTypes,
    getJobDataMapKeys
};