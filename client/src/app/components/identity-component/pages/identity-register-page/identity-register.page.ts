import { Component } from '@angular/core';
import {Login} from './../../models/loginModel';
import {AuthService} from './../../services/auth.service';
import {RegistrationModel} from "../../models/registrationModel";

@Component({
  templateUrl: './identity-register.page.html',
  styleUrls: ['./identity-register.page.scss']
})
export class IdentityRegisterPage{
  title = 'client';
  registrationModel = new RegistrationModel();
  constructor(private authService: AuthService) {
  }

  register(registrationModel: RegistrationModel){
    this.authService.register(registrationModel).subscribe();
  }
}
