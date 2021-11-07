import { Component, OnInit } from '@angular/core';
import { Category } from 'src/app/shared/enums/category';
import { Formation } from 'src/app/shared/enums/formation';

import { GetFilteredTeachersRequest } from 'src/app/shared/models/teacher/getFilteredTeachersRequest.model';

import { PagedResult } from 'src/app/shared/models/pagedResult.model';

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


  request: GetFilteredTeachersRequest = {
    fio: "",
    experience: "",
    formation: "",
    category: ""
  };

  fio: string;
  experience: number;
  minFormation: number;
  minCategory: number;

  countOfTeachers: number;
  pageSize: number;
  pageSizeOptions: number[] = [5, 10, 20, 50];

  currentPage: number;

  
  columnsToDisplay = ["fio", "dateOfBirth", "department", "experience", "category", "formation", "actions"];

  CategoryKeys = Object.keys(Category).filter((item) => {
    return isNaN(Number(item));
  });

  FormationKeys = Object.keys(Formation).filter((item) => {
    return isNaN(Number(item));
  });


  ngOnInit() {
    this.pageSize = 10;
    this.currentPage = 1;

    this.loadTeachers();
  }

  loadTeachers() {
    this.teacherService.getAll(this.currentPage + 1, this.pageSize).subscribe((response: PagedResult<Teacher[]>) => {
      this.teachers = response.data;
      this.countOfTeachers = response.countAllDocuments
    })
  }

  delete(id: number) {
    this.teacherService.delete(id).subscribe(() => {
        this.loadTeachers()
      });
  }


  search() {
    if(this.fio)
    {
      this.request.fio = this.fio;
    }

    if(this.experience  )
    {
      this.request.experience = this.experience.toString();
    }

    if(this.minCategory)
    {
      this.request.category = this.minCategory.toString();
    }

    if(this.minFormation)
    {
      this.request.formation = this.minFormation.toString();
    }
    
    this.teacherService.getByFilter(this.request).subscribe((teachers: Teacher[]) => {
      this.teachers = teachers;
    });
  }

  handlePage(e: any) {
    this.currentPage = e.pageIndex;
    this.pageSize = e.pageSize;

    this.loadTeachers();
  }
}
