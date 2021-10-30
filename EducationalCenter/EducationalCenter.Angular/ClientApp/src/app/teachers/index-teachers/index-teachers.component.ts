import { Component, OnInit } from '@angular/core';
import { Category } from 'src/app/shared/enums/category';
import { Formation } from 'src/app/shared/enums/formation';
import { Teacher } from 'src/app/shared/models/teacher/teacher.model';
import { TeachersService } from '../teachers.service';

@Component({
  selector: 'app-index-teachers',
  templateUrl: './index-teachers.component.html',
  styleUrls: ['./index-teachers.component.css']
})
export class IndexTeachersComponent implements OnInit {

  constructor(private teacherService: TeachersService) { }

  teachers: Teacher[] | undefined;
  Category = Category;
  Formation = Formation;
  
  columnsToDisplay = ["fio", "dateOfBirth", "department", "experience", "category", "formation", "actions"];

  ngOnInit() {
    this.loadTeachers();
  }

  loadTeachers() {
    this.teacherService.getAll().subscribe((teachers: Teacher[]) => {
      this.teachers = teachers;
    })
  }

  delete(id: number) {
    this.teacherService.delete(id).subscribe(() => {
        this.loadTeachers()
      });
  }
}
