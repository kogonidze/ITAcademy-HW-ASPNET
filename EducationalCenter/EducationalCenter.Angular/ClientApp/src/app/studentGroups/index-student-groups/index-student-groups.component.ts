import { Component, OnInit } from '@angular/core';
import { StudentGroup } from 'src/app/shared/models/studentGroup/studentGroup.model';
import { StudentGroupsService } from '../student-groups.service';

@Component({
  selector: 'app-index-student-groups',
  templateUrl: './index-student-groups.component.html',
  styleUrls: ['./index-student-groups.component.css']
})
export class IndexStudentGroupsComponent implements OnInit {

  constructor(private studentGroupsService: StudentGroupsService) { }

  studentGroups: StudentGroup[] | undefined;
  columnsToDisplay = ["title", "faculty", "startYear", "endingYear", "actions"];
  
  ngOnInit() : void {
    this.loadStudentGroups();
  }

  loadStudentGroups() {
    this.studentGroupsService.getAll().subscribe((studentGroups: StudentGroup[]) => {
      this.studentGroups = studentGroups;
    })
  }
}
