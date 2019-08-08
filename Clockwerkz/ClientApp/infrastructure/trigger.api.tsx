import * as Axios from 'axios';
import { ITriggerDeleteDto } from './dtos/trigger.delete.dto';
import { triggersPath } from './path.provider';

const deleteTrigger = (dto: ITriggerDeleteDto): Promise<any> => {
    return Axios.default.delete(triggersPath, {
        data: dto
    }).then(response => response.data)
};

export const TriggersApi = {
    deleteTrigger
};