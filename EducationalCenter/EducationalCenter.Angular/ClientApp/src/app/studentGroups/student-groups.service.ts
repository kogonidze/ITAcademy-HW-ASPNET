import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { StudentGroup } from '../shared/models/studentGroup/studentGroup.model';
import { StudentGroupCreation } from '../shared/models/studentGroup/studentGroupCreation.model';
import { StudentGroupFullInfo } from '../shared/models/studentGroup/studentGroupFullInfo.model';

@Injectable({
  providedIn: 'root'
})
export class StudentGroupsService {

  constructor(private http: HttpClient) { }

  private apiUrl = environment.apiUrl + 'studentGroups';
  headers = new HttpHeaders({ 'Authorization': 'Bearer ' + localStorage.getItem("token") });

  getAll(): Observable<StudentGroup[]> {
    return this.http.get<StudentGroup[]>(this.apiUrl, {headers: this.headers});
  }

  getById(id: number): Observable<StudentGroup> {
    return this.http.get<StudentGroup>(`${this.apiUrl}/${id}`, {headers: this.headers});
  }

  create(studentGroupCreation: StudentGroupCreation) {
    return this.http.post(this.apiUrl, studentGroupCreation, {headers: this.headers, responseType: 'text'});
  }

  edit(studentGroupEdition: StudentGroupFullInfo) {
    return this.http.put(this.apiUrl, studentGroupEdition, {headers: this.headers, responseType: 'text'});
  }

  delete(id: number) {
    return this.http.delete(`${this.apiUrl}/${id}`, {headers: this.headers, responseType: 'text'});
  }
}
