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
import {faCircleInfo} from "@fortawesome/free-solid-svg-icons";

@Component({
  selector: 'app-url-table',
  templateUrl: './url-table.component.html',
  styleUrls: ['./url-table.component.scss'],
})
export class UrlTableComponent implements OnInit {
  ecoRecords: any[] = [];
  detailsToShow = '';
  refundInfo = '';
  getEcoRecordsReq: GetAllRequestModel = {};
  isLoggedIn: boolean = false;
  isOverlayVisible = false;
  isDetailsVisible =  false;
  isRefundInfoVisible = false;
  isAdmin = false;
  increment = 0;
  constructor(private ecoRecordsService: EcoRecordsService, private authService: AuthService, private sanitizer: DomSanitizer, private router : Router) {}

  async ngOnInit(): Promise<void> {
    this.isLoggedIn = this.authService.isLoggedIn();
    this.fetchAllEcoRecords();
    const storedIsAdmin = localStorage.getItem('isAdmin');
    if (storedIsAdmin !== null) {
      this.isAdmin = JSON.parse(storedIsAdmin);
    }
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
    },500);
  }

  isLastRecordOfMonth(index: number): boolean {
    if (index <= this.ecoRecords.length - 1) {
      const currentRecord = this.ecoRecords[index];
      const nextRecord = this.ecoRecords[index + 1];
      if (nextRecord == null && this.isAdmin){
        return true;
      }
      const nextRecordMonth = new Date(nextRecord.creationDate).getMonth();
      // Перевірка, чи наступний запис належить до іншого місяця
      return (new Date(currentRecord.creationDate).getMonth() !== nextRecordMonth && this.isAdmin) ;
    }
    return false;
  }


  showEcoRecordDetails(ulrId: string): void{
    this.ecoRecordsService.getMonitoringDetails(ulrId).subscribe((data) => {
      this.detailsToShow = `
        Suspend Solids = ${data.suspendedSolidsStat}<br/>
        Sulfur Dioxide Stat = ${data.sulfurDioxideStat}<br/>
        Carbon Dioxide Stat = ${data.carbonDioxideStat}<br/>
        Nitrogen Dioxide Stat = ${data.nitrogenDioxideStat}<br/>
        Hydrogen Fluoride Stat = ${data.hydrogenFluorideStat}<br/>
        Ammonia Stat = ${data.ammoniaStat}<br/>
        Formaldehyde Stat = ${data.formaldehydeStat}<br/><br/><br/>
        Total Non-Cancer Risk = ${data.totalNonCancerRisk}<br/>
    `;

    });
    this.isDetailsVisible = true;
  }

  showRefundInfo(creationDate: any): void{
    const date = new Date(creationDate);

    const month = date.getMonth() + 1; // Adding 1 because getMonth() returns zero-based index (0 for January)
    const year = date.getFullYear();
    this.ecoRecordsService.getRefundInfo(year, month).subscribe((data) => {
      const dateFrom = new Date(data.dateFrom);
      const dateTo = new Date(data.dateTo);
      this.refundInfo = `
      Date From = ${dateFrom}        DateTo = ${dateTo}<br />
                          Amount of money = ${data.money}
    `;

    });
    this.isRefundInfoVisible = true;
  }

  openOverlay() {
    this.isOverlayVisible = true;
  }
  handleOverlayClose() {
    this.isOverlayVisible = false;
  }
  handleDetailsClose() {
    this.isDetailsVisible = false;
    this.isRefundInfoVisible = false;
  }

  protected readonly faTrash = faTrash;
  protected readonly faInfo = faInfo;
  protected readonly faPlus = faPlus;
}
