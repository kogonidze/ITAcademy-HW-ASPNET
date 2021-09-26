import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { PasswordConfirmationValidatorService } from "src/app/shared/custom-validators/password-confirmation-validator.service";
import { UserRegistration } from "src/app/shared/models/user/userRegistration.model";
import { AuthorizationService } from "../authorization.service";

@Component({
  selector: "app-signup-user",
  templateUrl: "./signup-user.component.html",
  styleUrls: ["./signup-user.component.css"],
})
export class SignupUserComponent implements OnInit {
  public registerForm: FormGroup;
  public errorMessage: string = "";
  public showError: boolean;

  constructor(
    private authService: AuthorizationService,
    private passConfValidator: PasswordConfirmationValidatorService
  ) {}

  ngOnInit(): void {
    this.registerForm = new FormGroup({
      email: new FormControl("", [Validators.required, Validators.email]),
      password: new FormControl("", Validators.required),
      confirmPassword: new FormControl("", Validators.required),
    });

    this.registerForm
      .get("confirmPassword")
      .setValidators([
        Validators.required,
        this.passConfValidator.validateConfirmPassword(
          this.registerForm.get("password")
        ),
      ]);
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
    this.showError = false;
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
        this.errorMessage = error;
        this.showError = true;
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

    if (field.hasError("mustMatch")) {
      return "Passwords must match!";
    }

    return "";
  }
}
