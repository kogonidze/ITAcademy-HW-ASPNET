import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { PagedResult } from '../shared/models/pagedResult.model';
import { Teacher } from '../shared/models/teacher/teacher.model';
import { TeacherCreation } from '../shared/models/teacher/teacherCreation.model';
import { TeacherFullInfo } from '../shared/models/teacher/teacherFullInfo.model';
import { GetFilteredTeachersRequest } from '../shared/models/teacher/getFilteredTeachersRequest.model';

@Injectable({
  providedIn: 'root'
})
export class TeachersService {

  constructor(private http: HttpClient) { }

  private apiUrl = environment.apiUrl + 'teachers';
  headers = new HttpHeaders({ 'Authorization': 'Bearer ' + localStorage.getItem("token") });

  getAll(page: number, pageSize: number): Observable<PagedResult<Teacher[]>> {
    return this.http.get<PagedResult<Teacher[]>>(`${this.apiUrl}?page=${page}&pageSize=${pageSize}`, { headers: this.headers });
  }

  getById(id: number): Observable<TeacherFullInfo> {
    return this.http.get<TeacherFullInfo>(`${this.apiUrl}/${id}`, { headers: this.headers });
  }

  create(teacherCreation: TeacherCreation) {
    return this.http.post(this.apiUrl, teacherCreation, { headers: this.headers, responseType: 'text' });
  }

  edit(teacherEdition: TeacherFullInfo) {
    return this.http.put(this.apiUrl, teacherEdition, { headers: this.headers, responseType: 'text' });
  }

  delete(id: number) {
    return this.http.delete(`${this.apiUrl}/${id}`, { headers: this.headers, responseType: 'text' });
  }

  getByFilter(request: GetFilteredTeachersRequest): Observable<PagedResult<Teacher[]>> {
    return this.http.get<PagedResult<Teacher[]>>(`${this.apiUrl}/search`, {
      headers: this.headers, params: {
        FIO: request.fio,
        Experience: request.experience,
        Formation: request.formation,
        Category: request.category,
        Page: request.page,
        PageSize: request.pageSize
      },
    });
  }
}
