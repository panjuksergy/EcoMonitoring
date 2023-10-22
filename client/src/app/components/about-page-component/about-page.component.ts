import {Component, OnInit} from '@angular/core';
import {AboutPageService} from "./services/about-page.service";
import {error} from "@angular/compiler-cli/src/transformers/util";

@Component({
  selector: 'app-about-page-component',
  templateUrl: './about-page.component.html',
  styleUrls: ['./about-page.component.scss']
})
export class AboutPageComponent implements OnInit{
  paragraphs: string[] = [];
  isPopOverVisible = false;
  is405 = false;
  shownText = 'Enter new text';
  urNotAdminText = 'You are not Admin!'
  constructor(private aboutService :AboutPageService) {
  }
  ngOnInit(): void {
    this.aboutService.getAbout().subscribe((data) => {
      this.paragraphs = data.data.split('\n\n');
    })
  }

  onChangeText(){
    this.isPopOverVisible = true;
  }
  onOkey(newText: string){
    this.aboutService.setAbout(newText).subscribe((error) => {
      if(error.status === 405) {
        this.is405 = true;
      }
    });
  }
}
