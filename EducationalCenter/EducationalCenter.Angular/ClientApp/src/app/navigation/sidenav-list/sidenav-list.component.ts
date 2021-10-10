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

  constructor(
    private _authService: AuthorizationService,
    private _router: Router
  ) {}

  ngOnInit(): void {
    this._authService.authChanged.subscribe((res) => {
      this.isUserAuthenticated = res;
    });
  }

  public onSidenavClose = () => {
    this.sidenavClose.emit();
  };

  public logout = () => {
    //this.sidenavClose.emit();
    this._authService.logout();
    this._router.navigate(["/"]);
  };
}
