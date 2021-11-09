export interface GetLogsRequest {
    globalFilter: string,
    logType: string,
    dateFrom: string,
    dateTo: string,
    page: string,
    pageSize: string
}