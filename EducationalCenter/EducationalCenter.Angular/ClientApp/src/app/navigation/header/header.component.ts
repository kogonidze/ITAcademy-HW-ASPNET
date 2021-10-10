import { Component, EventEmitter, OnInit, Output } from "@angular/core";
import { Router } from "@angular/router";
import { AuthorizationService } from "src/authorization/authorization.service";

@Component({
  selector: "app-header",
  templateUrl: "./header.component.html",
  styleUrls: ["./header.component.css"],
})
export class HeaderComponent implements OnInit {
  @Output() public sidenavToggle = new EventEmitter();
  public isUserAuthenticated: boolean;

  constructor(
    private _authService: AuthorizationService,
    private _router: Router
  ) {
    this._authService.authChanged.subscribe((res) => {
      this.isUserAuthenticated = res;
    });
  }

  ngOnInit(): void {
    this._authService.authChanged.subscribe((res) => {
      this.isUserAuthenticated = res;
    });
  }

  public onToggleSidenav = () => {
    this.sidenavToggle.emit();
  };

  public logout = () => {
    this._authService.logout();
    this._router.navigate(["/"]);
  };
}
