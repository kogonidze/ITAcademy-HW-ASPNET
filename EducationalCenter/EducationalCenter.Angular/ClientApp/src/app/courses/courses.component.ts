import { Component, OnInit } from "@angular/core";
import { Course } from "../shared/models/course/course.model";
import { CoursesService } from "./courses.service";

@Component({
  selector: "app-courses",
  templateUrl: "./courses.component.html",
  styleUrls: ["./courses.component.css"],
})
export class CoursesComponent implements OnInit {
  constructor(private coursesService: CoursesService) {}

  courses: Course[] | undefined;
  columnsToDisplay = ["title", "description", "hoursCount", "controlForm"];

  ngOnInit(): void {
    this.coursesService.get().subscribe((courses: Course[]) => {
      this.courses = courses;
    });
  }
}
