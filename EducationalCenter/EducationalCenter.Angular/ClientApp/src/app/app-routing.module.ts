import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { CoursesComponent } from "./courses/courses.component";
import { HomeComponent } from "./home/home.component";
import { NotFoundComponent } from "./shared/components/not-found/not-found.component";
import { AuthGuard } from "./shared/guards/auth.guard";
import { ManagerGuard } from "./shared/guards/manager.guard";
import { IndexStudentsComponent } from "./students/index-students/index-students.component";

const routes: Routes = [
  { path: "home", component: HomeComponent },
  { path: "courses", component: CoursesComponent },
  {
    path: "authorization",
    loadChildren: () =>
      import("../authorization/authorization.module").then(
        (m) => m.AuthorizationModule
      ),
  },
  { path: "students", component: IndexStudentsComponent, canActivate: [AuthGuard, ManagerGuard] },
  { path: "NotFound", component: NotFoundComponent },
  { path: "", redirectTo: "/home", pathMatch: "full" },
];

@NgModule({
  imports: [CommonModule, RouterModule.forRoot(routes)],
  exports: [RouterModule],
  declarations: [],
})
export class AppRoutingModule { }
