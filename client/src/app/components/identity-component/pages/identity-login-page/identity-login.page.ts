import { Component } from '@angular/core';
import {Login} from './../../models/loginModel';
import {AuthService} from './../../services/auth.service';
import {Router} from "@angular/router";
import {JwtHelperService} from "@auth0/angular-jwt";

@Component({
  templateUrl: './identity-login.page.html',
  styleUrls: ['./identity-login.page.scss']
})
export class IdentityLoginPage{
  title = 'client';
  userLogin = new Login();

  constructor(private jwtHelper: JwtHelperService, private authService: AuthService, private router : Router) {
  }

  login(userLogin: Login){
    this.authService.login(userLogin).subscribe((token: string) => {
      localStorage.setItem('authToken', token);
      this.router.navigate(['datatable']);
      this.isAdmin(token);
    });
  }

  public isAdmin(token: string):void {
    if (token && !this.jwtHelper.isTokenExpired(token)) {
      const decodedToken = this.jwtHelper.decodeToken(token);
      console.log(decodedToken);
      const role = decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];

      // Перевірка на наявність ролі Admin
      const isAdmin = role === 'Admin';

      localStorage.setItem('isAdmin', isAdmin.toString()); // Збереження ролі адміна
    }
  }
}
