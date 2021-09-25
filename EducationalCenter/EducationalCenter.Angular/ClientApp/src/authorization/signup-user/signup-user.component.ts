import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { UserRegistration } from "src/app/shared/models/user/userRegistration.model";
import { AuthorizationService } from "../authorization.service";

@Component({
  selector: "app-signup-user",
  templateUrl: "./signup-user.component.html",
  styleUrls: ["./signup-user.component.css"],
})
export class SignupUserComponent implements OnInit {
  public registerForm: FormGroup;

  constructor(private authService: AuthorizationService) {}

  ngOnInit(): void {
    this.registerForm = new FormGroup({
      email: new FormControl("", [Validators.required, Validators.email]),
      password: new FormControl("", Validators.required),
      confirmPassword: new FormControl("", Validators.required),
    });
  }

  public validateControl = (controlName: string) => {
    return (
      this.registerForm.controls[controlName].invalid &&
      this.registerForm.controls[controlName].touched
    );
  };

  public hasError = (controlName: string, errorName: string) => {
    return this.registerForm.controls[controlName].hasError(errorName);
  };

  public registerUser = (registerFormValue) => {
    const formValues = { ...registerFormValue };
    const user: UserRegistration = {
      email: formValues.email,
      password: formValues.password,
      confirmPassword: formValues.confirmPassword,
    };

    this.authService.registerUser(user).subscribe(
      (_) => {
        console.log("Successful registration");
      },
      (error) => {
        console.log(error.error.errors);
      }
    );
  };

  getEmailErrorMessage() {
    var field = this.registerForm.get("email");

    if (field.hasError("required")) {
      return "Email is required";
    }

    if (field.hasError("email")) {
      return "Please provide email in valid format";
    }

    return "";
  }

  getPasswordErrorMessage() {
    var field = this.registerForm.get("password");

    if (field.hasError("required")) {
      return "Password is required";
    }

    return "";
  }

  getConfirmPasswordErrorMessage() {
    var field = this.registerForm.get("confirmPassword");

    if (field.hasError("required")) {
      return "Confirm password is required";
    }

    return "";
  }
}
