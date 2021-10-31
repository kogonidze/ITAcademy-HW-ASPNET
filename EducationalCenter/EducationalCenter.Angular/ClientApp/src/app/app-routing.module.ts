import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { CoursesComponent } from "./courses/courses.component";
import { IndexDepartmentsComponent } from "./departments/index-departments/index-departments.component";
import { IndexFacultiesComponent } from "./faculties/index-faculties/index-faculties.component";
import { HomeComponent } from "./home/home.component";
import { NotFoundComponent } from "./shared/components/not-found/not-found.component";
import { AuthGuard } from "./shared/guards/auth.guard";
import { ManagerGuard } from "./shared/guards/manager.guard";
import { CreateStudentGroupComponent } from "./studentGroups/create-student-group/create-student-group.component";
import { EditStudentGroupComponent } from "./studentGroups/edit-student-group/edit-student-group.component";
import { IndexStudentGroupsComponent } from "./studentGroups/index-student-groups/index-student-groups.component";
import { CreateStudentsComponent } from "./students/create-students/create-students.component";
import { EditStudentComponent } from "./students/edit-student/edit-student.component";
import { IndexStudentsComponent } from "./students/index-students/index-students.component";
import { CreateTeachersComponent } from "./teachers/create-teachers/create-teachers.component";
import { EditTeacherComponent } from "./teachers/edit-teacher/edit-teacher.component";
import { IndexTeachersComponent } from "./teachers/index-teachers/index-teachers.component";

const routes: Routes = [
  { path: "home", component: HomeComponent },
  { path: "courses", component: CoursesComponent },
  { path: "faculties", component: IndexFacultiesComponent},
  { path: "departments", component: IndexDepartmentsComponent},
  {
    path: "authorization",
    loadChildren: () =>
      import("../authorization/authorization.module").then(
        (m) => m.AuthorizationModule
      ),
  },
  { path: "students", component: IndexStudentsComponent, canActivate: [AuthGuard, ManagerGuard] },
  { path: "students/create", component: CreateStudentsComponent, canActivate: [AuthGuard, ManagerGuard]},
  { path: "students/edit/:id", component: EditStudentComponent, canActivate: [AuthGuard, ManagerGuard]},
  { path: "teachers", component: IndexTeachersComponent, canActivate: [AuthGuard, ManagerGuard]},
  { path: "teachers/create", component: CreateTeachersComponent, canActivate: [AuthGuard, ManagerGuard]},
  { path: "teachers/edit/:id", component: EditTeacherComponent, canActivate: [AuthGuard, ManagerGuard]},
  { path: "studentGroups", component: IndexStudentGroupsComponent, canActivate: [AuthGuard, ManagerGuard]},
  { path: "studentGroups/create", component: CreateStudentGroupComponent, canActivate: [AuthGuard, ManagerGuard]},
  { path: "studentGroups/edit/:id", component: EditStudentGroupComponent, canActivate: [AuthGuard, ManagerGuard]},
  { path: "NotFound", component: NotFoundComponent },
  { path: "", redirectTo: "/home", pathMatch: "full" },
];

@NgModule({
  imports: [CommonModule, RouterModule.forRoot(routes)],
  exports: [RouterModule],
  declarations: [],
})
export class AppRoutingModule { }
