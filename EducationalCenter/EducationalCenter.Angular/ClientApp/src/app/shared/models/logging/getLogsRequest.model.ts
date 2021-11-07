import { LogType } from "../../enums/logType";

export interface GetLogsRequest {
    globalFilter: string,
    logType: string,
    dateFrom: string,
    dateTo: string
}