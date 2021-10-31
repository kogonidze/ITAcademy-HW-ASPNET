import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Faculty } from '../shared/models/faculty/faculty.model';

@Injectable({
  providedIn: 'root'
})
export class FacultyService {

  constructor(private http: HttpClient) { }

  private apiUrl = environment.apiUrl + 'faculties';
  headers = new HttpHeaders({ 'Authorization': 'Bearer ' + localStorage.getItem("token") });

  getAll(): Observable<Faculty[]> {
    return this.http.get<Faculty[]>(this.apiUrl, {headers: this.headers});
  }

  getById(id: number): Observable<Faculty> {
    return this.http.get<Faculty>(`${this.apiUrl}/${id}`, {headers: this.headers});
  }
}
