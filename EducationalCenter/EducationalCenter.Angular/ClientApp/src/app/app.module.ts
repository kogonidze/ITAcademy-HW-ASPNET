import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";

import { AppComponent } from "./app.component";
import { HomeComponent } from "./home/home.component";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { AppRoutingModule } from "./app-routing.module";
import { CoursesComponent } from "./courses/courses.component";
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

export function tokenGetter() {
  return localStorage.getItem("token");
}

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CoursesComponent,
    IndexStudentsComponent,
    CreateStudentsComponent,
    HeaderComponent,
    SidenavListComponent,
    NotFoundComponent,
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
