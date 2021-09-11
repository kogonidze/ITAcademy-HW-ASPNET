import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { CourseDTO } from "../shared/models/courseDTO.model";

@Injectable({
  providedIn: "root",
})
export class CoursesService {
  constructor(private http: HttpClient) {}

  private apiUrl = environment.apiUrl + "courses";

  get(): Observable<CourseDTO[]> {
    return this.http.get<CourseDTO[]>(this.apiUrl);
  }
}
