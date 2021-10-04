import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { UserRegistration } from "src/app/shared/models/user/userRegistration.model";
import { UserAuthentication } from "src/app/shared/models/user/userAuthentication.model";
import { Subject } from "rxjs";

@Injectable({
  providedIn: "root",
})
export class AuthorizationService {
  private _authChangeSub = new Subject<boolean>();
  public authChanged = this._authChangeSub.asObservable();

  constructor(private http: HttpClient) {}

  private apiUrl = environment.apiUrl + "authorization";

  public sendAuthStateChangeNotification = (isAuthenticated: boolean) => {
    this._authChangeSub.next(isAuthenticated);
  };

  registerUser = (newUser: UserRegistration) => {
    return this.http.post(this.apiUrl + "/signup", newUser);
  };

  loginUser = (user: UserAuthentication) => {
    return this.http.post(this.apiUrl + "/signin", user);
  };

  logout = () => {
    localStorage.removeItem("token");
    this.sendAuthStateChangeNotification(false);
  };
}
