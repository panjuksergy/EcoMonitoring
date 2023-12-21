import {Component, OnInit} from '@angular/core';

@Component({
  selector: 'app-nav-bar-component',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit{
  isAdmin = false;

  ngOnInit(){
    const storedIsAdmin = localStorage.getItem('isAdmin');
    if (storedIsAdmin !== null) {
      this.isAdmin = JSON.parse(storedIsAdmin);
    }
  }
}
