import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { StudentGroup } from '../shared/models/studentGroup/studentGroup.model';

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
}
