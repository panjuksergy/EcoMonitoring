import {Component, OnInit} from '@angular/core';
import {AboutPageService} from "./services/about-page.service";
import {error} from "@angular/compiler-cli/src/transformers/util";
import {Subscription} from "rxjs";

@Component({
  selector: 'app-about-page-component',
  templateUrl: './about-page.component.html',
  styleUrls: ['./about-page.component.scss']
})
export class AboutPageComponent implements OnInit{
  paragraphs: string[] = [];
  isPopOverVisible = false;
  is405 = false;
  isAdmin = false;
  newText = '';
  shownText = 'Enter new text';
  urNotAdminText = 'You are not Admin!'
  constructor(private aboutService :AboutPageService) {
  }
  ngOnInit(): void {
    this.aboutService.getAbout().subscribe((data) => {
      this.paragraphs = data.data.split('\n\n');
    })
    const storedIsAdmin = localStorage.getItem('isAdmin');
    if (storedIsAdmin !== null) {
      this.isAdmin = JSON.parse(storedIsAdmin);
    }
  }

  onChangeText(){
    this.isPopOverVisible = true;
  }
  onOkey(newText: string){
    this.aboutService.setAbout(newText).subscribe((errorResponse) => {
      if (errorResponse.status === 405) {
        this.is405 = true;
      } else {
        this.newText = newText; // Оновлення змінної newText у компоненті AboutPageComponent
      }
    });

    this.isPopOverVisible = false;
    setTimeout(() => {
      location.reload(); // Це перезавантажить сторінку через одну секунду
    }, 1000);

  }
}
