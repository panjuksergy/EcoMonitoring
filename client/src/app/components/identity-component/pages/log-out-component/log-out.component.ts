import {Component, OnInit} from '@angular/core';
import {AuthService} from "../../services/auth.service";

@Component({
  selector: 'app-log-out-component',
  templateUrl: './log-out.component.html',
  styleUrls: ['./log-out.component.scss']
})
export class LogOutComponent implements OnInit{
  constructor(private authService: AuthService) {
  }
  ngOnInit(): void {
    this.authService.logout();
  }
}
