import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { CoursesComponent } from "./courses/courses.component";
import { HomeComponent } from "./home/home.component";
import { NotFoundComponent } from "./shared/components/not-found/not-found.component";

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
  { path: "NotFound", component: NotFoundComponent },
  { path: "", redirectTo: "/home", pathMatch: "full" },
];

@NgModule({
  imports: [CommonModule, RouterModule.forRoot(routes)],
  exports: [RouterModule],
  declarations: [],
})
export class AppRoutingModule {}
