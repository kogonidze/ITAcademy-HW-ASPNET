import { Component, EventEmitter, OnInit, Output } from "@angular/core";
import { Router } from "@angular/router";
import { AuthorizationService } from "src/authorization/authorization.service";

@Component({
  selector: "app-sidenav-list",
  templateUrl: "./sidenav-list.component.html",
  styleUrls: ["./sidenav-list.component.css"],
})
export class SidenavListComponent implements OnInit {
  @Output() sidenavClose = new EventEmitter();
  public isUserAuthenticated: boolean;
  public isUserAdmin: boolean;
  public isUserManager: boolean;

  constructor(
    private _authService: AuthorizationService,
    private _router: Router
  ) {
    this._authService.authChanged.subscribe((res) => {
      this.isUserAuthenticated = res;
    });
    this._authService.authIsAdminRole.subscribe((res) => {
      this.isUserAdmin = res;
    });
    this._authService.authIsManagerRole.subscribe((res) => {
      this.isUserManager = res;
  })}

  ngOnInit(): void {
    this._authService.authChanged.subscribe((res) => {
      this.isUserAuthenticated = res;
    });
    this._authService.authIsAdminRole.subscribe((res) => {
      this.isUserAdmin = res;
    });
    this._authService.authIsManagerRole.subscribe((res) => {
      this.isUserManager = res;
  })}

  public onSidenavClose = () => {
    this.sidenavClose.emit();
  };

  public logout = () => {
    this._authService.logout();
    this._router.navigate(["/"]);
  };
}
