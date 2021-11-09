import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { PagedResult } from '../shared/models/pagedResult.model';
import { GetFilteredStudentsRequest } from '../shared/models/student/getFilteredStudentsRequest.model';
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
  
  getAll(page: number, pageSize: number): Observable<PagedResult<Student[]>> {
    return this.http.get<PagedResult<Student[]>>(`${this.apiUrl}?page=${page}&pageSize=${pageSize}`, {headers: this.headers});
  }

  getById(id: number): Observable<StudentFullInfo> {
    return this.http.get<StudentFullInfo>(`${this.apiUrl}/${id}`, {headers: this.headers});
  }

  create(studentCreation: StudentCreation) {
    return this.http.post(this.apiUrl, studentCreation, {headers: this.headers, responseType: 'text'});
  }

  edit(studentEdition: StudentFullInfo) {
    return this.http.put(this.apiUrl, studentEdition, {headers: this.headers, responseType: 'text'});
  }

  delete(id: number) {
    return this.http.delete(`${this.apiUrl}/${id}`, {headers: this.headers, responseType: 'text'});
  }

  getByFilter(request: GetFilteredStudentsRequest): Observable<PagedResult<Student[]>> {
    return this.http.get<PagedResult<Student[]>>(`${this.apiUrl}/search`, {
      headers: this.headers, params: {
        FIO: request.fio,
        GroupId: request.groupId,
        Page: request.page,
        PageSize: request.pageSize
      },
    });
  }
}
