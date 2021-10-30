import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { StudentFullInfo } from 'src/app/shared/models/student/studentFullInfo.model';
import { StudentGroup } from 'src/app/shared/models/studentGroup/studentGroup.model';
import { StudentGroupsService } from 'src/app/studentGroups/student-groups.service';
import { StudentsService } from '../students.service';

@Component({
  selector: 'app-edit-student',
  templateUrl: './edit-student.component.html',
  styleUrls: ['./edit-student.component.css']
})
export class EditStudentComponent implements OnInit {

  constructor(private activatedRoutes: ActivatedRoute,
    private studentsService: StudentsService,
    private studentGroupsService: StudentGroupsService, 
    private router: Router, private formBuilder: FormBuilder) { }

  editStudentForm: FormGroup;
  student: StudentFullInfo | undefined;
  studentGroups: StudentGroup[] | undefined;
  
  ngOnInit(): void {
    this.editStudentForm = this.formBuilder.group({
      firstName: [null, [Validators.required]],
      lastName: [null, [Validators.required]],
      dateOfBirth: [null],
      eMail: [null, [Validators.required]],
      phoneNumber: [null, [Validators.required]],
      groupId: [null]
    })

    this.activatedRoutes.params.subscribe(params => {
      this.studentsService.getById(params.id).subscribe((student: StudentFullInfo) => {
        this.student = student;

        this.editStudentForm.patchValue(this.student);
      });
    })

    this.studentGroupsService.getAll().subscribe((studentGroups: StudentGroup[]) => {
      this.studentGroups = studentGroups;
    });

  }

  saveChanges() {
    this.student.firstName = this.editStudentForm.get("firstName").value;
    this.student.lastName = this.editStudentForm.get("lastName").value;
    this.student.dateOfBirth = this.editStudentForm.get("dateOfBirth").value;
    this.student.eMail = this.editStudentForm.get("eMail").value;
    this.student.phoneNumber = this.editStudentForm.get("phoneNumber").value;
    this.student.groupId = this.editStudentForm.get("groupId").value;

    this.studentsService.edit(this.student).subscribe(() => {
      this.router.navigate(['/students']);
    })
  }

}
