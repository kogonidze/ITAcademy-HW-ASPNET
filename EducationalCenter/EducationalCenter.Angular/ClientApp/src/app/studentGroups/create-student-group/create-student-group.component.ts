import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { FacultyService } from 'src/app/faculties/faculty.service';
import { Faculty } from 'src/app/shared/models/faculty/faculty.model';
import { StudentGroupsService } from '../student-groups.service';

@Component({
  selector: 'app-create-student-group',
  templateUrl: './create-student-group.component.html',
  styleUrls: ['./create-student-group.component.css']
})
export class CreateStudentGroupComponent implements OnInit {

  createStudentGroupForm: FormGroup;
  faculties: Faculty[] | undefined;

  constructor(private studentGroupsService: StudentGroupsService, 
    private facultiesService: FacultyService, 
    private router: Router,
    private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.facultiesService.getAll().subscribe((faculties: Faculty[]) => {
      this.faculties = faculties;
    })

    this.createStudentGroupForm = this.formBuilder.group({
      title: [null, [Validators.required]],
      facultyId: [null],
      startYear: [null, [Validators.required]],
      endingYear: [null, [Validators.required]],
    });
  }

  saveChanges() {
    this.studentGroupsService.create(this.createStudentGroupForm.value).subscribe(() => {
      this.router.navigate(['/studentGroups']);
    })
  }
}
