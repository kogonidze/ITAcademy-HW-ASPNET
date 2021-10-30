import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { DepartmentsService } from 'src/app/departments/departments.service';
import { Category } from 'src/app/shared/enums/category';
import { Formation } from 'src/app/shared/enums/formation';
import { Department } from 'src/app/shared/models/department/department.model';
import { TeacherFullInfo } from 'src/app/shared/models/teacher/teacherFullInfo.model';
import { TeachersService } from '../teachers.service';

@Component({
  selector: 'app-edit-teacher',
  templateUrl: './edit-teacher.component.html',
  styleUrls: ['./edit-teacher.component.css']
})
export class EditTeacherComponent implements OnInit {

  constructor(private activatedRoutes: ActivatedRoute,
    private teachersService: TeachersService,
    private departmentsService: DepartmentsService, 
    private router: Router, private formBuilder: FormBuilder) { }

  editTeacherForm: FormGroup;
  teacher: TeacherFullInfo | undefined;
  departments: Department[] | undefined;
  Category = Object.keys(Category).filter((item) => {
    return isNaN(Number(item));
  });
  Formation = Object.keys(Formation).filter((item) => {
    return isNaN(Number(item));
  });

  ngOnInit() : void {
    this.editTeacherForm = this.formBuilder.group({
      firstName: [null, [Validators.required]],
      lastName: [null, [Validators.required]],
      dateOfBirth: [null],
      eMail: [null, [Validators.required]],
      phoneNumber: [null, [Validators.required]],
      departmentId: [null],
      experience: [null, [Validators.required]],
      category: [null, [Validators.required]],
      formation: [null, [Validators.required]],
      salary: [null, [Validators.required]]
    })

    this.activatedRoutes.params.subscribe(params => {
      this.teachersService.getById(params.id).subscribe((teacher: TeacherFullInfo) => {
        this.teacher = teacher;

        this.editTeacherForm.patchValue(this.teacher);
      });
    })

    this.departmentsService.getAll().subscribe((departments: Department[]) => {
      this.departments = departments;
    });
  }

  saveChanges() {
    this.teacher.firstName = this.editTeacherForm.get("firstName").value;
    this.teacher.lastName = this.editTeacherForm.get("lastName").value;
    this.teacher.dateOfBirth = this.editTeacherForm.get("dateOfBirth").value;
    this.teacher.eMail = this.editTeacherForm.get("eMail").value;
    this.teacher.phoneNumber = this.editTeacherForm.get("phoneNumber").value;
    this.teacher.departmentId = this.editTeacherForm.get("departmentId").value;
    this.teacher.experience = this.editTeacherForm.get("experience").value;
    this.teacher.category = this.editTeacherForm.get("category").value;
    this.teacher.formation = this.editTeacherForm.get("formation").value;
    this.teacher.salary = this.editTeacherForm.get("salary").value;

    this.teachersService.edit(this.teacher).subscribe(() => {
      this.router.navigate(['/teachers']);
    })
  }

}
