import { Component, OnInit } from '@angular/core';
import { Student } from 'src/app/shared/models/student/student.model';
import { StudentsService } from '../students.service';

@Component({
  selector: 'app-index-students',
  templateUrl: './index-students.component.html',
  styleUrls: ['./index-students.component.css']
})
export class IndexStudentsComponent implements OnInit {

  constructor(private studentsService: StudentsService) { }

  students: Student[] | undefined;
  columnsToDisplay = ["fio", "dateOfBirth", "group"];
  
  ngOnInit() : void {
    this.studentsService.getAll().subscribe((students: Student[]) => {
      this.students = students;
    })
  }

}
