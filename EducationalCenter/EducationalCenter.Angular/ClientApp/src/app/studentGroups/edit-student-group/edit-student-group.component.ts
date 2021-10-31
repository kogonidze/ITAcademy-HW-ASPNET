import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FacultyService } from 'src/app/faculties/faculty.service';
import { Faculty } from 'src/app/shared/models/faculty/faculty.model';
import { StudentGroupFullInfo } from 'src/app/shared/models/studentGroup/studentGroupFullInfo.model';
import { StudentGroupsService } from '../student-groups.service';

@Component({
  selector: 'app-edit-student-group',
  templateUrl: './edit-student-group.component.html',
  styleUrls: ['./edit-student-group.component.css']
})
export class EditStudentGroupComponent implements OnInit {

  constructor(private activatedRoutes: ActivatedRoute,
    private studentGroupService: StudentGroupsService,
    private facultyService: FacultyService, 
    private router: Router, private formBuilder: FormBuilder) { }

  editStudentGroupForm: FormGroup;
  studentGroup: StudentGroupFullInfo | undefined;
  faculties: Faculty[] | undefined;

  ngOnInit() : void {
    this.editStudentGroupForm = this.formBuilder.group({
      title: [null, [Validators.required]],
      facultyId: [null],
      startYear: [null, [Validators.required]],
      endingYear: [null, [Validators.required]],
    });

    this.activatedRoutes.params.subscribe(params => {
      this.studentGroupService.getById(params.id).subscribe((studentGroup: StudentGroupFullInfo) => {
        this.studentGroup = studentGroup;

        this.editStudentGroupForm.patchValue(this.studentGroup);
      });
    })

    this.facultyService.getAll().subscribe((faculties: Faculty[]) => {
      this.faculties = faculties;
    });

  }

  saveChanges() {
    this.studentGroup.title = this.editStudentGroupForm.get("title").value;
    this.studentGroup.facultyId = this.editStudentGroupForm.get("facultyId").value;
    this.studentGroup.startYear = this.editStudentGroupForm.get("startYear").value;
    this.studentGroup.endingYear = this.editStudentGroupForm.get("endingYear").value;

    this.studentGroupService.edit(this.studentGroup).subscribe(() => {
      this.router.navigate(['/studentGroups']);
    })
  }

}
