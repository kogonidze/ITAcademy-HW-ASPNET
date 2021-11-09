import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { GetLogsRequest } from '../shared/models/logging/getLogsRequest.model';
import { Log } from '../shared/models/logging/log.model';
import { PagedResult } from '../shared/models/pagedResult.model';

@Injectable({
  providedIn: 'root'
})
export class LogsService {

  constructor(private http: HttpClient) { }

  private apiUrl = environment.apiUrl + 'logs';
  headers = new HttpHeaders({ 'Authorization': 'Bearer ' + localStorage.getItem("token") });

  getAll(page: number, pageSize: number): Observable<PagedResult<Log[]>> {
    return this.http.get<PagedResult<Log[]>>(`${this.apiUrl}?page=${page}&pageSize=${pageSize}`, { headers: this.headers });
  }

  getByFilter(request: GetLogsRequest): Observable<PagedResult<Log[]>> {
    return this.http.get<PagedResult<Log[]>>(this.apiUrl, {
      headers: this.headers, params: {
        GlobalFilter: request.globalFilter,
        LogType: request.logType,
        DateFrom: request.dateFrom,
        DateTo: request.dateTo,
        Page: request.page,
        PageSize: request.pageSize
      },
    });
  }
}
