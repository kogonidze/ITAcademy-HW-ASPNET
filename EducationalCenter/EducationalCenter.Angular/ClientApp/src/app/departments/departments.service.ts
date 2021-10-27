import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Department } from '../shared/models/department/department.model';

@Injectable({
  providedIn: 'root'
})
export class DepartmentsService {

  constructor(private http: HttpClient) { }

  private apiUrl = environment.apiUrl + 'departments';
  headers = new HttpHeaders({ 'Authorization': 'Bearer ' + localStorage.getItem("token") });
  
  getAll(): Observable<Department[]> {
    return this.http.get<Department[]>(this.apiUrl, {headers: this.headers});
  }

  getById(id: number): Observable<Department> {
    return this.http.get<Department>(`${this.apiUrl}/${id}`, {headers: this.headers});
  }
}
