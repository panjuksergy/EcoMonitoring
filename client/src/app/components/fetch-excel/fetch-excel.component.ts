import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {CreateEcoRecordlModel} from "../new-url-component/models/create-eco-recordl.model";
import {Observable} from "rxjs";
import {Router} from "@angular/router";

@Component({
  selector: 'app-fetch-excel',
  templateUrl: './fetch-excel.component.html',
  styleUrls: ['./fetch-excel.component.scss']
})
export class FetchExcelComponent implements OnInit {
  constructor(private http: HttpClient, private router: Router) { }

  public FetchDataFromExcelToBdEndpointCall(): Observable<any>{
    return this.http.get(`https://localhost:5001/api/urlAdmin/writeDataFromXL`,);
  }
  ngOnInit(): void {
      this.FetchDataFromExcelToBdEndpointCall().subscribe();
      setTimeout(() => {
        const currentUrl = this.router.url;
        this.router.navigateByUrl('/datatable', { skipLocationChange: true }).then(() => {
        });
      },700);
    }

}
