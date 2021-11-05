import { Component, OnInit } from '@angular/core';
import { LogType } from 'src/app/shared/enums/logType';
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

  ngOnInit() {
    this.loadLogs();
  }

  loadLogs() {
    this.logsService.getAll().subscribe((logs: Log[]) => {
      this.logs = logs;
    })
  }

}
