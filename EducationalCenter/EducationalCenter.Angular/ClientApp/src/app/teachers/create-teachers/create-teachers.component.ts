import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { DepartmentsService } from 'src/app/departments/departments.service';
import { Department } from 'src/app/shared/models/department/department.model';
import { TeachersService } from '../teachers.service';

@Component({
  selector: 'app-create-teachers',
  templateUrl: './create-teachers.component.html',
  styleUrls: ['./create-teachers.component.css']
})
export class CreateTeachersComponent implements OnInit {

  createTeacherForm: FormGroup;
  departments: Department[] | undefined;

  constructor(private teacherService: TeachersService, 
    private departmentService: DepartmentsService, 
    private router: Router,
    private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.departmentService.getAll().subscribe((departments: Department[]) => {
      this.departments = departments;
    })

    this.createTeacherForm = this.formBuilder.group({
      firstName: [null, [Validators.required]],
      lastName: [null, [Validators.required]],
      dateOfBirth: [null],
      email: [null, [Validators.required]],
      phoneNumber: [null, [Validators.required]],
      departmentId: [null],
      experience: [null, [Validators.required]],
      category: [null, [Validators.required]],
      formation: [null, [Validators.required]],
      salary: [null, [Validators.required]]
    });
  }

  saveChanges() {
    this.teacherService.create(this.createTeacherForm.value).subscribe(() => {
      this.router.navigate(['/teachers']);
    })
  }

}
