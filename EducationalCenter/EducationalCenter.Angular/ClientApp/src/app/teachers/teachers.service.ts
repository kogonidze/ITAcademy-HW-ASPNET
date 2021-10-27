import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Teacher } from '../shared/models/teacher/teacher.model';
import { TeacherFullInfo } from '../shared/models/teacher/teacherFullInfo.model';

@Injectable({
  providedIn: 'root'
})
export class TeachersService {

  constructor(private http: HttpClient) { }

  private apiUrl = environment.apiUrl + 'teachers';
  headers = new HttpHeaders({ 'Authorization': 'Bearer ' + localStorage.getItem("token") });

  getAll(): Observable<Teacher[]> {
    return this.http.get<Teacher[]>(this.apiUrl, {headers: this.headers});
  }

  getById(id: number): Observable<TeacherFullInfo> {
    return this.http.get<TeacherFullInfo>(`${this.apiUrl}/${id}`, {headers: this.headers});
  }
}
