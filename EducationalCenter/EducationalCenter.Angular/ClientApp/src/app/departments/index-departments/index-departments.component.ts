import { Component, OnInit } from '@angular/core';
import { Department } from 'src/app/shared/models/department/department.model';
import { DepartmentsService } from '../departments.service';

@Component({
  selector: 'app-index-departments',
  templateUrl: './index-departments.component.html',
  styleUrls: ['./index-departments.component.css']
})
export class IndexDepartmentsComponent implements OnInit {

  constructor(private departmentsService: DepartmentsService) { }

  departments: Department[] | undefined;
  columnsToDisplay = ["name"];

  ngOnInit() {
    this.loadDepartments();
  }

  loadDepartments() {
    this.departmentsService.getAll().subscribe((departments: Department[]) => {
      this.departments = departments;
    })
  }

}
