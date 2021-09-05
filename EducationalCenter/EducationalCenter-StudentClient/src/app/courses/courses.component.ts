import { Component, OnInit } from '@angular/core';
import { CourseDTO } from '../shared/models/courseDTO.model';
import { CoursesService } from './courses.service';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.css']
})
export class CoursesComponent implements OnInit {

  constructor(private coursesService: CoursesService) { }

  courses: CourseDTO[] | undefined;
  columnsToDisplay = ['title', 'description', 'hoursCount', 'controlForm'];

  ngOnInit(): void {
    this.coursesService.get().subscribe((courses: CourseDTO[]) => {
      this.courses = courses;
    });
  }

}
