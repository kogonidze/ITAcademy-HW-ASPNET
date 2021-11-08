import { Component, OnInit } from '@angular/core';
import { PagedResult } from 'src/app/shared/models/pagedResult.model';
import { GetFilteredStudentsRequest } from 'src/app/shared/models/student/getFilteredStudentsRequest.model';
import { Student } from 'src/app/shared/models/student/student.model';
import { StudentGroup } from 'src/app/shared/models/studentGroup/studentGroup.model';
import { StudentGroupsService } from 'src/app/studentGroups/student-groups.service';
import { StudentsService } from '../students.service';

@Component({
  selector: 'app-index-students',
  templateUrl: './index-students.component.html',
  styleUrls: ['./index-students.component.css']
})
export class IndexStudentsComponent implements OnInit {

  constructor(private studentsService: StudentsService,
    private studentGroupsService: StudentGroupsService) { }

  students: Student[] | undefined;
  studentGroups: StudentGroup[] | undefined;
  
  columnsToDisplay = ["fio", "dateOfBirth", "group", "actions"];
  
  request: GetFilteredStudentsRequest = {
    fio: "",
    groupId: "",
    page: "",
    pageSize: ""
  };

  fio: string;
  groupId: number;

  countOfStudents: number;
  pageSize: number;
  pageSizeOptions: number[] = [5, 10, 20, 50];

  currentPage: number;
  IsSearchMode: boolean;

  ngOnInit() : void {
    this.pageSize = 10;
    this.currentPage = 0;
    this.IsSearchMode = false;

    this.loadStudents();

    this.studentGroupsService.getAll().subscribe((studentGroups: StudentGroup[]) => {
      this.studentGroups = studentGroups;
    })
  }

  loadStudents() {
    this.studentsService.getAll(this.currentPage + 1, this.pageSize).subscribe((response: PagedResult<Student[]>) => {
      this.students = response.data;
      this.countOfStudents = response.countAllDocuments
    })
  }

  delete(id: number) {
    this.studentsService.delete(id).subscribe(response => {
        this.loadStudents()
      });
  }

  search() {
    if (this.fio) {
      this.request.fio = this.fio;
    }

    if (this.groupId !== undefined) {
      this.request.groupId = this.groupId.toString();
    }

    this.request.page = (this.currentPage + 1).toString();
    this.request.pageSize = this.pageSize.toString();

    this.IsSearchMode = true;

    this.studentsService.getByFilter(this.request).subscribe((response: PagedResult<Student[]>) => {
      this.students = response.data;
      this.countOfStudents = response.countAllDocuments;
    });
  }

  handlePage(e: any) {
    this.currentPage = e.pageIndex;
    this.pageSize = e.pageSize;

    if (this.IsSearchMode) {

      this.request.page = (this.currentPage + 1).toString();
      this.request.pageSize = this.pageSize.toString();

      this.studentsService.getByFilter(this.request).subscribe((response: PagedResult<Student[]>) => {
        this.students = response.data;
        this.countOfStudents = response.countAllDocuments;
      });
    }
    else {
      this.loadStudents();
    }
  }
}
