import { LogType } from "../../enums/logType";

export interface Log {
    id: number,
    message: string,
    userName: string,
    ip: string,
    logType: LogType,
    logDate: Date
}