import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";

import { AppComponent } from "./app.component";
import { HomeComponent } from "./home/home.component";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { AppRoutingModule } from "./app-routing.module";
import { IndexCoursesComponent } from "./courses/index-courses/index-courses.component";
import { MaterialModule } from "./material/material.module";
import { HeaderComponent } from "./navigation/header/header.component";
import { SidenavListComponent } from "./navigation/sidenav-list/sidenav-list.component";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { JwtModule } from "@auth0/angular-jwt";

import { NotFoundComponent } from "./shared/components/not-found/not-found.component";
import { ErrorHandlerService } from "./shared/services/error-handler.service";
import { AuthGuard } from "./shared/guards/auth.guard";
import { AdminGuard } from "./shared/guards/admin.guard";
import { ManagerGuard } from "./shared/guards/manager.guard";
import { IndexStudentsComponent } from "./students/index-students/index-students.component";
import { CreateStudentsComponent } from "./students/create-students/create-students.component";
import { ReactiveFormsModule } from "@angular/forms";
import { MAT_DATE_LOCALE } from "@angular/material";
import { EditStudentComponent } from "./students/edit-student/edit-student.component";
import { IndexTeachersComponent } from "./teachers/index-teachers/index-teachers.component";
import { CreateTeachersComponent } from "./teachers/create-teachers/create-teachers.component";
import { EditTeacherComponent } from "./teachers/edit-teacher/edit-teacher.component";
import { IndexStudentGroupsComponent } from "./studentGroups/index-student-groups/index-student-groups.component";
import { CreateStudentGroupComponent } from "./studentGroups/create-student-group/create-student-group.component";
import { EditStudentGroupComponent } from "./studentGroups/edit-student-group/edit-student-group.component";
import { IndexFacultiesComponent } from "./faculties/index-faculties/index-faculties.component";
import { IndexDepartmentsComponent } from "./departments/index-departments/index-departments.component";
import { ForbiddenComponent } from "./shared/components/forbidden/forbidden.component";
import { ServerErrorComponent } from "./shared/components/server-error/server-error.component";

export function tokenGetter() {
  return localStorage.getItem("token");
}

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    IndexCoursesComponent,
    IndexStudentsComponent,
    CreateStudentsComponent,
    EditStudentComponent,
    IndexTeachersComponent,
    CreateTeachersComponent,
    EditTeacherComponent,
    IndexStudentGroupsComponent,
    CreateStudentGroupComponent,
    EditStudentGroupComponent,
    IndexFacultiesComponent,
    IndexDepartmentsComponent,
    HeaderComponent,
    SidenavListComponent,
    NotFoundComponent,
    ForbiddenComponent,
    ServerErrorComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    MaterialModule,
    HttpClientModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        whitelistedDomains: ["localhost:5001"],
        blacklistedRoutes: [],
      },
    }),
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorHandlerService,
      multi: true,
    },
    [AuthGuard],
    [AdminGuard],
    [ManagerGuard]
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
