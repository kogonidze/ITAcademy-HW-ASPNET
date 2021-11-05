import { ConstantPool } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { LogType } from 'src/app/shared/enums/logType';
import { GetLogsRequest } from 'src/app/shared/models/logging/getLogsRequest.model';
import { Log } from 'src/app/shared/models/logging/log.model';
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
    dateTo: ""
  };
  chosenLogType: number;
  dateFrom: Date;
  dateTo: Date;

  LogTypeKeys = Object.keys(LogType).filter((item) => {
    return isNaN(Number(item));
  });
  

  globalFilter: string;
  

  ngOnInit() {
    this.loadLogs();
  }

  loadLogs() {
    this.logsService.getAll().subscribe((logs: Log[]) => {
      this.logs = logs;
    })
  }

  public mySearch() {
    if(this.globalFilter)
    {
      this.request.globalFilter = this.globalFilter;
    }

    if(this.chosenLogType)
    {
      this.request.logType = this.chosenLogType.toString();
    }

    if(this.dateFrom)
    {
      this.request.dateFrom = this.dateFrom.toDateString();
    }

    if(this.dateTo)
    {
      this.request.dateTo = this.dateTo.toDateString();
    }
    
    this.logsService.getByFilter(this.request).subscribe((logs: Log[]) => {
      this.logs = logs;
    });
  }

}
