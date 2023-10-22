import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Login} from "../models/loginModel";
import {RegistrationModel} from "../models/registrationModel";
import {Router} from "@angular/router";

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(private http: HttpClient, private router: Router) {
  }

  public register(user: RegistrationModel): Observable<any> {
    return this.http.post('https://localhost:5004/api/UserAnonymous/register', user);
  }

  public login(user: Login): Observable<any> {
    return this.http.post('https://localhost:5003/api/identity/login', user, {
      responseType: 'text',
    });
  }

  public logout(){
    localStorage.removeItem('authToken');
    this.router.navigate(['login']);
  }

  public isLoggedIn() {
    return !!localStorage.getItem('authToken');
  }
}
