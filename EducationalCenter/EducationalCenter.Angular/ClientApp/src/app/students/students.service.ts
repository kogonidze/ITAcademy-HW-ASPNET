import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Student } from '../shared/models/student/student.model';
import { StudentCreation } from '../shared/models/student/studentCreation.model';
import { StudentFullInfo } from '../shared/models/student/studentFullInfo.model';

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

  getById(id: number): Observable<StudentFullInfo> {
    return this.http.get<StudentFullInfo>(`${this.apiUrl}/${id}`, {headers: this.headers});
  }

  create(studentCreation: StudentCreation) {
    return this.http.post(this.apiUrl, studentCreation, {headers: this.headers, responseType: 'text'});
  }

  delete(id: number) {
    return this.http.delete(`${this.apiUrl}/${id}`, {headers: this.headers, responseType: 'text'});
  }
}
