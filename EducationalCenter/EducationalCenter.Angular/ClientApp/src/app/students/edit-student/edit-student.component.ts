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
  studentGroup: StudentGroup | undefined;
  
  ngOnInit(): void {
    this.activatedRoutes.params.subscribe(params => {
      this.studentsService.getById(params.id).subscribe((student: StudentFullInfo) => {
        console.log(student);
        this.student = student});
    })

    if (this.student !== undefined) {
      if (this.student.groupId) {
        this.studentGroupsService.getById(this.student.groupId).subscribe((studentGroup: StudentGroup) => {
          console.log(studentGroup);
          this.studentGroup = studentGroup;
        })
      }
    }

    this.editStudentForm = this.formBuilder.group({
      firstName: [null, [Validators.required]],
      lastName: [null, [Validators.required]],
      dateOfBirth: [null],
      email: [null, [Validators.required]],
      phoneNumber: [null, [Validators.required]],
      groupId: [null]
    })
  }

}
