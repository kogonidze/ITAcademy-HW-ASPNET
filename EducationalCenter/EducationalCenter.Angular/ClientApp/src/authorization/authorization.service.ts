import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { UserRegistration } from "src/app/shared/models/user/userRegistration.model";

@Injectable({
  providedIn: "root",
})
export class AuthorizationService {
  constructor(private http: HttpClient) {}

  private apiUrl = environment.apiUrl + "authorization";

  registerUser = (newUser: UserRegistration) => {
    return this.http.post(this.apiUrl + "/signup", newUser);
  };
}
