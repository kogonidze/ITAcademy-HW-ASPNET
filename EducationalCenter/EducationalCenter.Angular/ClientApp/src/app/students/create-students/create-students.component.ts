import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { StudentCreation } from 'src/app/shared/models/student/studentCreation.model';
import { StudentGroup } from 'src/app/shared/models/studentGroup/studentGroup.model';
import { StudentGroupsService } from 'src/app/studentGroups/student-groups.service';
import { StudentsService } from '../students.service';

@Component({
  selector: 'app-create-students',
  templateUrl: './create-students.component.html',
  styleUrls: ['./create-students.component.css']
})
export class CreateStudentsComponent implements OnInit {

  createStudentForm: FormGroup;
  studentGroups: StudentGroup[] | undefined;

  constructor(private studentsService: StudentsService, 
    private studentGroupsService: StudentGroupsService, 
    private router: Router,
    private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.studentGroupsService.getAll().subscribe((studentGroups: StudentGroup[]) => {
      this.studentGroups = studentGroups;
    })

    this.createStudentForm = this.formBuilder.group({
      firstName: [null, [Validators.required]],
      lastName: [null, [Validators.required]],
      dateOfBirth: [null],
      email: [null, [Validators.required]],
      phoneNumber: [null, [Validators.required]],
      groupId: [null]
    });
  }

  saveChanges(studentCreation: StudentCreation) {
    this.studentsService.create(studentCreation).subscribe(() => {
      this.router.navigate(['students']);
    })
  }
}
