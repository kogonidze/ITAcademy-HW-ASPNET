import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Log } from '../shared/models/logging/log.model';

@Injectable({
  providedIn: 'root'
})
export class LogsService {

  constructor(private http: HttpClient) { }

  private apiUrl = environment.apiUrl + 'logs';
  headers = new HttpHeaders({ 'Authorization': 'Bearer ' + localStorage.getItem("token") });
  
  getAll(): Observable<Log[]> {
    return this.http.get<Log[]>(this.apiUrl, {headers: this.headers});
  }
}
