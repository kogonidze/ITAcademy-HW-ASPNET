import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { Course } from "../shared/models/course.model";

@Injectable({
  providedIn: "root",
})
export class CoursesService {
  constructor(private http: HttpClient) {}

  private apiUrl = environment.apiUrl + "courses";

  get(): Observable<Course[]> {
    return this.http.get<Course[]>(this.apiUrl);
  }
}
