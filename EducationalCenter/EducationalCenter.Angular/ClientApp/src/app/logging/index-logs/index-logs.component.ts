import { ConstantPool } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { LogType } from 'src/app/shared/enums/logType';
import { GetLogsRequest } from 'src/app/shared/models/logging/getLogsRequest.model';
import { Log } from 'src/app/shared/models/logging/log.model';
import { PagedResult } from 'src/app/shared/models/pagedResult.model';
import { LogsService } from '../logs.service';

@Component({
  selector: 'app-index-logs',
  templateUrl: './index-logs.component.html',
  styleUrls: ['./index-logs.component.css']
})
export class IndexLogsComponent implements OnInit {

  constructor(private logsService: LogsService) { }

  logs: Log[] | undefined;
  columnsToDisplay = ["id", "message", "username", "ip", "logType", "logDate"];
  LogType = LogType;
  request: GetLogsRequest = {
    globalFilter: "",
    logType: "",
    dateFrom: "",
    dateTo: "",
    page: "",
    pageSize: ""
  };

  globalFilter: string;
  chosenLogType: number;
  dateFrom: Date;
  dateTo: Date;

  countOfLogs: number;
  pageSize: number;
  pageSizeOptions: number[] = [5, 10, 20, 50];

  currentPage: number;
  IsSearchMode: boolean;

  LogTypeKeys = Object.keys(LogType).filter((item) => {
    return isNaN(Number(item));
  });

  ngOnInit() {
    this.pageSize = 10;
    this.currentPage = 0;
    this.IsSearchMode = false;

    this.loadLogs();
  }

  loadLogs() {
    this.logsService.getAll(this.currentPage + 1, this.pageSize).subscribe((response: PagedResult<Log[]>) => {
      this.logs = response.data;
      this.countOfLogs = response.countAllDocuments;
    });
  }

  public mySearch() {
    if (this.globalFilter) {
      this.request.globalFilter = this.globalFilter;
    }

    if (this.chosenLogType !== undefined) {
      this.request.logType = this.chosenLogType.toString();
    }

    if (this.dateFrom) {
      this.request.dateFrom = this.dateFrom.toDateString();
    }

    if (this.dateTo) {
      this.request.dateTo = this.dateTo.toDateString();
    }

    this.request.page = (this.currentPage + 1).toString();
    this.request.pageSize = this.pageSize.toString();

    this.IsSearchMode = true;

    this.logsService.getByFilter(this.request).subscribe((response: PagedResult<Log[]>) => {
      this.logs = response.data;
      this.countOfLogs = response.countAllDocuments;
    });
  }

  handlePage(e: any) {
    this.currentPage = e.pageIndex;
    this.pageSize = e.pageSize;

    if (this.IsSearchMode) {

      this.request.page = (this.currentPage + 1).toString();
      this.request.pageSize = this.pageSize.toString();

      this.logsService.getByFilter(this.request).subscribe((response: PagedResult<Log[]>) => {
        this.logs = response.data;
        this.countOfLogs = response.countAllDocuments;
      });
    }
    else {
      this.loadLogs();
    }
  }
}
