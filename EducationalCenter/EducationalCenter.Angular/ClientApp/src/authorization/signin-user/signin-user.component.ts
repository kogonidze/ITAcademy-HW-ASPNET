import { ThrowStmt } from "@angular/compiler";
import { Route } from "@angular/compiler/src/core";
import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { UserAuthentication } from "src/app/shared/models/user/userAuthentication.model";
import { AuthorizationService } from "../authorization.service";

@Component({
  selector: "app-signin-user",
  templateUrl: "./signin-user.component.html",
  styleUrls: ["./signin-user.component.css"],
})
export class SigninUserComponent implements OnInit {
  public loginForm: FormGroup;
  public errorMessage: string = "";
  public showError: boolean;
  private _returnUrl: string;

  constructor(
    private _authService: AuthorizationService,
    private _router: Router,
    private _route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.loginForm = new FormGroup({
      email: new FormControl("", [Validators.required]),
      password: new FormControl("", [Validators.required]),
    });

    this._returnUrl = this._route.snapshot.queryParams["returnUrl"] || "/";
  }

  public validateControl = (controlName: string) => {
    return (
      this.loginForm.controls[controlName].invalid &&
      this.loginForm.controls[controlName].touched
    );
  };

  public hasError = (controlName: string, errorName: string) => {
    return this.loginForm.controls[controlName].hasError(errorName);
  };

  public loginUser = (loginFormValue) => {
    this.showError = false;
    const login = { ...loginFormValue };
    const userForAuth: UserAuthentication = {
      email: login.email,
      password: login.password,
    };

    this._authService.loginUser(userForAuth).subscribe(
      (res: any) => {
        localStorage.setItem("token", res.token);
        this._authService.sendAuthStateChangeNotification(res.isAuthSuccessful);
        this._router.navigate([this._returnUrl]);
      },
      (error) => {
        this.errorMessage = error;
        this.showError = true;
      }
    );
  };

  public logout = () => {
    this._authService.logout();
    this._router.navigate(["/"]);
  };

  getEmailErrorMessage() {
    var field = this.loginForm.get("email");

    if (field.hasError("required")) {
      return "Email is required";
    }

    if (field.hasError("email")) {
      return "Please provide email in valid format";
    }

    return "";
  }

  getPasswordErrorMessage() {
    var field = this.loginForm.get("password");

    if (field.hasError("required")) {
      return "Password is required";
    }

    return "";
  }
}
