import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Student } from '../shared/models/student/student.model';

@Injectable({
  providedIn: 'root'
})
export class StudentsService {

  constructor(private http: HttpClient) { }

  private apiUrl = environment.apiUrl + 'students';
  headers = new HttpHeaders({ 'Authorization': 'Bearer ' + localStorage.getItem("token") });
  
  getAll(): Observable<Student[]> {
    return this.http.get<Student[]>(this.apiUrl, {headers: this.headers});
  }
}
