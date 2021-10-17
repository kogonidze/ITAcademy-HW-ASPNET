import { Component } from "@angular/core";
import { AuthorizationService } from "src/authorization/authorization.service";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.css"],
})
export class AppComponent {
  title = "app";

  constructor(private authService: AuthorizationService) {}

  ngOnInit(): void {
    if (this.authService.isUserAuthenticated())
      this.authService.sendAuthStateChangeNotification(true);

    if (this.authService.isUserAdmin())
      this.authService.sendAuthIsAdminRoleNotification(true);

    if (this.authService.isUserManager())
      this.authService.sendAuthIsManagerRoleNotification(true);
  }
}
