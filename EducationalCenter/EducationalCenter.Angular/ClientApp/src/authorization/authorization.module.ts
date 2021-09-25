import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { SignupUserComponent } from "./signup-user/signup-user.component";
import { RouterModule } from "@angular/router";
import { MaterialModule } from "src/app/material/material.module";
import { ReactiveFormsModule } from "@angular/forms";

@NgModule({
  declarations: [SignupUserComponent],
  imports: [
    CommonModule,
    RouterModule.forChild([{ path: "signup", component: SignupUserComponent }]),
    MaterialModule,
    ReactiveFormsModule,
  ],
})
export class AuthorizationModule {}
