import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { SignupUserComponent } from "./signup-user/signup-user.component";
import { RouterModule } from "@angular/router";
import { MaterialModule } from "src/app/material/material.module";
import { ReactiveFormsModule } from "@angular/forms";
import { SigninUserComponent } from "./signin-user/signin-user.component";

@NgModule({
  declarations: [SignupUserComponent, SigninUserComponent],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: "signup", component: SignupUserComponent },
      { path: "signin", component: SigninUserComponent },
    ]),
    MaterialModule,
    ReactiveFormsModule,
  ],
})
export class AuthorizationModule {}
