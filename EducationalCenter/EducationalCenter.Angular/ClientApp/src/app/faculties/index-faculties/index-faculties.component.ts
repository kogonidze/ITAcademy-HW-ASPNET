import { Component, OnInit } from '@angular/core';
import { Faculty } from 'src/app/shared/models/faculty/faculty.model';
import { FacultyService } from '../faculty.service';

@Component({
  selector: 'app-index-faculties',
  templateUrl: './index-faculties.component.html',
  styleUrls: ['./index-faculties.component.css']
})
export class IndexFacultiesComponent implements OnInit {

  constructor(private facultiesService: FacultyService) { }

  faculties: Faculty[] | undefined;
  columnsToDisplay = ["name"];
  
  ngOnInit() : void {
    this.loadFaculties();
  }

  loadFaculties() {
    this.facultiesService.getAll().subscribe((faculties: Faculty[]) => {
      this.faculties = faculties;
    })
  }

}
