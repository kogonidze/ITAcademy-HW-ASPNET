import { Injectable } from "@angular/core";
import {
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  UrlTree,
  Router,
} from "@angular/router";
import { Observable } from "rxjs";
import { AuthorizationService } from "src/authorization/authorization.service";

@Injectable({
  providedIn: "root",
})
export class AdminGuard implements CanActivate {
  constructor(
    private _authService: AuthorizationService,
    private _router: Router
  ) {}

  canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    if (this._authService.isUserAdmin()) return true;

    this._router.navigate(["/forbidden"], {
      queryParams: { returnUrl: state.url },
    });

    return false;
  }
}
