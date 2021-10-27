import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { UserRegistration } from "src/app/shared/models/user/userRegistration.model";
import { UserAuthentication } from "src/app/shared/models/user/userAuthentication.model";
import { Subject } from "rxjs";
import { JwtHelperService } from "@auth0/angular-jwt";

@Injectable({
  providedIn: "root",
})
export class AuthorizationService {
  private _authChangeSub = new Subject<boolean>();
  private _authIsAdminRoleSub = new Subject<boolean>();
  private _authIsManagerRoleSub = new Subject<boolean>();

  public authChanged = this._authChangeSub.asObservable();
  public authIsAdminRole = this._authIsAdminRoleSub.asObservable();
  public authIsManagerRole = this._authIsManagerRoleSub.asObservable();

  constructor(private http: HttpClient, private jwtHelper: JwtHelperService) {}

  private apiUrl = environment.apiUrl + "authorization";

  public sendAuthStateChangeNotification = (isAuthenticated: boolean) => {
    this._authChangeSub.next(isAuthenticated);
  };

  public sendAuthIsAdminRoleNotification = (isAdminRole: boolean) => {
    this._authIsAdminRoleSub.next(isAdminRole);
  };

  public sendAuthIsManagerRoleNotification = (isManagerRole: boolean) => {
    this._authIsManagerRoleSub.next(isManagerRole);
  }

  registerUser = (newUser: UserRegistration) => {
    return this.http.post(this.apiUrl + "/signup", newUser);
  };

  loginUser = (user: UserAuthentication) => {
    return this.http.post(this.apiUrl + "/signin", user);
  };

  logout = () => {
    localStorage.removeItem("token");
    this.sendAuthStateChangeNotification(false);
    this.sendAuthIsAdminRoleNotification(false);
    this.sendAuthIsManagerRoleNotification(false);
  };

  isUserAuthenticated = (): boolean => {
    const token = localStorage.getItem("token");

    return token && !this.jwtHelper.isTokenExpired(token);
  };

  isUserAdmin = (): boolean => {
    if (this.isUserAuthenticated())
    {
      const role = this.getRoleFromToken();

      return role === "administrator";
    }
    
    return false;
  };

  isUserManager = (): boolean => {
    if (this.isUserAuthenticated())
    {
      const role = this.getRoleFromToken();

      return role === "manager";
    }

    return false;
  };

  private getRoleFromToken = (): string => {
    const token = localStorage.getItem("token");
    const decodedToken = this.jwtHelper.decodeToken(token);

    const role =
      decodedToken[
        "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
      ];

    return role;
  };
}
