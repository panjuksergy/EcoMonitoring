import { Component, OnInit } from '@angular/core';
import { EcoRecordsService } from './services/eco-records.service';
import {GetAllRequestModel} from "./models/get-all-request.model";
import { faTrash} from "@fortawesome/free-solid-svg-icons/faTrash"
import { faInfo} from "@fortawesome/free-solid-svg-icons/faInfo";
import { faPlus} from "@fortawesome/free-solid-svg-icons/faPlus";
import {AuthService} from "../identity-component/services/auth.service";
import {DomSanitizer} from "@angular/platform-browser";
import {Router} from "@angular/router";
import {delay} from "rxjs";

@Component({
  selector: 'app-url-table',
  templateUrl: './url-table.component.html',
  styleUrls: ['./url-table.component.scss'],
})
export class UrlTableComponent implements OnInit {
  ecoRecords: any[] = [];
  detailsToShow = '';
  getEcoRecordsReq: GetAllRequestModel = {};
  isLoggedIn: boolean = false;
  isOverlayVisible = false;
  isDetailsVisible =  false;
  increment = 0;
  constructor(private ecoRecordsService: EcoRecordsService, private authService: AuthService, private sanitizer: DomSanitizer, private router : Router) {}

  async ngOnInit(): Promise<void> {
    this.isLoggedIn = this.authService.isLoggedIn();
    this.fetchAllEcoRecords();
  }
  fetchAllEcoRecords(): void {
    this.ecoRecordsService.getAllEcoRecords(this.getEcoRecordsReq).subscribe((data) => {
      this.ecoRecords = data.ecoRecords;
    });
  }
  deleteEcoRecord(urlId: string): void{
    this.ecoRecordsService.deleteEcoRecord(urlId).subscribe((data) => {
      console.log("deleted");
    });
    setTimeout(() => {
      const currentUrl = this.router.url;
      this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
        this.router.navigateByUrl(currentUrl);
      });
    },400);
  }

  showEcoRecordDetails(ulrId: string): void{
    this.ecoRecordsService.getUrlDetails(ulrId).subscribe((data) => {
      this.detailsToShow = `Url Id = ${data.urlId}<br/>Url From = ${data.urlFrom}<br/>Url to = ${data.urlTo}<br/>
                            Created ${data.creationDate}<br/> Created by ${data.userId}`;
    });
    this.isDetailsVisible = true;
  }
  openOverlay() {
    this.isOverlayVisible = true;
  }
  handleOverlayClose() {
    this.isOverlayVisible = false;
  }
  handleDetailsClose() {
    this.isDetailsVisible = false;
  }

  protected readonly faTrash = faTrash;
  protected readonly faInfo = faInfo;
  protected readonly faPlus = faPlus;
}