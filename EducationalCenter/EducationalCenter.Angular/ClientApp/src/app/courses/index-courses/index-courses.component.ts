import { Component, OnInit } from "@angular/core";
import { AuthorizationService } from "src/authorization/authorization.service";
import { Course } from "../../shared/models/course/course.model";
import { CoursesService } from "../courses.service";

@Component({
  selector: "app-index-courses",
  templateUrl: "./index-courses.component.html",
  styleUrls: ["./index-courses.component.css"],
})
export class IndexCoursesComponent implements OnInit {
  public isUserAdmin: boolean;
  public isUserManager: boolean;

  constructor(private coursesService: CoursesService, private authService: AuthorizationService,) {
    this.isUserAdmin = this.authService.isUserAdmin();
    this.isUserManager = this.authService.isUserManager();
  }

  courses: Course[] | undefined;
  columnsToDisplay = [];


  ngOnInit(): void {
    this.coursesService.get().subscribe((courses: Course[]) => {
      this.courses = courses;
    });

    this.isUserAdmin = this.authService.isUserAdmin();
    this.isUserManager = this.authService.isUserManager();

    if (this.isUserAdmin || this.isUserManager) {
      this.columnsToDisplay = ["title", "description", "hoursCount", "controlForm", "actions"]
    }
    else {
      this.columnsToDisplay = ["title", "description", "hoursCount", "controlForm"]
    }

  }
}
